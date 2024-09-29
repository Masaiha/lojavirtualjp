using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;
using System.Globalization;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(FMLojaVirtualDbContext context, IVeiculoImagemRepository veiculoImagemRepository) : base(context){}

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     select v.Nome,
	                                        AnoFabricacao,
	                                        Modelo, Kilometragem,
	                                        Descricao,
	                                        Valor,
	                                        vi.Id As IdImagem,
	                                        vi.Nome As Nome,
	                                        vi.Tipo,
                                            tv.Id As IdTiposVeiculo,
                                            tv.Nome As Nome
                                       from Veiculos v  WITH (NOLOCK)
                                       join VeiculoImagem vi  WITH (NOLOCK)
                                         on v.Id = vi.IdVeiculo
                                        join TiposVeiculo tv WITH (NOLOCK)
                                          on tv.Id = v.IdTipoVeiculo
                                ";

            var veiculos = await cn.QueryAsync<Veiculo, VeiculoImagem, TiposVeiculo, Veiculo>(
                sql: sql,
                map: (veiculo, veiculoImagem, tiposVeiculo) =>
                    {
                        veiculo.VeiculoImagem = veiculoImagem;
                        veiculo.TiposVeiculo = tiposVeiculo;

                        return veiculo;
                    },
                null,
                splitOn: "IdImagem, IdTiposVeiculo",
                transaction: null);


            return veiculos;
        }

        public async Task<IEnumerable<Veiculo>> Listar(int idTipoVeiculo)
        {
            var cn = OpenConnectionDb();

            string sql = $@"SET ARITHABORT ON
                                     SELECT v.Nome,
	                                        AnoFabricacao,
	                                        Modelo, Kilometragem,
	                                        Descricao,
	                                        Valor,
	                                        vi.Id As IdImagem,
	                                        vi.Nome As Nome,
	                                        vi.Tipo,
                                            tv.Id As IdTiposVeiculo,
                                            tv.Nome As Nome
                                       FROM Veiculos v  WITH (NOLOCK)
                                       JOIN VeiculoImagem vi  WITH (NOLOCK)
                                         ON v.Id = vi.IdVeiculo
                                       JOIN TiposVeiculo tv WITH (NOLOCK)
                                         ON tv.Id = v.IdTipoVeiculo
                                      WHERE tv.Id = {idTipoVeiculo} ";

            var veiculos = await cn.QueryAsync<Veiculo, VeiculoImagem, TiposVeiculo, Veiculo>(
                sql: sql,
                map: (veiculo, veiculoImagem, tiposVeiculo) =>
                {
                    veiculo.VeiculoImagem = veiculoImagem;
                    veiculo.TiposVeiculo = tiposVeiculo;

                    return veiculo;
                },
                null,
                splitOn: "IdImagem, IdTiposVeiculo",
                transaction: null);


            return veiculos;
        }

        public async Task Adicionar(Veiculo veiculo)
        {
            var cn = OpenConnectionDb();

            string sql = $@"INSERT INTO Veiculos  (IdTipoVeiculo, Nome, 
                                                        AnoFabricacao, 
                                                        Modelo, 
                                                        Kilometragem, 
                                                        Descricao, 
                                                        Valor)
                                                VALUES (1,
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
