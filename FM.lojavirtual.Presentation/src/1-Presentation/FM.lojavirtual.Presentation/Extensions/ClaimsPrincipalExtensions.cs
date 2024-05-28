using FM.lojavirtual.Application.ViewModels;
using System.Security.Claims;
using System.Text.Json;

namespace FM.lojavirtual.Presentation.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static ClaimsPrincipal Set(this ClaimsPrincipal principal, Claim claim)
        {

            principal.Identities.FirstOrDefault().AddClaim(claim);

            return principal;
        }

        public static UsuarioViewModel GetUser(this ClaimsPrincipal principal)
        {
            return JsonSerializer.Deserialize<UsuarioViewModel>(principal.FindFirst("UserInfo").Value);
        }

    }
}
