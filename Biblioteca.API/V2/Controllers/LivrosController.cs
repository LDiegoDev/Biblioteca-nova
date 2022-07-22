using AutoMapper;
using Biblioteca.API.ViewModels;
using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/livros")]
    public class LivrosController : MainController
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivrosController(INotificador notificador,
                                ILivroRepository livroRepository,
                                ILivroService livroService,
                                IMapper mapper) : base(notificador)
        {
            _livroRepository = livroRepository;
            _livroService = livroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LivroViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<LivroViewModel>>(await _livroRepository.ObterLivrosEditoras());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LivroViewModel>> ObterPorId(Guid id)
        {
            var livroViewModel = await ObterLivro(id);

            if (livroViewModel == null) return NotFound();

            return livroViewModel;
        }

        //[MapToApiVersion("2.0")]
        //[HttpPost]
        //public async Task<ActionResult<LivroViewModel>> Adicionar(LivroViewModel modelo)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var imagemNome = Guid.NewGuid() + "_" + modelo.Imagem;
        //    if (!UploadArquivo(modelo.ImagemUpload, imagemNome))
        //    {
        //        return CustomResponse(modelo);
        //    }

        //    modelo.Imagem = imagemNome;
        //    await _livroService.Adicionar(_mapper.Map<Livro>(modelo));

        //    return CustomResponse(modelo);

        //}

        //[HttpDelete("{id:guid}")]
        //public async Task<ActionResult<LivroViewModel>> Excluir(Guid id)
        //{
        //    var livro = await ObterLivro(id);

        //    if (livro is null) return NotFound();

        //    await _livroService.Remover(id);

        //    return CustomResponse(livro);

        //}

        //private bool UploadArquivo(string arquivo, string imgNome)
        //{
        //    if (string.IsNullOrEmpty(arquivo))
        //    {
        //        NotificarErro("Forneça uma imagem para este produto!");
        //        return false;
        //    }

        //    var imageDataByteArray = Convert.FromBase64String(arquivo);

        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgNome);

        //    if (System.IO.File.Exists(filePath))
        //    {
        //        NotificarErro("Já existe um arquivo com este nome!");
        //        return false;
        //    }

        //    System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

        //    return true;
        //}
        private async Task<LivroViewModel> ObterLivro(Guid id)
        {
            return _mapper.Map<LivroViewModel>(await _livroRepository.ObterLivroEditora(id));
        }
    }
}
