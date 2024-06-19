using FM.lojavirtual.Application.ViewModels;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface ITiposVeiculoWebApi
    {
        Task<IEnumerable<TiposVeiculoViewModel>> Listar(string token, CancellationToken cancellationToken);
    }
}
