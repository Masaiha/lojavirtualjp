using FM.lojavirtual.Application.ViewModels;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface ILoginWebApi
    {
        Task<UsuarioViewModel> Logar(UsuarioViewModel usuario, CancellationToken cancellationToken);
    }
}
