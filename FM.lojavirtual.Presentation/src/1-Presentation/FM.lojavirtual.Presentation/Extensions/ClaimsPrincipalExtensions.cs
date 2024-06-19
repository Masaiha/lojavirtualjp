using FM.lojavirtual.Application.ViewModels;
using System.Security.Claims;
using System.Text.Json;

namespace FM.lojavirtual.Presentation.Extensions
{

    public static class ClaimExtensions
    {
        public static void SetClaim(this ClaimsIdentity claimsIdentity, Claim claim)
        {
            if (claimsIdentity == null)
                throw new ArgumentException(nameof(claimsIdentity));
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static ClaimsPrincipal Set(this ClaimsPrincipal principal, Claim claim)
        {
            ValidaPrincipalIsNull(principal);

            principal.Identities.FirstOrDefault().AddClaim(claim);

            return principal;
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst("NomeUsuario");
            return claim?.Value;
        }

        public static UsuarioViewModel GetUser(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = JsonSerializer.Deserialize<UsuarioViewModel>(principal.FindFirst("UserInfo").Value);
            return claim;
        }

        public static string GetUserLogin(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst("login");
            return claim?.Value;
        }

        public static string GetUserURLFoto(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst("URLFoto");
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst("Email");
            return claim?.Value;
        }

        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst("Token");
            return claim?.Value;
        }

        public static string GetUserClaimByKey(this ClaimsPrincipal principal, string chave)
        {
            ValidaPrincipalIsNull(principal);

            var claim = principal.FindFirst(chave);
            return claim?.Value;
        }

        private static void ValidaPrincipalIsNull(ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));
        }
    }
}
