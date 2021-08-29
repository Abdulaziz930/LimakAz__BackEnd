using AutoMapper;
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
    public class ShopContentController : ControllerBase
    {
        private readonly IShopContentService _shopContentService;
        private readonly IMapper _mapper;

        public ShopContentController(IShopContentService shopContentService,IMapper mapper)
        {
            _shopContentService = shopContentService;
            _mapper = mapper;
        }

        //GET: api/ShopContent/getShopContent/az
        [HttpGet("getShopContent/{languageCode}")]
        public async Task<IActionResult> GetShopContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var shopContent = await _shopContentService.GetShopContentAsync(languageCode);
            if (shopContent == null)
                return NotFound();

            var shopContentDto = _mapper.Map<ShopContentDto>(shopContent);

            return Ok(shopContentDto);
        }
    }
}
