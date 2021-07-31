using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ShopDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public int CountryId { get; set; }
    }
}
