using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Classes
{
    public class LoginWebApi : ILoginWebApi
    {
        private readonly IHttpGenericCall _genericCall;
        private readonly AppSettingsUi _appSettingsUi;

        public LoginWebApi(IHttpGenericCall genericCall, IOptions<AppSettingsUi> appSettingsUi)
        {
            _genericCall = genericCall;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<UsuarioViewModel> Logar(UsuarioViewModel usuario, CancellationToken cancellationToken)
        {
            return await _genericCall.CallMethod<UsuarioViewModel>(HttpMethod.Get, _appSettingsUi.Autenticar,
                                                                   cancellationToken, 
                                                                   new Dictionary<string, object>()
                                                                   {
                                                                       {"login", usuario.Login },
                                                                       {"senha", usuario.Senha }
                                                                   }, null, null);
        }
    }
}
