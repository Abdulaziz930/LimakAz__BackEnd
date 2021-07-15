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
    public class AuxiliarySectionsController : ControllerBase
    {
        private readonly IRepository<AuxiliarySection> _repository;
        private readonly IMapper _mapper;

        public AuxiliarySectionsController(IRepository<AuxiliarySection> repository, IMapper mapper)
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
                nameof(AuxiliarySection.Language)
            };

            var auxiliarySections = await _repository.GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (auxiliarySections == null)
                return NotFound();

            var auxiliarySectionsDto = _mapper.Map<List<AuxiliarySectionDto>>(auxiliarySections);

            return Ok(auxiliarySectionsDto);
        }
    }
}
