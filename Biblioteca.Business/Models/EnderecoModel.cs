﻿namespace Biblioteca.Business.Models
{
    public class EnderecoModel : EntityModel
    {
        public Guid EditoraId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        /* EF Relation */
        public EditoraModel Editora { get; private set; }
    }
}
