using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]

namespace CDC.WebNotes.DB.Migrations
{
    internal class Program
    {
        private static IConfiguration _configuration;

        private static int Main(string[] args)
        {
            try
            {
                Log.Information("Starting db migrator");

                IServiceProvider serviceProvider = CreateServices();

                // Put the database update into a scope to ensure
                // that all resources will be disposed.
                using IServiceScope scope = serviceProvider.CreateScope();

                MigrationDirection migrationDirection = MigrationDirection.Up;

                IServiceProvider scopeServiceProvider = scope.ServiceProvider;

                try
                {
                    UpdateDatabase(scopeServiceProvider, migrationDirection);
                }
                catch (Exception exception)
                {
                    Log.Error(exception, "Failed to update database");
                    if (exception.InnerException != null)
                        throw exception.InnerException;
                    throw;
                };

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Db migrator terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                  .AddScoped(provider => Configuration)
                  .AddFluentMigratorCore()
                  .ConfigureRunner(runnerBuilder =>
                                       runnerBuilder
                                          // Add SqlServer to FluentMigrator
                                          .AddSqlServer()
                                          // Set global timeout
                                          .WithGlobalCommandTimeout(TimeSpan.FromMinutes(1))
                                          .WithGlobalConnectionString(provider =>
                                          {
                                              IConfiguration configuration =
                                                  provider.GetRequiredService<IConfiguration>();

                                              return configuration.GetConnectionString("migrationDb");
                                          })
                                          .ScanIn(typeof(Program).Assembly)
                                          .For.Migrations())
                                          .AddLogging(lb => lb.AddFluentMigratorConsole())
                                          // TODO Add migration Tags 
                                          .Configure<RunnerOptions>(opt =>
                                          {
                                              string tag = Configuration.GetValue<string>("migrationTag");

                                              if (!string.IsNullOrEmpty(tag))
                                              {
                                                  Log.Debug("MigrationTag: {Tag}", tag);

                                                  opt.Tags = new[] { tag };
                                              }
                                              else
                                              {
                                                  Log.Warning("No migration tag to apply");
                                              }
                                          })
                                          .BuildServiceProvider(false);
        }

        private static IConfiguration Configuration
        {
            get
            {
                if (_configuration != null)
                {
                    return _configuration;
                }

                IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                                                      .AddJsonFile("appsettings.json")
                                                      .Build();
                _configuration = configurationRoot;

                return configurationRoot;
            }
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider, MigrationDirection migrationDirection)
        {
            IMigrationRunner runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            Log.Debug("Run migrations");
            runner.ListMigrations();

            if (migrationDirection == MigrationDirection.Up)
            {
                if (!runner.HasMigrationsToApplyUp())
                {
                    Log.Warning("Migrations to Up not found");
                    return;
                }

                Log.Information("Execute Up migrations");

                runner.ValidateVersionOrder();
                runner.MigrateUp();
            }
            else
            {
                if (!runner.HasMigrationsToApplyRollback())
                {
                    Log.Warning("Migrations to rollback not found");
                    return;
                }

                Log.Information("Rollback ONE migration");
                runner.Rollback(1);
            }
        }
    }
}
