using System.Globalization;

namespace FM.lojavirtual.Domain.Entidades
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoFabricacao { get; set; }
        public int Modelo { get; set; }
        public int Kilometragem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }


        public string ObterValorVeiculoModeloBancoDados()
        {
            return Valor.ToString("N", CultureInfo.CreateSpecificCulture("en-US")).Replace(",", "");
        }
    }
}
