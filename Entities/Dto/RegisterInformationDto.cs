using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class RegisterInformationDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ButtonName { get; set; }

        public string Image { get; set; }
    }
}
