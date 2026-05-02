using Microsoft.EntityFrameworkCore;

namespace TaskAPI.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TaskDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

      
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }
        public void Update(int id, T entity)
        {
            _dbSet.Update(entity);
            Save();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }
        public void Save()
        {
            
            _context.SaveChanges();
        }
    }
}
