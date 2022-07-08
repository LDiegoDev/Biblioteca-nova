using System.Text.Json.Serialization;

namespace Biblioteca.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseWebApiConfig(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseCors("Development");

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }

}
