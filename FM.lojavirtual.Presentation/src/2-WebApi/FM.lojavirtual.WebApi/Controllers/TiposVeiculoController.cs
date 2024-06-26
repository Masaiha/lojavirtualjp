﻿using FM.lojavirtual.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/tipos-veiculo")]
    public class TiposVeiculoController : ControllerBase
    {
        private readonly ITiposVeiculoAppService _appService;

        public TiposVeiculoController(ITiposVeiculoAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("listar-tipos-veiculo")]
        public async Task<IActionResult> Listar()
        {

            try
            {
                var tipos = await _appService.Listar();

                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
