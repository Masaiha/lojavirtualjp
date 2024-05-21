using System.Linq.Expressions;

namespace FM.lojavirtual.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes);
    }
}
