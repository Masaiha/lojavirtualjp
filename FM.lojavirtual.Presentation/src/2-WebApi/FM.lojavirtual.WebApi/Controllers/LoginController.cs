using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using FM.lojavirtual.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace FM.lojavirtual.WebApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _appService;
        private readonly AppSettingsApi _appSettingsApi;

        public LoginController(ILoginAppService appService, IOptions<AppSettingsApi> appSettingsApi)
        {
            _appService = appService;
            _appSettingsApi = appSettingsApi.Value;
        }

        [HttpGet("autenticar")]
        public async Task<IActionResult> Autenticar(string login, string senha)
        {
            try
            {
                var usuario = await _appService.Autenticar(login, senha);

                if (usuario != null)
                {
                    Response.Headers.Add("access-token", CreateToken(usuario));

                    return Ok(usuario);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private string CreateToken(UsuarioViewModel usuario)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;

            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddHours(double.Parse(_appSettingsApi.TokenExpirationTime));

            var tokenHandler = new JwtSecurityTokenHandler();
            //var ip = _httpContext.HttpContext.Connection.RemoteIpAddress;

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Login),
                new Claim("nome", usuario.Nome)
                //new Claim("idioma", usuario.NumeroIdioma.ToString()),
                //new Claim("origem", origem.ToString()),
                //new Claim("versao", usuario.Versao ?? "0")
            });

            string secrectKey = _appSettingsApi.SecretKeyJWT;
            string keyURL = _appSettingsApi.TokenValidationBaseUrl;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secrectKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = tokenHandler.CreateJwtSecurityToken(
                    issuer: keyURL,
                    audience: keyURL,
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expires,
                    signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
