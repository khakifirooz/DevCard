using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            _context = new ShopDbContext();
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int Count()
        {
            return _dbSet.Count();
        }
    }
}
