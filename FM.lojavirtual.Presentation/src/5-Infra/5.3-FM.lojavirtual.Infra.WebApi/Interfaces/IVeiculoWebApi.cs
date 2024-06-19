using FM.lojavirtual.Application.ViewModels;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface IVeiculoWebApi
    {
        Task<IEnumerable<VeiculoViewModel>> Listar(string token, CancellationToken cancellationToken);
        Task<IEnumerable<VeiculoViewModel>> Listar(int idTipoVeiculo, string token, CancellationToken cancellationToken);
        Task Adicionar(VeiculoViewModel veiculoViewModel, string token, CancellationToken cancellationToken);
    } 
}
