using AutoMapper;
using DataAccess.Interfaces;
using Entities.Dto;
using Entities.Models;
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
    public class CertificateContentController : ControllerBase
    {
        private readonly IRepository<CertifcateContent> _repository;
        private readonly IMapper _mapper;

        public CertificateContentController(IRepository<CertifcateContent> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var certificates = await _repository.GetAllAsync(x => x.IsDeleted == false,null);
            if (certificates == null)
                return NotFound();

            var certificateDto = _mapper.Map<List<CertificateContentDto>>(certificates);

            return Ok(certificateDto);
        }
        
    }
}
