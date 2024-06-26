﻿using FM.lojavirtual.Domain.Entidades;
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

        public async Task<IEnumerable<Veiculo>> Listar(int idTipoVeiculo)
        {
            return await _repository.Listar(idTipoVeiculo);
        }

        public async Task Adicionar(Veiculo veiculo)
        {

            if (string.IsNullOrEmpty(veiculo.Nome) ||
               string.IsNullOrEmpty(veiculo.Descricao) ||
               veiculo.Valor <= 0)
                throw new Exception("Preencha os dados do veículo corretamente.");

            await _repository.Adicionar(veiculo);

            return;
        }
    }
}
