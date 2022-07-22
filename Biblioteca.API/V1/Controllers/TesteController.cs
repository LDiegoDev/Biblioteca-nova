using Biblioteca.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        public TesteController(INotificador notificador) : base(notificador)
        {
        }

        [HttpGet]
        public string Valor()
        {
            return "Sou a V1";
        }
    }
}
