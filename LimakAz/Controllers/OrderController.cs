using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace LimakAz.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;
        private readonly IOrderContentService _orderContentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(IOrderService orderService
            , IStatusService statusService, IOrderContentService orderContentService
            , IMapper mapper, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _statusService = statusService;
            _orderContentService = orderContentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("makeOrder")]
        public async Task<IActionResult> PostOrder([FromBody] List<MakeOrderDto> makeOrders)
        {
            foreach (var makeOrder in makeOrders)
            {
                if (makeOrder.Price <= 0 || makeOrder.Count <= 0)
                    return BadRequest();

                var user = await _userManager.FindByNameAsync(makeOrder.UserName);
                if (user == null)
                    return NotFound();

                var code = "NW" + RandomUtil.RandomStringGenerator(9);

                var order = new Order
                {
                    Url = makeOrder.Url,
                    Price = makeOrder.Price,
                    Count = makeOrder.Count,
                    Note = makeOrder.Note,
                    Code = code,
                    AppUserId = user.Id,
                    StatusId = 1
                };

                await _orderService.AddAsync(order);
            }

            return Ok(new ResponseDto { Status = "Success", Message = "Order succeffuly added" });
        }

        [HttpGet("getOrders/{languageCode}/{userName}")]
        public async Task<IActionResult> GetOrders([FromRoute] string languageCode, string userName)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var orders = await _statusService.GetAllStatusesAsync(languageCode, user.Id);
            if (orders == null)
                return NotFound();

            var statusesDto = new List<StatusDto>();
            foreach (var status in orders)
            {
                var ordersDto = new List<OrderDto>();
                foreach (var order in status.Orders)
                {
                    var orderDto = new OrderDto
                    {
                        Id = order.Id,
                        Url = order.Url,
                        Price = order.Price,
                        Code = order.Code,
                        Count = order.Count,
                        Note = order.Note
                    };
                    ordersDto.Add(orderDto);
                }
                var statusDto = new StatusDto
                {
                    Id = status.Id,
                    StatusTitle = status.Title,
                    Orders = ordersDto
                };
                statusesDto.Add(statusDto);
            }

            return Ok(statusesDto);
        }

        [HttpGet("getOrderContent/{languageCode}")]
        public async Task<IActionResult> GetOrderContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var orderContent = await _orderContentService.GetOrderContentAsync(languageCode);
            if (orderContent == null)
                return NotFound();

            var orderContentDto = _mapper.Map<OrderContentDto>(orderContent);

            return Ok(orderContentDto);
        }
    }
}
