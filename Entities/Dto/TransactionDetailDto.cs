using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class TransactionDetailDto
    {
        public int Id { get; set; }

        public decimal OldBalance { get; set; }

        public decimal Amount { get; set; }

        public decimal NewBalance { get; set; }

        public DateTime DateTime { get; set; }
    }
}
