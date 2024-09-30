using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class TiposVeiculoRepository : BaseRepository<TiposVeiculo>, ITiposVeiculoRepository
    {
        public TiposVeiculoRepository(FMLojaVirtualDbContext context) : base(context){}

        public async Task<IEnumerable<TiposVeiculo>> Listar()
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     SELECT Id,
	                                        Nome
                                       FROM TiposVeiculo WITH (NOLOCK) ";

            var tiposVeiculo = await cn.QueryAsync<TiposVeiculo>(sql);

            return tiposVeiculo;
        }

        public async Task<TiposVeiculo> ObterPorId(int id)
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     SELECT Id,
	                                        Nome
                                       FROM TiposVeiculo WITH (NOLOCK) 
                                      WHERE Id = @id";

            var tiposVeiculo = await cn.QueryAsync<TiposVeiculo>(sql, new { 
                id = id
            });

            return tiposVeiculo.FirstOrDefault();
        }
    }
}
