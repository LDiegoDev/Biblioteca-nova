using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface ILivroService : IDisposable
    {
        Task Adicionar(Livro produto);
        Task Atualizar(Livro produto);
        Task Remover(Guid id);
    }
}
