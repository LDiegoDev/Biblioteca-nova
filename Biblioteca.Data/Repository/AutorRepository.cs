using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(DbContextApp context) : base(context)
        {
        }

        public async Task<Autor> ObterAutorLivros(Guid id)
        {
            return await Db.Autores.AsNoTracking()
                .Include(x => x.Livros)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
