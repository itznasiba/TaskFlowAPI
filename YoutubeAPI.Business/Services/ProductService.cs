using youtubeAPI.Core.Entities;
using YoutubeAPI.DataAccess.Repository;

namespace YoutubeAPI.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        //2
        public void Add(Product product)
        {
            _repository.Add(product);
            _repository.Save();
        }

        //1
        public void Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                {
                    throw new Exception("Object not found");
            }
            _repository.Delete(existing);
            _repository.Save();
        }
        //3
        public IEnumerable<Product> GetAll()
        {
            return (IEnumerable<Product>)_repository.GetAll();
        }
        //4
        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }
        //5
        public void Update(Product product)
        {
            _repository.Update(product);
        }
        public void Take(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            if (product.IsTaken)
            {
                throw new Exception("Product is already taken");
            }
            product.IsTaken = true;
            _repository.Update(product);
            _repository.Save();
        }
    }
}
