using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class LoginRepository : BaseRepository<Usuario> ,ILoginRepository
    {
        public LoginRepository(FMLojaVirtualDbContext context) : base(context) {}

        public async Task<Usuario?> Autenticar(string login, string senha)
        {
            var cn = OpenConnectionDb();

            const string sql = @"
                                    SELECT *
                                      FROM Usuarios
                                     WHERE login = @login
                                       AND senha = @senha
                                ";

            var usuario = await cn.QueryAsync<Usuario>(sql, new
            {
                login = login,
                senha = senha
            });

            return usuario.FirstOrDefault();
        }
    }
}
