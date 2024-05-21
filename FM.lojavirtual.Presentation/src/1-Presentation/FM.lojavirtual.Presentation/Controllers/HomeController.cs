using _5._3_FM.lojavirtual.Infra.WebApi;
using FM.lojavirtual.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly LojaServicoWebApi _lojaWebApi;

        public HomeController(ILogger<HomeController> logger, LojaServicoWebApi lojaWebApi)
        {
            _logger = logger;
            _lojaWebApi = lojaWebApi;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var teste1 = await _lojaWebApi.ListarNomeLojas(cancellationToken);

            return View();
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