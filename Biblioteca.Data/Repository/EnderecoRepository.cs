using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository
{
    public class EnderecoRepository : Repository<EnderecoModel>, IEnderecoRepository
    {
        public EnderecoRepository(DbContextApp context) : base(context) { }

        public async Task<EnderecoModel> ObterEnderecoPorEditora(Guid editoraId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.EditoraId == editoraId);
        }
    }
}
