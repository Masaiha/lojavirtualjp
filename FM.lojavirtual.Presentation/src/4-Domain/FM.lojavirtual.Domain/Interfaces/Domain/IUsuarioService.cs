using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Domain
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> Listar();
    }
}
