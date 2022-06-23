using Biblioteca.Business.Models;

namespace Biblioteca.Business.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<Autor> ObterAutorLivros(Guid id);
    }
}
