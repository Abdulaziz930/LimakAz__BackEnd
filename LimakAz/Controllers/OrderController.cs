using AutoMapper;
using DataAccess.Interfaces;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderController(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("languageCode/{languageCode}")]
        public async Task<IActionResult> Get([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Order.Language)
            };

            var orders = await _repository.GetAsync(x => x.Language.Code == languageCode, includedProperties);
            if (orders == null)
                return NotFound();

            var ordersDto = _mapper.Map<OrderDto>(orders);

            return Ok(ordersDto);
        }
    }
}
