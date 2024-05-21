using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Listar();
    }
}
