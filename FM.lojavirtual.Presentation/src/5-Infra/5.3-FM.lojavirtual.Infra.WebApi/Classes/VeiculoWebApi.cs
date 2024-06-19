using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Classes
{
    public class VeiculoWebApi : IVeiculoWebApi
    {
        private readonly IHttpGenericCall _genericCall;
        private readonly AppSettingsUi _appSettingsUi;

        public VeiculoWebApi(IHttpGenericCall genericCall, IOptions<AppSettingsUi> appSettingsUi)
        {
            _genericCall = genericCall;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<IEnumerable<VeiculoViewModel>> Listar(string token, CancellationToken cancellationToken)
        {
            return await _genericCall.CallMethod<IEnumerable<VeiculoViewModel>>(HttpMethod.Get, _appSettingsUi.VeiculoListar,
                                                                   cancellationToken,null, null, token);
        }

        public async Task<IEnumerable<VeiculoViewModel>> Listar(int idTipoVeiculo, string token, CancellationToken cancellationToken)
        {
            return await _genericCall.CallMethod<IEnumerable<VeiculoViewModel>>(HttpMethod.Get, _appSettingsUi.FiltarVeiculos,
                                                                   cancellationToken, new Dictionary<string, object>
                                                                   {
                                                                       {"idTipoVeiculo", idTipoVeiculo }

                                                                   }, null, token);
        }

        public async Task Adicionar(VeiculoViewModel veiculoViewModel, string token, CancellationToken cancellationToken)
        {
            await _genericCall.CallMethod(HttpMethod.Post,
                                          _appSettingsUi.VeiculoAdicionar,
                                          cancellationToken,
                                          null,
                                          veiculoViewModel,
                                          token);

            return;
        }
    }
}
