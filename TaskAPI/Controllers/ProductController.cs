using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TaskAPI.Business.Services;
using TaskAPI.Core.Exceptions;
using TaskAPI.Core.Product;

namespace youtubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(ProductSaveDto product)
        {
            _productService.Add(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductSaveDto product)
        {
            _productService.Update(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpPost("{id}/take")]
        public IActionResult Take(int id)
        {
            _productService.Take(id);
            return Ok();
        }

    }
}