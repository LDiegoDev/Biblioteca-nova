using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IEnumerable<Livro>> ObterLivrosPorEditora(Guid EditoraId);
        Task<IEnumerable<Livro>> ObterLivrosEditoras();
        Task<Livro> ObterLivroEditora(Guid id);
    }
}
