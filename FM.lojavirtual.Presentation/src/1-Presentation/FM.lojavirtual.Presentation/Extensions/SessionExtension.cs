using Newtonsoft.Json;

namespace FM.lojavirtual.Presentation.Extensions
{
    public static class SessionExtension
    {
        public static void SetSession<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static void SetSession(this ISession session, string key, string value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static void SetSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }

    }
}
