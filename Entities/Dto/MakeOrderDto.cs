using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class MakeOrderDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
