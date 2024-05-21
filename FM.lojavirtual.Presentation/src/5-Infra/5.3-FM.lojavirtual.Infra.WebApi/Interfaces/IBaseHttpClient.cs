namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface IBaseHttpClient
    {
        string GetSiglaIdioma();
        string GetBaseUrl();
        HttpClient HttpClient();
        void ValidarRequisicaoHttp(HttpResponseMessage httpResponseMessage, string result, string url);
    }
}
