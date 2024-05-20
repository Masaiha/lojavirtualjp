namespace FM.lojavirtual.Domain.Entidades
{
    public class Loja
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
