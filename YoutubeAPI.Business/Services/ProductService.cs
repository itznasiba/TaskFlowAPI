using AutoMapper;
using TaskAPI.Core.Product;
using TaskAPI.DataAccess.Repository;

namespace TaskAPI.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //2
        public void Add(ProductSaveDto product)
        {
            //Product productEntity = new Product
            //{
            //    Title = product.Title,
            //    Description = product.Description,
            //    Deadline = product.Deadline,
            //    IsTaken = false
            //};
           var productEntity = _mapper.Map<Product>(product);
            _repository.Add(productEntity);
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
        public IEnumerable<ProductDto> GetAll()
        {
            IEnumerable<Product> products = _repository.GetAll();
            var productList = _mapper.Map<List<ProductDto>>(products);
            return productList;
        }
        //4
        public ProductDto? GetById(int id)
        {
            var entity = _repository.GetById(id);

            var dto = _mapper.Map<ProductDto>(entity);
            return dto;
        }
        //5
        public void Update(int id, ProductSaveDto product)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new Exception("Product not found");
            }
            //existing.Title = product.Title;
            //existing.Description = product.Description;
            //existing.Deadline = product.Deadline;

            var productEntity = _mapper.Map<Product>(product);
            _repository.Update(id, productEntity);
            _repository.Save();
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
            _repository.Update(id, product);
            _repository.Save();
        }
    }
}
