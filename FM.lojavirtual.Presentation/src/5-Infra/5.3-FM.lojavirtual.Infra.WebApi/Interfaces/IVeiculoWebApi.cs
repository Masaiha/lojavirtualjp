using FM.lojavirtual.Application.ViewModels;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface IVeiculoWebApi
    {
        Task<IEnumerable<VeiculoViewModel>> Listar(CancellationToken cancellationToken);
    }
}
