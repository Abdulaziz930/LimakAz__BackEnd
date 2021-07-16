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

        public List<CountryDto> CountriesDto { get; set; }

        public List<CityDto> CitiesDto { get; set; }

        public CalculatorDto CalculatorDto { get; set; }

        public List<UnitsOfLengthDto> UnitsOfLengthsDto { get; set; }

        public List<WeightDto> WeightsDto { get; set; }

        public List<ProductTypeDto> ProductTypesDto { get; set; }

        public WeightInputDto WeightInputDto { get; set; }

        public WidthInputDto WidthInputDto { get; set; }

        public LengthInputDto LengthInputDto { get; set; }

        public BoxCountInputDto BoxCountInputDto { get; set; }

        public HeightInputDto HeightInputDto { get; set; }

    }
}
