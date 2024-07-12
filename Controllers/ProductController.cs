using Microsoft.AspNetCore.Mvc;
using RedbullService.DTOs;
using RedbullService.Interfaces;
using RedbullService.Models;
using RedBullService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            var product = new Product
            {
                product_name = productDto.product_name,
                price = productDto.price,
                img_url = productDto.img_url,
                description = productDto.description,
                category_id = productDto.category_id
            };

            await _productRepository.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.product_id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.product_id)
            {
                return BadRequest("Product ID mismatch");
            }

            var product = await _productRepository.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            product.product_name = productDto.product_name;
            product.price = productDto.price;
            product.img_url = productDto.img_url;
            product.description = productDto.description;
            product.category_id = productDto.category_id;

            await _productRepository.UpdateProduct(product);

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteProduct(id);

            return NoContent();
        }
    }
}
