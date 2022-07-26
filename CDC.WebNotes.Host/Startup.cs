using AutoMapper;
using CDC.WebNotes.Api.Mapping;
using CDC.WebNotes.Application.Mapping;
using CDC.WebNotes.Data;
using CDC.WebNotes.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<ApplicationDbContext>(
                op => op.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddProblemDetailsConfig();

            services.AddServices();

            services.AddRepositories();

            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddSwaggerGen();

            services.AddAutoMapper(config =>
                config.AddProfiles(new Profile[]
                {
                    new ApplicationProfile(),
                    new ApiProfile()
                }));
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
