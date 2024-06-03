using FM.lojavirtual.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FM.lojavirtual.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/veiculo")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoAppService _appService;

        public VeiculoController(IVeiculoAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var veiculos = await _appService.Listar();

            return Ok(veiculos);
        }

    }
}
