using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Domain.Interfaces.Domain
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> Listar();
        Task<IEnumerable<Veiculo>> Listar(int idTipoVeiculo);
        Task Adicionar(Veiculo veiculo);
    }
}
