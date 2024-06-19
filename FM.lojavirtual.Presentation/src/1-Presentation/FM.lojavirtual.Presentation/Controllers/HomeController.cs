using _5._3_FM.lojavirtual.Infra.WebApi;
using FM.lojavirtual.Application.AutoMapper;
using FM.lojavirtual.Presentation.Extensions;
using FM.lojavirtual.Presentation.Helpers;
using FM.lojavirtual.Presentation.Interfaces;
using FM.lojavirtual.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly LojaServicoWebApi _lojaWebApi;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUser _user;
        string _token;

        public HomeController(IUser user,
                              LojaServicoWebApi lojaWebApi, 
                              IHttpContextAccessor accessor)
        {
            _user = user;
            _accessor = accessor;
            _lojaWebApi = lojaWebApi;

            _token = _user.ObterUsuarioToken();
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var teste1 = await _lojaWebApi.ListarNomeLojas(cancellationToken);

            //var teste2 = _token;
            //var teste = ObterClaims();
            //var user = _accessor.HttpContext.User.GetUser();

            return View();
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext?.User.Claims ?? throw new Exception("Ops, Ocorreu um erro ao salvar dados na Claim.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }   
    }
}