using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ContentDto
    {
        public List<SectionDto> SectionsDto { get; set; }

        public List<AuxiliarySectionDto> AuxiliarySectionsDto { get; set; }

        public List<AuthenticationDto> AuthenticationsDto { get; set; }

        public OrderDto OrderDto { get; set; }
    }
}
