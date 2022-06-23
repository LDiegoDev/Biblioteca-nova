using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> ObterEditoraEndereco(Guid id);
        Task<Editora> ObterEditoraLivrosEndereco(Guid id);
    }
}
