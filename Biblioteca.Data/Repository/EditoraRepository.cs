using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository
{
    public class EditoraRepository : Repository<EditoraModel>, IEditoraRepository
    {
        public EditoraRepository(DbContextApp context) : base(context)
        {
        }

        public async Task<EditoraModel> ObterEditoraEndereco(Guid id)
        {
            return await Db.Editoras.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<EditoraModel> ObterEditoraLivrosEndereco(Guid id)
        {
            return await Db.Editoras.AsNoTracking()
                .Include(c => c.Livros)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
