using Biblioteca.Business.Enums;

namespace Biblioteca.Business.Models
{
    public class EditoraModel : EntityModel
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public TipoEditora TipoEditora { get; private set; }
        public EnderecoModel Endereco { get; private set; }
        public bool Ativo { get; private set; }

        /* EF Relations */
        public IEnumerable<LivroModel> Livros { get; private set; }
    }
}
