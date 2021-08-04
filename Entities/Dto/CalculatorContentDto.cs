using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class CalculatorContentDto
    {
        public int Id { get; set; }

        public string CalculatorHeading { get; set; }

        public string ConverterTitle { get; set; }

        public string ConverterDescription { get; set; }

        public string ConverterButton { get; set; }

        public string BreadcrumbPathname { get; set; }
    }
}
