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
    public class ContactContentController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IContactContentService _contactContentService;
        private readonly IMapper _mapper;

        public ContactContentController(IContactContentService contactContentService,IContactService contactService,IMapper mapper)
        {
            _contactContentService = contactContentService;
            _contactService = contactService;
            _mapper = mapper;
        }

        //GET: api/ContactContent/getContactsContent/az
        [HttpGet("getContactsContent/{languageCode}")]
        public async Task<IActionResult> GetContactsContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var contacts = await _contactService.GetAllContactsAsync(languageCode);
            if (contacts == null)
                return NotFound();


            var contactsDto = new List<ContactsDto>();
            foreach (var cityItem in contacts)
            {
                var servicesDto = new List<ServiceDto>();
                foreach (var contactItem in cityItem.Contacts)
                {
                    foreach (var item in contactItem.Services)
                    {
                        var serviceDto = new ServiceDto
                        {
                            Id = item.Id,
                            ServiceTitle = item.ServiceTitle,
                            ServiceValue = item.ServiceValue
                        };
                        servicesDto.Add(serviceDto);
                    }
                    var contactDto = new ContactsDto
                    {
                        Id = contactItem.Id,
                        CityName = cityItem.Name,
                        CityValue = cityItem.Value,
                        Location = contactItem.Location,
                        IframeLocation = contactItem.IframeLocation,
                        Phone = contactItem.Phone,
                        Email = contactItem.Email,
                        ServicesDto = servicesDto
                    };
                    contactsDto.Add(contactDto);
                }
            }

            return Ok(contactsDto);
        }

        //GET: api/ContactContent/getContactContent/az
        [HttpGet("getContactContent/{languageCode}")]
        public async Task<IActionResult> GetContactContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var contactContent = await _contactContentService.GetContactContentAsync(languageCode);
            if (contactContent == null)
                return NotFound();

            var contactContentDto = _mapper.Map<ContactContentDto>(contactContent);

            return Ok(contactContentDto);
        }
    }
}
