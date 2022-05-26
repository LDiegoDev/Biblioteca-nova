using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<EnderecoModel>
    {
        Task<EnderecoModel> ObterEnderecoPorEditora(Guid EditoraId);
    }
}
