using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class TariffDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
    }
}
