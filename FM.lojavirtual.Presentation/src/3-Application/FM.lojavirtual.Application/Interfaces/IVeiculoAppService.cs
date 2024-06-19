using FM.lojavirtual.Application.ViewModels;

namespace FM.lojavirtual.Application.Interfaces
{
    public interface IVeiculoAppService
    {
        Task<IEnumerable<VeiculoViewModel>> Listar();
        Task<IEnumerable<VeiculoViewModel>> Listar(int idTipoVeiculo);
        Task Adicionar(VeiculoViewModel veiculoViewModel);
    }
}
