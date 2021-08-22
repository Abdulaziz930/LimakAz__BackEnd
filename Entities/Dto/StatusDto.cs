using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class StatusDto
    {
        public int Id { get; set; }

        public string StatusTitle { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
