using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class PaymentDto
    {
        [Required]
        public string Email { get; set; }

        public string Token { get; set; }

        public double Sum { get; set; }

        public double Amount { get; set; }
    }
}
