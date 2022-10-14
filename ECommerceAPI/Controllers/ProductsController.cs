using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interfaces;
using ECommerceAPI.Dtos;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IConfiguration _config;
        public ProductsController(IProductRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =await _repository.GetProductsAsync();

            return Ok(products.Select(product => new ProductToReturnDto 
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = _config["ApiUrl"] + (product.PictureUrl),
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            return Ok(new ProductToReturnDto()
            {
                Name = product.Name,
                Description=product.Description,
                Price=product.Price,
                PictureUrl =_config["ApiUrl"] + product.PictureUrl,
                ProductType=product.ProductType.Name,
                ProductBrand=product.ProductBrand.Name
            }) ;
        }
    }
}