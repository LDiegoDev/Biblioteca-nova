using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Business.Models.Validations;

namespace Biblioteca.Business.Services
{
    public class EditoraService : BaseService, IEditoraService
    {
        private readonly IEditoraRepository _EditoraRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EditoraService(IEditoraRepository EditoraRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _EditoraRepository = EditoraRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(EditoraModel Editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), Editora)
                || !ExecutarValidacao(new EnderecoValidation(), Editora.Endereco)) return false;

            if (_EditoraRepository.Buscar(f => f.Documento == Editora.Documento).Result.Any())
            {
                Notificar("Já existe um Editora com este documento informado.");
                return false;
            }

            await _EditoraRepository.Adicionar(Editora);
            return true;
        }

        public async Task<bool> Atualizar(EditoraModel Editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), Editora)) return false;

            if (_EditoraRepository.Buscar(f => f.Documento == Editora.Documento && f.Id != Editora.Id).Result.Any())
            {
                Notificar("Já existe um Editora com este documento informado.");
                return false;
            }

            await _EditoraRepository.Atualizar(Editora);
            return true;
        }

        public async Task AtualizarEndereco(EnderecoModel endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_EditoraRepository.ObterEditoraLivrosEndereco(id).Result.Livros.Any())
            {
                Notificar("O Editora possui Livros cadastrados!");
                return false;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorEditora(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _EditoraRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _EditoraRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
