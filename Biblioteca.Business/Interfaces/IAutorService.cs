using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IAutorService : IDisposable
    {
        Task<bool> Adicionar(Autor autor);
        Task<bool> Atualizar(Autor autor);
        Task<bool> Remover(Guid id);
    }
}
