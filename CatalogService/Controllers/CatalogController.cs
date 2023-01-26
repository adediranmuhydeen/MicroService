using CatalogService.DataBase;
using CatalogService.Service;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _service;
        public CatalogController(DatabaseContext context, IProductService service)
        {
            _service = service;
        }

        [HttpGet("/All")]
        public IActionResult Get()
        {
            var products = _service.GetProductList();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null) { return BadRequest($"Product with ID {id} does not exist"); }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var produc = _service.AddProduct(product);
            if (produc == null) { return BadRequest($"Product {product.Name} does not exist"); }
            return Ok(produc);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var entity = _service.UpdateProduct(product);
            if (entity == null) { return BadRequest($"Product {product.Name} does not exist"); }
            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var entity = _service.DeleteProduct(id);
            if (entity == null) { return BadRequest($"Product with ID {id} does not exist"); }
            return Ok(entity);
        }
    }
}
