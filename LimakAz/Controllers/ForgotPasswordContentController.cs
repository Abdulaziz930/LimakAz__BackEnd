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
    public class ForgotPasswordContentController : ControllerBase
    {
        private readonly IForgotPasswordContentService _forgotPasswordContentService;
        private readonly IMapper _mapper;

        public ForgotPasswordContentController(IForgotPasswordContentService forgotPasswordContentService, IMapper mapper)
        {
            _forgotPasswordContentService = forgotPasswordContentService;
            _mapper = mapper;
        }

        //GET: api/ForgotPasswordContent/getForgotPasswordContent/az
        [HttpGet("getForgotPasswordContent/{languageCode}")]
        public async Task<IActionResult> GetForgotPasswordContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var forgotPasswordContent = await _forgotPasswordContentService.GetForgotPasswordContentAsync(languageCode);
            if (forgotPasswordContent == null)
                return NotFound();

            var forgotPasswordContentDto = _mapper.Map<ForgotPasswordContentDto>(forgotPasswordContent);

            return Ok(forgotPasswordContentDto);
        }
    }
}
