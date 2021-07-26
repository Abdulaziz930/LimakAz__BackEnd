using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class AllAdvertisementDto
    {
        public List<AdvertisementDto> AdvertisementDto { get; set; }

        public List<AdvertisementDetailDto> AdvertisementDetailDto { get; set; }
    }
}
