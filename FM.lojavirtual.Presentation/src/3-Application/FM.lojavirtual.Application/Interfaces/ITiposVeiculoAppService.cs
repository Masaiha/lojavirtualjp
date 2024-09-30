using FM.lojavirtual.Application.ViewModels;

namespace FM.lojavirtual.Application.Interfaces
{
    public interface ITiposVeiculoAppService
    {
        Task<IEnumerable<TiposVeiculoViewModel>> Listar();
        Task<TiposVeiculoViewModel> ObterPorID(int id);
    }
}
