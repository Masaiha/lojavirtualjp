using System.Net.Http.Headers;
using System.Web;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Utilitarios
{

    public static class HttpHelper
    {
        public static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                JsonHelper.SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public static string UriWithParameters(string uri, Dictionary<string, object> arParams)
        {
            try
            {
                string queryStringParameters = string.Join("&", arParams.Select(item => $"{item.Key}={HttpUtility.UrlEncode(item.Value == null ? "" : item.Value.ToString())}"));
                return $"{uri}?{queryStringParameters}";
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"UriWithParameters: {ex.Message}");
            }
        }
    }
}
