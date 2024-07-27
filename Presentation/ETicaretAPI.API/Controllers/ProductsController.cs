using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

       

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            var id=Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = id, Name = "ömer" });
            await _orderWriteRepository.AddAsync(new() { Description = "tanımm", Address = "şanlıurfa/viranşehir", CustomerId = id });
            await _orderWriteRepository.SaveAsync();
        }
        [HttpPut("id")]
        public async Task Update(string id)
        {
            var order=await _orderReadRepository.GetByIdAsync(id);
            order.Description = "değişirildi";
             _orderWriteRepository.Update(order);
            _orderWriteRepository.SaveAsync();
            
        }
    }
}
