using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FMLojaVirtualDbContext context) : base(context){}

        public async Task<IEnumerable<Usuario>> Listar()
        {
            var cn = OpenConnectionDb();

            const string sql = @"      SET ARITHABORT ON
                                    SELECT *
                                      FROM Usuarios WITH(NOLOCK)
                                ";

            var usuarios = await cn.QueryAsync<Usuario>(sql);
            
            return usuarios;
        }
    }
}
