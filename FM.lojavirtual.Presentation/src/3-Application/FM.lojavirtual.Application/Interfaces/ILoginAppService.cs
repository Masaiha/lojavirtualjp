using FM.lojavirtual.Application.ViewModels;

namespace FM.lojavirtual.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<UsuarioViewModel?> Autenticar(string login, string senha);
    }
}
