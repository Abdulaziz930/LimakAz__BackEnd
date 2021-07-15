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
    public class LanguageController : ControllerBase
    {
        private readonly IRepository<Language> _repository;
        private readonly IMapper _mapper;

        public LanguageController(IRepository<Language> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var language = await _repository.GetAllAsync(x => x.IsDeleted == false,null);

            var languageDto = _mapper.Map<List<LanguageDto>>(language);

            return Ok(languageDto);
        }
    }
}
