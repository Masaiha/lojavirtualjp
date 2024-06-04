using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> Listar();
        Task Adicionar(Veiculo veiculo);
    }
}
