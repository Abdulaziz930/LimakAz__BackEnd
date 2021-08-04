using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ContactContentDto
    {
        public int Id { get; set; }

        public string PageTitle { get; set; }

        public string WriteUsTitle { get; set; }

        public string WriteUsButton { get; set; }

        public string BreadcrumbPathname { get; set; }
    }
}
