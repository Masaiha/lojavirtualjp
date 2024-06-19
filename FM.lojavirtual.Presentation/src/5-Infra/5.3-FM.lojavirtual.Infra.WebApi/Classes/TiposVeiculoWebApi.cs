using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Classes
{
    public class TiposVeiculoWebApi : ITiposVeiculoWebApi
    {
        private readonly IHttpGenericCall _genericCall;
        private readonly AppSettingsUi _appSettingsUi;

        public TiposVeiculoWebApi(IHttpGenericCall genericCall, IOptions<AppSettingsUi> appSettingsUi)
        {
            _genericCall = genericCall;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<IEnumerable<TiposVeiculoViewModel>> Listar(string token, CancellationToken cancellationToken)
        {
            return await _genericCall.CallMethod<IEnumerable<TiposVeiculoViewModel>>(HttpMethod.Get, _appSettingsUi.TiposVeiculoWebApi,
                                                                   cancellationToken,null, null, token);
        }

    }
}
