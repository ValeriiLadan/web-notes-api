using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;

namespace CDC.WebNotes.Host.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddDevelopmentConfig(this IApplicationBuilder app)
        {
            app.UseProblemDetails();

            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
