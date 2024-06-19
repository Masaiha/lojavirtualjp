using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Domain;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace FM.lojavirtual.Domain.Servicos
{
    public class TiposVeiculoService : ITiposVeiculoService
    {
        private readonly ITiposVeiculoRepository _repository;

        public TiposVeiculoService(ITiposVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TiposVeiculo>> Listar()
        {
            return await _repository.Listar();
        }
    }
}
