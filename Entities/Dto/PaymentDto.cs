using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class PaymentDto
    {
        [Required]
        public string UserName { get; set; }

        public string CardNumber { get; set; }

        public int Mounth { get; set; }

        public int Year { get; set; }

        public string Cvc { get; set; }

        public int Amount { get; set; }
    }
}
