using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class TariffDto
    {
        public List<Tariff> Tariffs { get; set; }

        public List<CountryProductType> CountryProductTypes { get; set; }
    }
}
