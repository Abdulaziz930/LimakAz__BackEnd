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
    public class SectionController : ControllerBase
    {
        private readonly IRepository<Section> _repository;
        private readonly IMapper _mapper;

        public SectionController(IRepository<Section> repository, IMapper mapper)
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
                nameof(Section.Language)
            };

            var sections = await _repository.GetAllAsync(x => x.Language.Code == languageCode, includedProperties);
            if (sections == null)
                return NotFound();

            var sectionsDto = _mapper.Map<List<SectionDto>>(sections);

            return Ok(sectionsDto);
        }
    }
}
