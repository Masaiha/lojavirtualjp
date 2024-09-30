using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using FM.lojavirtual.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class TiposVeiculoWebController : Controller
    {
        private string _token;
        private readonly IUser _user;
        private readonly IVeiculoWebApi _webApi;
        private readonly INotyfService _notyfService;
        private readonly ITiposVeiculoWebApi _tiposVeiculoWebApi;

        public TiposVeiculoWebController(IUser user, 
                                      IVeiculoWebApi webApi,
                                      INotyfService notyfService,
                                      ITiposVeiculoWebApi tiposVeiculoWebApi)
        {
            _user = user;
            _token = _user.ObterUsuarioToken();
            _webApi = webApi;
            _notyfService = notyfService;
            _tiposVeiculoWebApi = tiposVeiculoWebApi;
        }

        [HttpGet]
        public async Task<IActionResult> Coco(CancellationToken cancellationToken)
        {
            var tipos = await _tiposVeiculoWebApi.Listar(_token, cancellationToken);

            var selectListTiposVeiculo = new List<SelectListItem>();

            if (tipos != null)
            {
                foreach (var tipo in tipos)
                {
                    selectListTiposVeiculo.Add(new SelectListItem()
                    {
                        Text = tipo.Nome,
                        Value = tipo.Id.ToString()
                    });
                }
            }

            ViewBag.TiposVeiculo = selectListTiposVeiculo;

            return PartialView("_DropDownListTiposVeiculo", ViewBag.TiposVeiculo);
        }
    }
}
