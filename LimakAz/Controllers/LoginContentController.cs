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
    public class LoginContentController : ControllerBase
    {
        private readonly ILoginContentService _loginContentService;
        private readonly IMapper _mapper;

        public LoginContentController(ILoginContentService loginContentService,IMapper mapper)
        {
            _loginContentService = loginContentService;
            _mapper = mapper;
        }

        [HttpGet("getLoginContent/{languageCode}")]
        public async Task<IActionResult> Get([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var loginContent = await _loginContentService.GetLoginContentAsync(languageCode);
            if (loginContent == null)
                return NotFound();

            var loginContentDto = _mapper.Map<LoginContentDto>(loginContent);

            return Ok(loginContentDto);
        }
    }
}
