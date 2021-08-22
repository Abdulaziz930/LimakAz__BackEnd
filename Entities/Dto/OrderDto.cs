using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public string Note { get; set; }
    }
}
