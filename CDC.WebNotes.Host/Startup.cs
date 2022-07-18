using AutoMapper;
using CDC.WebNotes.Api.Mapping;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Application.Mapping;
using CDC.WebNotes.Application.Services;
using CDC.WebNotes.Data;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Data.Repositories;
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

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteService, NoteService>();

            services.AddControllers();

            services.AddAutoMapper(config =>
                config.AddProfiles(new Profile[]
                {
                    new AppProfile(),
                    new ApiProfile()
                }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
