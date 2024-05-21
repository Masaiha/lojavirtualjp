using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class LojaRepository : BaseRepository<Loja>, ILojaRepository
    {
        public LojaRepository(FMLojaVirtualDbContext context) : base(context){}

        public IEnumerable<Loja> ListarLojas()
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     SELECT Id,
                                            Nome
                                       FROM dbo.Loja WITH (NOLOCK)
                                ";

            var lojas = cn.Query<Loja>(sql);

            return lojas;
        }
    }
}
