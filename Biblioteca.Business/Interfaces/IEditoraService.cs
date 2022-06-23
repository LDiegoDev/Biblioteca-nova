using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraService : IDisposable
    {
        Task<bool> Adicionar(Editora Editora);
        Task<bool> Atualizar(Editora Editora);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
