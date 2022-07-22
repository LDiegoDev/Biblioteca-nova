using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Notificacoes;
using Biblioteca.Business.Services;
using Biblioteca.Data.Context;
using Biblioteca.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Biblioteca.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContextApp>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<IAutorService, AutorService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            return services;
        }
    }
}
