using AutoMapper;
using Buisness.Abstract;
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
        private readonly ICertificateContentService _certificateService; 
        private readonly IMapper _mapper;

        public CertificateContentController(ICertificateContentService certificateService, IMapper mapper)
        {
            _certificateService = certificateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var certificates = await _certificateService.GetAllCertificatesAsync();
            if (certificates == null)
                return NotFound();

            var certificateDto = _mapper.Map<List<CertificateContentDto>>(certificates);

            return Ok(certificateDto);
        }
        
    }
}
