using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoEditora(Guid EditoraId);
    }
}
