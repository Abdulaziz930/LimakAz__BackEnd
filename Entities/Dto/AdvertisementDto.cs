using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class AdvertisementDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
