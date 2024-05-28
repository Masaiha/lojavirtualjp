namespace _5._3_FM.lojavirtual.Infra.WebApi.Utilitarios
{
    public class TokenDto
    {
        public string Value { get; set; }

        public TokenDto() { }

        public TokenDto(string token)
        {
            Value = token;
        }
    }

    public class PersistToken
    {
        public static TokenDto _token { get; set; }
    }
}
