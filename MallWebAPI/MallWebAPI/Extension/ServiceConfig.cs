using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MallWebAPI.Extension
{
    public static class ServiceConfig
    {
        public static void AddExtensionServices(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
        }

        public static void AddConfigure(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API");
            });
        }
    }
}
