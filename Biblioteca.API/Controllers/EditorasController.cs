using AutoMapper;
using Biblioteca.API.ViewModels;
using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/editoras")]
    public class EditorasController : MainController
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEditoraService _editoraService;
        private readonly IMapper _mapper;


        public EditorasController(IEditoraRepository editoraRepository, IMapper mapper,
                                  IEditoraService editoraService, IEnderecoRepository enderecoRepository,
                                  INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _editoraService = editoraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditoraViewModel>>> ObterTodos()
        {
            var editoras = _mapper.Map<IEnumerable<EditoraViewModel>>(await _editoraRepository.ObterTodos());

            return CustomResponse(editoras);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> ObterPorId(Guid id)
        {
            var editora = await ObterEditoraLivrosEndereco(id);

            if (editora is null) return NotFound();

            return CustomResponse(editora);
        }

        [HttpPost]
        public async Task<ActionResult<EditoraViewModel>> Adicionar(EditoraViewModel editoraViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _editoraService.Adicionar(_mapper.Map<Editora>(editoraViewModel));

            return CustomResponse(editoraViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> Atualizar(Guid id, EditoraViewModel editoraViewModel)
        {
            if (id != editoraViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _editoraService.Atualizar(_mapper.Map<Editora>(editoraViewModel));

            if (!result) return BadRequest();

            return CustomResponse(editoraViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> Excluir(Guid id)
        {
            var editora = await ObterEditoraEndereco(id);

            if (editora is null) return NotFound();

            await _editoraService.Remover(id);

            return CustomResponse();
        }

        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }

        [HttpPut("atualizar-endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _editoraService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        private async Task<EditoraViewModel> ObterEditoraLivrosEndereco(Guid id)
        {
            return _mapper.Map<EditoraViewModel>(await _editoraRepository.ObterEditoraLivrosEndereco(id));
        }

        private async Task<EditoraViewModel> ObterEditoraEndereco(Guid id)
        {
            return _mapper.Map<EditoraViewModel>(await _editoraRepository.ObterEditoraEndereco(id));
        }

    }
}
