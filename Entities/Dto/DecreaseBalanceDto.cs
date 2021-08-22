using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class DecreaseBalanceDto
    {
        [Required]
        public string UserName { get; set; }

        public double ResultBalance { get; set; }

        public double Amount { get; set; }
    }
}
