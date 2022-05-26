using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository
{
    public class LivroRepository : Repository<LivroModel>, ILivroRepository
    {
        public LivroRepository(DbContextApp context) : base(context) { }

        public async Task<LivroModel> ObterLivroEditora(Guid id)
        {
            return await Db.Livros.AsNoTracking().Include(f => f.Editora)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<LivroModel>> ObterLivrosEditoras()
        {
            return await Db.Livros.AsNoTracking().Include(f => f.Editora)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<LivroModel>> ObterLivrosPorEditora(Guid editoraId)
        {
            return await Buscar(p => p.EditoraId == editoraId);
        }
    }
}
