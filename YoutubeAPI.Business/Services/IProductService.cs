using youtubeAPI.Core.Entities;

namespace YoutubeAPI.Business.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Take(int id);
    }
}
