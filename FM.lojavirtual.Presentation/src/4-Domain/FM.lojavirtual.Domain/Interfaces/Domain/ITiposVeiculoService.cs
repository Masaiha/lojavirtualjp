using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Domain
{
    public interface ITiposVeiculoService
    {
        Task<IEnumerable<TiposVeiculo>> Listar();
    }
}
