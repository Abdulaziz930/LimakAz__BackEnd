using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ProductTypeContentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public List<TariffDto> TariffsDto { get; set; }
    }
}
