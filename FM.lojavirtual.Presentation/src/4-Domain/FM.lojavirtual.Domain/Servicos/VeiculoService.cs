using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Domain;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace FM.lojavirtual.Domain.Servicos
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            return await _repository.Listar();
        }
    }
}
