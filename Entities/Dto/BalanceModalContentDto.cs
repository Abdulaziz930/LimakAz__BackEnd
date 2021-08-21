using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class BalanceModalContentDto
    {
        public int Id { get; set; }

        public string ModalHeader { get; set; }

        public string OldBalanceTitle { get; set; }

        public string AmountTitle { get; set; }

        public string NewBalanceTitle { get; set; }

        public string DateTimeTitle { get; set; }
    }
}
