using _5._2_FM.lojavirtual.Infra.Data.Context;
using FM.lojavirtual.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly FMLojaVirtualDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(FMLojaVirtualDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public DbConnection OpenConnectionDb()
        {
            Db.Database.OpenConnection();

            return Db.Database.GetDbConnection();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }
        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            TEntity result = query.FirstOrDefault();
            return result;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            IEnumerable<TEntity> result = query.ToList();
            return result;
        }

        public void Dispose()
        {
            Db?.Dispose();

        }
    }
}
