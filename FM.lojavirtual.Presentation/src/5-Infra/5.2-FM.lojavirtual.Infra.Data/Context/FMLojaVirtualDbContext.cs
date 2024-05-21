using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _5._2_FM.lojavirtual.Infra.Data.Context
{
    public class FMLojaVirtualDbContext : DbContext
    {
        public FMLojaVirtualDbContext(DbContextOptions<FMLojaVirtualDbContext> opt) : base(opt)
        {
            Dapper.SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
        }
    }
}
