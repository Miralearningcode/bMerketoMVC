using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ProductRepo _productRepo;

        public ProductsController(ProductService productService, ProductRepo productRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductAsync(schema.ArticleNumber);
                if (product != null)
                    return Conflict(new { product, error = "A product with the same article number already exist" });

                product = await _productService.CreateProductAsync(schema);
                if (product != null)
                    return Created("", product);
            }

            return BadRequest(schema);
        }

        [HttpGet("{articleNumber}")]
        public async Task <IActionResult> Get(ProductSchema schema)
        {
            if (string.IsNullOrEmpty(schema.ArticleNumber))
                return BadRequest();

            var entity = await _productService.GetProductAsync(schema.ArticleNumber);
            if (entity != null)
                return Ok(entity);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string articleNumber)
        {
            var entities = await _productService.GetProductAsync(articleNumber);
            if (entities != null)
                return Ok(entities);

            return NotFound();
        }
    }
}
