using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class BalanceContentDto
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string ButtonName { get; set; }

        public string TableDetailHeader { get; set; }

        public string TablePriceHeader { get; set; }

        public string TableButtonName { get; set; }

        public string TableDateHeader { get; set; }

        public string IncreaseBalanceHeader { get; set; }

        public string IncreaseBalanceDescription { get; set; }

        public string IncreaseBalanceButtonName { get; set; }
    }
}
