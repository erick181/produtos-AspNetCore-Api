using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_products.Models;
using project_products.Repositories;
using project_products.Repositories.Interface;

namespace project_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Authorize(Roles = "employed")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            List<Product> products = await _productRepository.GetAll();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetById(int id)
        {
            Product product = await _productRepository.GetById(id);
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            Product productReturn = await _productRepository.Add(product);
            return Ok(productReturn);

        }


    }
}
