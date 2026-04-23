namespace YoutubeAPI.DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(T entity);
        void Save();
    }
}
