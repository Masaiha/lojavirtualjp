using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface ILoginRepository
    {
        Task<Usuario?> Autenticar(string login, string senha);
    }
}
