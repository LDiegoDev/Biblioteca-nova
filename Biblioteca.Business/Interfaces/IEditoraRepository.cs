using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraRepository : IRepository<EditoraModel>
    {
        Task<EditoraModel> ObterEditoraEndereco(Guid id);
        Task<EditoraModel> ObterEditoraLivrosEndereco(Guid id);
    }
}
