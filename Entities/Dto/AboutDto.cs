using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class AboutDto
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string AboutTitle { get; set; }

        public string Description { get; set; }

        public string BreadcrumbPathname { get; set; }
    }
}
