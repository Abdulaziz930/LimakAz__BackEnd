using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class CalculatorDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string EmptyButtonName { get; set; }

        public string SumButtonName { get; set; }

        public string SumLabelName { get; set; }
    }
}
