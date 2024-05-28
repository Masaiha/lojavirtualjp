using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using _5._3_FM.lojavirtual.Infra.WebApi.Utilitarios;
using FM.lojavirtual.Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace FM.lojavirtual.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILoginWebApi _loginWebApi;

        public LoginController(ILoginWebApi loginWebApi, IHttpContextAccessor accessor)
        {
            _loginWebApi = loginWebApi;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar(UsuarioViewModel usuario, CancellationToken cancellationToken)
        {
            var usuarioLogado = await _loginWebApi.Logar(usuario, cancellationToken);

            await SetCookie(usuario, PersistToken._token.Value, "1");

            return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
        }

        private async Task SetCookie(UsuarioViewModel user, string token, string lang)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Token", token));
            claims.Add(new Claim("UserInfo", JsonSerializer.Serialize(user)));
            claims.Add(new Claim("NumeroIdioma", lang));

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddHours(2),
                    IsPersistent = true
                }    
            );
        }
    }
}
