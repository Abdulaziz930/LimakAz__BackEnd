using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ContactsDto
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public string CityValue { get; set; }

        public string Location { get; set; }

        public string IframeLocation { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<ServiceDto> ServicesDto { get; set; }
    }
}
