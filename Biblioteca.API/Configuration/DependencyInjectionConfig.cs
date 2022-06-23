using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Notificacoes;
using Biblioteca.Business.Services;
using Biblioteca.Data.Context;
using Biblioteca.Data.Repository;

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

            return services;
        }
    }
}
