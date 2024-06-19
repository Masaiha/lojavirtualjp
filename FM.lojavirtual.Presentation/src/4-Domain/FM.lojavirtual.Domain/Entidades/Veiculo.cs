using System.Globalization;

namespace FM.lojavirtual.Domain.Entidades
{
    public class Veiculo
    {
        public Veiculo()
        {

            if(VeiculoImagem == null) VeiculoImagem = new();    
            if(TiposVeiculo == null) TiposVeiculo = new();    
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoFabricacao { get; set; }
        public int Modelo { get; set; }
        public int Kilometragem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCriacao { get; set; }


        public VeiculoImagem VeiculoImagem { get; set; }
        public TiposVeiculo TiposVeiculo { get; set; }

        public string ObterValorVeiculoModeloBancoDados()
        {
            return Valor.ToString("N", CultureInfo.CreateSpecificCulture("en-US")).Replace(",", "");
        }
    }
}
