namespace FM.lojavirtual.Application.ViewModels
{
    public class VeiculoViewModel
    {
        public VeiculoViewModel()
        {
            if (VeiculoImagemViewModel == null) VeiculoImagemViewModel = new();   
            if (TiposVeiculoViewModel == null) TiposVeiculoViewModel = new();   
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoFabricacao { get; set; }
        public int Modelo { get; set; }
        public int Kilometragem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public VeiculoImagemViewModel VeiculoImagemViewModel { get; set; }
        public TiposVeiculoViewModel TiposVeiculoViewModel { get; set; }
    }
}
