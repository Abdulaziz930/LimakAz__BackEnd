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
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService,IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        //GET: api/SocialMedia
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var socialMedias = await _socialMediaService.GetAllSocialMediasAsync();
            if (socialMedias == null)
                return NotFound();

            var socialMediasDto = _mapper.Map<List<SocialMediaDto>>(socialMedias);

            return Ok(socialMediasDto);
        }
    }
}
