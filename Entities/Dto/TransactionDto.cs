using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public decimal OldBalance { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }
    }
}
