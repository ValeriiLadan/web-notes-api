using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CDC.WebNotes.Data;
using CDC.WebNotes.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebNotes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;           
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            services.AddDbContext<ApplicationDbContext>(
                op => op.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddProblemDetailsConfig();

            services.AddServices();

            services.AddRepositories();

            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddFluentValidationConfig();

            services.AddSwaggerGen();

            services.AddAutoMapper(config => {
                config.AddMaps(typeof(CDC.WebNotes.Api.Mapping.ApiProfile),
                               typeof(CDC.WebNotes.Application.Mapping.ApplicationProfile));
                config.AddCollectionMappers();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.AddDevelopmentConfig();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
