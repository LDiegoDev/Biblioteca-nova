namespace Biblioteca.Business.Models
{
    public class EditoraModel : EntityModel
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        //    public TipoEditora TipoEditora { get; set; }
        //   public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        //   public IEnumerable<Livro> Livros { get; set; }
    }
}
