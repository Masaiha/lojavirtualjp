using FM.lojavirtual.Application.ViewModels;
using System.Security.Claims;

namespace FM.lojavirtual.Presentation.Interfaces
{
    public interface IUser
    {
        string ObterUsuarioEmail();
        string ObterUsuarioToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
        //string ObterUsuarioTokenWhoisWho();
        string ObterUsuarioNome();
        string ObterUsuarioLogin();
        string GetUserClaimByKey(string chave);
        string GetUserURLFoto();
        UsuarioViewModel ObterUsuario();
        void Set(Claim claim);
    }
}
