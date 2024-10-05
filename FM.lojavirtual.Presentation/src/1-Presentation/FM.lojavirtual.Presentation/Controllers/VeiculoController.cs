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

        public VeiculoController(IUser user,
                                 IVeiculoWebApi webApi,
                                 INotyfService notyfService,
                                 ITiposVeiculoWebApi tiposVeiculoWebApi)
        {
            _user = user;
            _webApi = webApi;
            _notyfService = notyfService;
            _token = _user.ObterUsuarioToken();
            _tiposVeiculoWebApi = tiposVeiculoWebApi;
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
        public IActionResult AdicionarGet(CancellationToken cancellationToken)
        {
            var tipos = _tiposVeiculoWebApi.Listar(_token, cancellationToken);

            return PartialView("_Adicionar");
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarPost(VeiculoViewModel veiculoViewModel, CancellationToken cancellationToken)
        {
            var TipoVeiculo = await ObterTipoVeiculo(veiculoViewModel.TiposVeiculoViewModel.Id, cancellationToken);

            veiculoViewModel.TiposVeiculoViewModel.Id = TipoVeiculo.Id;
            veiculoViewModel.TiposVeiculoViewModel.Nome = TipoVeiculo.Nome;

            veiculoViewModel.VeiculoImagemViewModel.Nome = "semimagem.jpeg";
            veiculoViewModel.VeiculoImagemViewModel.Tipo = "jpeg";
            veiculoViewModel.VeiculoImagemViewModel.DataCriacao = DateTime.UtcNow;

            await _webApi.Adicionar(veiculoViewModel, _token, cancellationToken);

            return Json(new { });
        }

        [HttpGet]
        public async Task<IActionResult> ListarTiposVeiculo(CancellationToken cancellationToken)
        {
            var tiposVeiculo = await _tiposVeiculoWebApi.Listar(_token, cancellationToken);

            return PartialView("_TiposVeiculo", tiposVeiculo);
        }

        public async Task<TiposVeiculoViewModel> ObterTipoVeiculo(int id, CancellationToken cancellationToken)
        {
            var tipoVeiculo = await _tiposVeiculoWebApi.ObterPorId(id, _token, cancellationToken);

            return tipoVeiculo;
            
        }

        [HttpGet]
        public IActionResult AdicionarImagemVeiculo()
        {
            return PartialView("_AdicionarImagemVeiculo");
        }
    }
}
