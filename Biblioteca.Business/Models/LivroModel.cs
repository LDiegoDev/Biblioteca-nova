namespace Biblioteca.Business.Models
{
    public class LivroModel : EntityModel
    {
        public Guid EditoraId { get; private set; }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

        /* EF Relations */
        public EditoraModel Editora { get; private set; }
    }
}
