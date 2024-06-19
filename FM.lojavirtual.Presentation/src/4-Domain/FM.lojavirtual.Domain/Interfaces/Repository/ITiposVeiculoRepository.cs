using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface ITiposVeiculoRepository
    {
        Task<IEnumerable<TiposVeiculo>> Listar();
    }
}
