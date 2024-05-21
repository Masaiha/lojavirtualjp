using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using _5._3_FM.lojavirtual.Infra.WebApi.Utilitarios;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Servicos
{
    public class HttpGenericCall : IHttpGenericCall
    {
        private readonly AppSettingsUi _appSettingsUi;
        private readonly IBaseHttpClient _baseHttpClient;

        public HttpGenericCall(IBaseHttpClient baseHttpClient, IOptions<AppSettingsUi> appSettingsUi)
        {
            _baseHttpClient = baseHttpClient;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<TResult> CallMethod<TResult>(HttpMethod typeMethod, string methodToCall, CancellationToken cancellationToken,
            Dictionary<string, object> paramsToQuery = null, object paramsToBody = null, string jwtToken = null, string jsonParam = null, string baseUrl = null)
        {
            string url;

            if (baseUrl == null)
            {
                url = _baseHttpClient.GetBaseUrl() + methodToCall;
            }
            else
            {
                url = baseUrl + methodToCall;
            }

            if (paramsToQuery != null)
                url = HttpHelper.UriWithParameters(url, paramsToQuery);

            using (HttpRequestMessage request = new HttpRequestMessage(typeMethod, url))
            {
                if (paramsToBody != null)
                    request.Content = HttpHelper.CreateHttpContent(paramsToBody);

                if (jsonParam != null)
                    request.Content = new StringContent(jsonParam, Encoding.UTF8, "application/json");

                //bool.TryParse(_appSettingsUi.GatewayEnabled, out bool GatewayEnabled);

                //if (GatewayEnabled)
                //    request.Headers.Add("x-api-key", _appSettingsUi.GatewayKey);

                if (jwtToken != null)
                    request.Headers.Add("Authorization", $"Bearer {jwtToken}");

                using (HttpResponseMessage response = await _baseHttpClient.HttpClient()
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false))
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //if (response.Headers.Contains("access-token") && response.Headers.GetValues("access-token") != null)
                    //    PersistToken._token = new Application.Dto.TokenDto(response.Headers.GetValues("access-token").FirstOrDefault());

                    _baseHttpClient.ValidarRequisicaoHttp(response, result, url);

                    if (!result.Contains("{") && !result.Contains("}") && result != "[]")
                        return JsonConvert.DeserializeObject<TResult>(JsonConvert.SerializeObject(result));

                    return JsonConvert.DeserializeObject<TResult>(result);
                }
            }
        }

        public async Task CallMethod(HttpMethod typeMethod, string methodToCall, CancellationToken cancellationToken,
                                     Dictionary<string, object> paramsToQuery = null, object paramsToBody = null, string jwtToken = null)
        {
            string url = _baseHttpClient.GetBaseUrl() + methodToCall;

            if (paramsToQuery != null)
                url = HttpHelper.UriWithParameters(url, paramsToQuery);

            using (HttpRequestMessage request = new HttpRequestMessage(typeMethod, url))
            {
                if (paramsToBody != null)
                    request.Content = HttpHelper.CreateHttpContent(paramsToBody);

                //bool.TryParse(_appSettingsUi.GatewayEnabled, out bool GatewayEnabled);

                //if (GatewayEnabled)
                //    request.Headers.Add("x-api-key", _appSettingsUi.GatewayKey);

                if (jwtToken != null)
                    request.Headers.Add("Authorization", $"Bearer {jwtToken}");

                using (HttpResponseMessage response = await _baseHttpClient.HttpClient()
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false))
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    _baseHttpClient.ValidarRequisicaoHttp(response, result, url);
                }
            }
        }
    }
}
