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
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<Authentication> _repository;
        private readonly IMapper _mapper;

        public AuthenticationController(IRepository<Authentication> repository, IMapper mapper)
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

            var authentications = await _repository.GetAllAsync(x => x.Language.Code == languageCode, includedProperties);
            if (authentications == null)
                return NotFound();

            var authenticationsDto = _mapper.Map<List<AuthenticationDto>>(authentications);

            return Ok(authenticationsDto);
        }
    }
}
