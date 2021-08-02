using Buisness.Abstract;
using Entities.Dto;
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
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("getAllShops/{id}/{skipCount}/{takeCount}")]
        public async Task<IActionResult> GetAllShops([FromRoute] int? id, int skipCount = 0, int takeCount = 10)
        {
            if (id == null)
                return BadRequest();

            var shops = await _shopService.GetAllShopsAsync(id.Value, skipCount, takeCount);
            if (shops == null)
                return NotFound();

            var shopsDto = new List<ShopDto>();
            foreach (var shop in shops)
            {
                var shopDto = new ShopDto
                {
                    Id = shop.Id,
                    Title = shop.Title,
                    Url = shop.Url,
                    Image = shop.Image,
                    CountryId = id.Value
                };
                shopsDto.Add(shopDto);
            }

            return Ok(shopsDto);
        }

        [HttpGet("getShopsCount/{id}")]
        public async Task<IActionResult> GetShopsCount([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            var shops = await _shopService.GetAllShopsAsync(id.Value);
            if (shops == null)
                return NotFound();

            var count = shops.Count;

            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecommendedShops()
        {
            var shops = await _shopService.GetAllRecommendedShopsAsync();
            if (shops == null)
                return NotFound();

            var recommendedShopsDto = new List<RecommendedShopDto>();
            foreach (var shop in shops)
            {
                var recommendedShopDto = new RecommendedShopDto
                {
                    Id = shop.Id,
                    Image = shop.Image
                };
                recommendedShopsDto.Add(recommendedShopDto);
            }

            return Ok(recommendedShopsDto);
        }
    }
}
