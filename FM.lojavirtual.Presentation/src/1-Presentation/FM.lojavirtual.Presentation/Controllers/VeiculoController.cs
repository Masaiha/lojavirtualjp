using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Presentation.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.Presentation.Controllers
{
    [Route("[controller]/[action]")]
    public class VeiculoController : Controller
    {
        private readonly IUser _user;
        private string _token;
        private readonly IVeiculoWebApi _webApi;
        private readonly ITiposVeiculoWebApi _tiposVeiculoWebApi;
        private readonly INotyfService _notyfService;

        public VeiculoController(IVeiculoWebApi webApi, IUser user, ITiposVeiculoWebApi tiposVeiculoWebApi, INotyfService notyfService)
        {
            _webApi = webApi;
            _user = user;
            _token = _user.ObterUsuarioToken();
            _tiposVeiculoWebApi = tiposVeiculoWebApi;
            _notyfService = notyfService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarVeiculos(CancellationToken cancellationToken)
        {
            var veiculos = await _webApi.Listar(_token, cancellationToken);

            var quantidadeVeiculos = veiculos?.Count();

            _notyfService.Success($"{quantidadeVeiculos} veículos encontrados!");

            return PartialView("Index", veiculos);
        }

        [HttpGet]
        public async Task<IActionResult> Filtrar(int idTipoVeiculo, CancellationToken cancellationToken)
        {
            var veiculos = await _webApi.Listar(idTipoVeiculo, _token, cancellationToken);

            var quantidadeVeiculos = veiculos?.Count();

            _notyfService.Success($"{quantidadeVeiculos} veículos encontrados!");

            return PartialView("Index", veiculos);
        }

        [HttpGet]
        public IActionResult AdicionarGet()
        {
            return PartialView("_Adicionar");
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarPost(VeiculoViewModel veiculoViewModel, CancellationToken cancellationToken)
        {
            veiculoViewModel.TiposVeiculoViewModel.Nome = "key";
            veiculoViewModel.TiposVeiculoViewModel.DataCriacao =  DateTime.UtcNow;

            veiculoViewModel.VeiculoImagemViewModel.Nome = "sdfsdfsdfsd";
            veiculoViewModel.VeiculoImagemViewModel.DataCriacao = DateTime.UtcNow;

            veiculoViewModel.TiposVeiculoViewModel.Id = 1;
            veiculoViewModel.TiposVeiculoViewModel.Nome = "Wagon R";

            veiculoViewModel.VeiculoImagemViewModel.Id = 2;
            veiculoViewModel.VeiculoImagemViewModel.Nome = "fiat1.jpg";
            veiculoViewModel.VeiculoImagemViewModel.Tipo = "jpg";
            veiculoViewModel.VeiculoImagemViewModel.DataCriacao = DateTime.UtcNow;



            await _webApi.Adicionar(veiculoViewModel, _token, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarTiposVeiculo(CancellationToken cancellationToken)
        {
            var tiposVeiculo = await _tiposVeiculoWebApi.Listar(_token, cancellationToken);

            return PartialView("_TiposVeiculo", tiposVeiculo);
        }
    }
}
