using FM.lojavirtual.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FM.lojavirtual.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IVeiculoAppService _appService;

        public ValuesController(IVeiculoAppService appService)
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
