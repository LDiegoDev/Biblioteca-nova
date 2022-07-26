using Biblioteca.API.Extensions;

namespace Biblioteca.API.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "08980773700a43a9af9dd3bf500722d4";
                o.LogId = new Guid("6cda7b62-6b1c-41eb-a60d-880831682b6d");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "08980773700a43a9af9dd3bf500722d4";
                    options.LogId = new Guid("6cda7b62-6b1c-41eb-a60d-880831682b6d");
                    options.HeartbeatId = "API Biblioteca";

                })
                .AddCheck("Livros", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecksUI()
                .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
