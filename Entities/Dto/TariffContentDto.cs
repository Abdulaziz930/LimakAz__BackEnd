using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class TariffContentDto
    {
        public int Id { get; set; }

        public string ConutryName { get; set; }

        public string CountryValue { get; set; }

        public List<ProductTypeContentDto> ProductTypesDto { get; set; }

        public string TabTitle { get; set; }

        public string TabDescription { get; set; }

        public string TabImage { get; set; }
    }
}
