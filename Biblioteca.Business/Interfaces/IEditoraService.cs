using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraService : IDisposable
    {
        Task<bool> Adicionar(EditoraModel Editora);
        Task<bool> Atualizar(EditoraModel Editora);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(EnderecoModel endereco);
    }
}
