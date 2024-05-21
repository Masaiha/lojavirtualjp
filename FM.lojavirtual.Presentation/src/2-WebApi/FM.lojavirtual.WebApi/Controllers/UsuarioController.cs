using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FM.lojavirtual.WebApi.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
		private readonly IUsuarioAppService _appService;

        public UsuarioController(IUsuarioAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
			try
			{
                IEnumerable<UsuarioViewModel> usuarios = await _appService.Listar();

                if (usuarios == null)
                    return NoContent();

                return Ok(usuarios);
			}
			catch (Exception ex)
			{
                return BadRequest(ex.Message);
			}
        }
    }
}
