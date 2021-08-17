using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class AddressContentDto
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string CountryValue { get; set; }

        public List<AddressDto> Addresses { get; set; }
    }
}
