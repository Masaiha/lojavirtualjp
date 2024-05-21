using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface ILojaRepository
    {
        IEnumerable<Loja> ListarLojas();
    }
}
