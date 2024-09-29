using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class VeiculoImagemRepository : BaseRepository<VeiculoImagem>, IVeiculoImagemRepository
    {
        public VeiculoImagemRepository(FMLojaVirtualDbContext context) : base(context){}


        public async Task AdicionarSemImagemEmUltimoVeiculoAdd()
        {
            var cn = OpenConnectionDb();

            string sql = $@"INSERT INTO VeiculoImagem (IdVeiculo, 
                                        Nome, 
                                        Tipo,
                                        Ativo,
                                        DataCriacao,
                                        DataAlteracao)
                                  VALUES (
                                        (SELECT MAX(Id) as id from Veiculos),
                                        'semimagem.jpeg', 
                                        'jpeg', 
                                        1, 
                                        (select GETDATE()),
                                        null) ";

            await cn.QueryAsync(sql);

            return;
        }
    }
}
