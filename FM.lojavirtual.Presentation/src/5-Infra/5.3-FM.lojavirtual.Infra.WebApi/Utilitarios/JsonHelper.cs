using Newtonsoft.Json;
using System.Text;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Utilitarios
{
    public static class JsonHelper
    {
        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }
    }
}
