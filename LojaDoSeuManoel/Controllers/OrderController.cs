using AutoMapper;
using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(
            IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async  Task<IActionResult> PackOrder([FromBody] OrderInputModel orderInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =  await _orderService.PackOrder(_mapper.Map<Order>(orderInput));
            return Ok(result);
        }

    }
}