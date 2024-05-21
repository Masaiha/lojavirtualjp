using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Servicos
{
    public class BaseHttpClient : IBaseHttpClient
    {
        protected readonly HttpClient _client;
        protected readonly AppSettingsUi _appSettingsUi;

        public BaseHttpClient(IOptions<AppSettingsUi> appSettingsUi)
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(1000);
            _appSettingsUi = appSettingsUi.Value;
        }

        private string SiglaIdioma { get { return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName; } }

        private string BaseUrl
        {
            get
            {
                return $"{_appSettingsUi.BaseApiUrl}";
            }
        }

        public HttpClient HttpClient()
        {
            return _client;
        }

        public string GetSiglaIdioma()
        {
            return SiglaIdioma;
        }

        public string GetBaseUrl()
        {
            return BaseUrl;
        }

        /// <summary>
        /// Valida requisição http
        /// </summary>
        /// <param name="httpResponseMessage">Objeto HttpResponseMessage da requisição atual</param>
        /// <param name="result">Resultado ReadAsStringAsync da requisição</param>
        /// <param name="url">Url requisitada</param>
        public void ValidarRequisicaoHttp(HttpResponseMessage httpResponseMessage, string result, string url)
        {
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new Exception($"Não foi possível acessar o web api. O endereço {url} não foi encontrado.");
            else if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Match m = Regex.Match(result, @"<title>\s*(.+?)\s*</title>");
                if (m.Success)
                {
                    throw new Exception(m.Groups[1].Value);
                }
                else
                {
                    throw new Exception(result);
                }
            }
            else if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw JsonConvert.DeserializeObject<Exception>(result);
            }
            else if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK && httpResponseMessage.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                if (result.StartsWith("{") && result.EndsWith("}"))
                {
                    throw new Exception(JsonConvert.DeserializeObject<string>(result));
                }
                else if (result.StartsWith("\"") && result.EndsWith("\""))
                {
                    throw new Exception(result.Remove(result.Length - 1).Remove(0, 1));
                }
                else
                {
                    throw new Exception(result);
                }
            }
        }
    }
}
