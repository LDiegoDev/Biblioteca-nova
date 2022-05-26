using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface ILivroRepository : IRepository<LivroModel>
    {
        Task<IEnumerable<LivroModel>> ObterLivrosPorEditora(Guid EditoraId);
        Task<IEnumerable<LivroModel>> ObterLivrosEditoras();
        Task<LivroModel> ObterLivroEditora(Guid id);
    }
}
