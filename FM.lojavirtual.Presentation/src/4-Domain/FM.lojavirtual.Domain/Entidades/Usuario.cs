namespace FM.lojavirtual.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
