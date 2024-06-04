using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;
using System.Globalization;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(FMLojaVirtualDbContext context) : base(context){}

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     SELECT Id,
                                            Nome,
                                            AnoFabricacao,
                                            Modelo,
                                            Kilometragem,
                                            Descricao,
                                            Valor
                                       FROM dbo.Veiculos WITH (NOLOCK)
                                ";

            var veiculos = await cn.QueryAsync<Veiculo>(sql);

            return veiculos;
        }

        public async Task Adicionar(Veiculo veiculo)
        {
            var cn = OpenConnectionDb();

            string sql = $@"INSERT INTO Veiculos  (Nome, 
                                                        AnoFabricacao, 
                                                        Modelo, 
                                                        Kilometragem, 
                                                        Descricao, 
                                                        Valor)
                                                VALUES (
                                                        '{veiculo.Nome}', 
                                                         {veiculo.AnoFabricacao}, 
                                                         {veiculo.Modelo}, 
                                                         {veiculo.Kilometragem}, 
                                                        '{veiculo.Descricao}', 
                                                         {veiculo.ObterValorVeiculoModeloBancoDados()}); ";

            await cn.QueryAsync(sql);

            return;
        }

    }
}
