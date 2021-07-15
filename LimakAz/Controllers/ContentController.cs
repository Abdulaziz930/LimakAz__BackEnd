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
    public class ContentController : ControllerBase
    {
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<AuxiliarySection> _auxiliarySectionRepository;
        private readonly IRepository<Authentication> _authenticationRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public ContentController(IRepository<Section> sectionRepository, IRepository<AuxiliarySection> auxiliarySectionRepository,
           IRepository<Authentication> authenticationRepository, IRepository<Order> orderRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _auxiliarySectionRepository = auxiliarySectionRepository;
            _authenticationRepository = authenticationRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet("getContentWebSite/{languageCode}")]
        public async Task<IActionResult> GetContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var sections = await _sectionRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (sections == null)
                return NotFound();

            var auxiliarySections = await _auxiliarySectionRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (auxiliarySections == null)
                return NotFound();

            var authentications = await _authenticationRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (authentications == null)
                return NotFound();

            var order = await _orderRepository.GetAsync(x => x.Language.Code == languageCode, includedProperties);
            if (order == null)
                return NotFound();

            var sectionsDto = _mapper.Map<List<SectionDto>>(sections);
            var auxiliarySectionsDto = _mapper.Map<List<AuxiliarySectionDto>>(auxiliarySections);
            var authenticationsDto = _mapper.Map<List<AuthenticationDto>>(authentications);
            var orderDto = _mapper.Map<OrderDto>(order);

            var contentDto = new ContentDto
            {
                SectionsDto = sectionsDto,
                AuxiliarySectionsDto = auxiliarySectionsDto,
                AuthenticationsDto = authenticationsDto,
                OrderDto = orderDto
            };

            return Ok(contentDto);
        }
    }
}
