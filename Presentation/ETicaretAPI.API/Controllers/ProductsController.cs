using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;



namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products=_productService.GetProducts();
            return Ok(products);
        }
    }
}

