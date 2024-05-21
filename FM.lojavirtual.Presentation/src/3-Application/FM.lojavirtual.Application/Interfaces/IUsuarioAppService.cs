using FM.lojavirtual.Application.ViewModels;

namespace FM.lojavirtual.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<IEnumerable<UsuarioViewModel>> Listar();
    }
}
