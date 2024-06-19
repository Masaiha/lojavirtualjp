using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Presentation.Extensions;
using FM.lojavirtual.Presentation.Interfaces;
using System.Security.Claims;
using System.Text.Json;

namespace FM.lojavirtual.Presentation.Helpers
{

    public static class UsuarioSession
    {
        public static string GetToken(this ISession session)
        {
            return JsonSerializer.Deserialize<string>(session.GetString("Token"));
        }

        public static UsuarioViewModel GetUsuario(this ISession session)
        {
            var usuario = new UsuarioViewModel();
            var idGrupoUsuario = 0;

            usuario.Login = session.GetString("Login");


            //int.TryParse(session.GetString("IdGrupoUsuario"), out idGrupoUsuario);
            //usuario.IdGrupoUsuario = idGrupoUsuario;

            //usuario.CodigoCentroCusto = session.GetString("CodigoCentroCusto");
            //usuario.NomeUsuario = session.GetString("NomeUsuario");
            //usuario.Telefone = session.GetString("Telefone");


            //usuario.DataSenha = DateTime.Parse(session.GetString("DataSenha"));
            //usuario.DataAcesso = DateTime.Parse(session.GetString("DataAcesso"));

            //int numeroAcesso;
            //int.TryParse(session.GetString("NumeroAcesso"), out numeroAcesso);
            //usuario.NumeroAcesso = numeroAcesso;

            //int numeroErro;
            //int.TryParse(session.GetString("NumeroErro"), out numeroErro);
            //usuario.NumeroErro = numeroErro;

            //usuario.Email = session.GetString("Email");
            //usuario.SiglaDominio = session.GetString("SiglaDominio");
            //usuario.CodigoEmpresa = session.GetString("CodigoEmpresa");
            //usuario.CodigoDiretoria = session.GetString("CodigoDiretoria");

            //int numeroIdioma;
            //int.TryParse(session.GetString("NumeroIdioma"), out numeroIdioma);
            //usuario.NumeroIdioma = numeroIdioma;

            //usuario.NomeSolicitante = session.GetString("NomeSolicitante");
            //usuario.DescricaoArea = session.GetString("DescricaoArea");
            //usuario.CodigoLinha = session.GetString("CodigoLinha");
            //usuario.TipoUsuario = session.GetString("TipoUsuario");
            //usuario.SiglaResponsavelGeral = session.GetString("SiglaResponsavelGeral");
            //usuario.CodigoLoginManutencao = session.GetString("CodigoLoginManutencao");

            //usuario.DataManutencao = DateTime.Parse(session.GetString("DataManutencao"));

            //int statusUsuario;
            //int.TryParse(session.GetString("StatusUsuario"), out statusUsuario);
            //usuario.StatusUsuario = statusUsuario;

            //usuario.NomeContato = session.GetString("NomeContato");
            //usuario.CodigoEmpresaConcessionario = session.GetString("CodigoEmpresaConcessionario");
            //usuario.SiglaFeedbackAutomatico = session.GetString("SiglaFeedbackAutomatico");
            //usuario.Ambiente = session.GetString("Ambiente");
            //usuario.URLFoto = session.GetString("URLFoto");
            //usuario.Versao = session.GetString("Versao");

            return usuario;
        }
    }

    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void Set(Claim claim)
        {
            if (!EstaAutenticado())
                return;

            var claims = _accessor.HttpContext.User.Set(claim);
            _accessor.HttpContext.User.Set(new Claim("", ""));

            var newClaim = new ClaimsPrincipal(claims);

            _accessor.HttpContext.User = newClaim;
            _accessor.HttpContext.User.Identities.FirstOrDefault().SetClaim(new Claim("", ""));
        }

        public string GetUserClaimByKey(string chave)
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserClaimByKey(chave) : "";
        }

        public string ObterUsuarioNome()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserName() : "";
        }

        public UsuarioViewModel ObterUsuario()
        {
            if (EstaAutenticado())
            {
                var user = _accessor.HttpContext.User.GetUser();

                //var idioma = _accessor.HttpContext.Session.GetString("NumeroIdioma");
                //user.NumeroIdioma = string.IsNullOrEmpty(idioma) ? user.NumeroIdioma : int.TryParse(JsonSerializer.Deserialize<string>(idioma), out int i) ? i : 5;

                return user;
            }
            return null;
        }

        public string ObterUsuarioLogin()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserLogin() : "";
        }

        public string ObterUsuarioEmail()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public string ObterUsuarioToken()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserToken() : "";
        }

        public string GetUserURLFoto()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserURLFoto() : "";
        }

        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool PossuiRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _accessor.HttpContext;
        }
    }


}
