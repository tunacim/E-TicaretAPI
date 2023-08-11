using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModel.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWriteRepository _customerWriteRepository ;




        public ProductsController(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository)
     
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
           
        }

        [HttpGet]
        public async Task <IActionResult>Get()
        {

            return Ok(_productReadRepository.GetAll(false));
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));
        }



        [HttpPost]
        public async Task <IActionResult> Post(VM_Create_Product model )
        {
            if (ModelState.IsValid)
            {

            }
             await _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Stock=model.Stock,
                Price=model.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }



        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model) 
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;

           await _productWriteRepository.SaveAsync();

            return Ok();
        }



        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}

