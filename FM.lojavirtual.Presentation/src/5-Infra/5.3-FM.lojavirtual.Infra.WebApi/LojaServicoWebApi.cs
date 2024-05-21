using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;

namespace _5._3_FM.lojavirtual.Infra.WebApi
{
    public class LojaServicoWebApi
    {
        private readonly IHttpGenericCall _httpGenericCall;
        private readonly AppSettingsUi _appSettingsUi;

        public LojaServicoWebApi(IHttpGenericCall httpGenericCall, IOptions<AppSettingsUi> appSettingsUi)
        {
            _httpGenericCall = httpGenericCall;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<IEnumerable<Loja>> ListarNomeLojas(CancellationToken cancellationToken)
        {


            return await _httpGenericCall.CallMethod<IEnumerable<Loja>>(HttpMethod.Get, 
                                                            _appSettingsUi.Loja, 
                                                            cancellationToken, null, null, null);
        }

    }
}
