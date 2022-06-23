using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(DbContextApp context) : base(context) { }

        public async Task<Livro> ObterLivroEditora(Guid id)
        {
            return await Db.Livros.AsNoTracking().Include(f => f.Editora)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Livro>> ObterLivrosEditoras()
        {
            return await Db.Livros.AsNoTracking()
                    .Include(f => f.Editora)
                    .Include(f => f.Autor)
                        .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Livro>> ObterLivrosPorEditora(Guid editoraId)
        {
            return await Buscar(p => p.EditoraId == editoraId);
        }
    }
}
