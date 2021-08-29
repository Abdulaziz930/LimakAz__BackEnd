using AutoMapper;
using Buisness.Abstract;
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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        //GET: api/Language
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var language = await _languageService.GetAllLanguagesAsync();

            var languageDto = _mapper.Map<List<LanguageDto>>(language);

            return Ok(languageDto);
        }
    }
}
