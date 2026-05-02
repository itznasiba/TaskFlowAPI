using TaskAPI.Core.Product;

namespace TaskAPI.Business.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto? GetById(int id);
        void Add(ProductSaveDto product);
        void Update(int id, ProductSaveDto product);
        void Delete(int id);
        void Take(int id);
    }
}
