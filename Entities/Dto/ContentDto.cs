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

        public List<CalculatorDto> CalculatorsDto { get; set; }

        public List<UnitsOfLengthDto> UnitsOfLengthsDto { get; set; }

        public List<WeightDto> WeightsDto { get; set; }

        public List<ProductTypeDto> ProductTypesDto { get; set; }

        public List<WeightInputDto> WeightInputsDto { get; set; }

        public List<WidthInputDto> WidthInputsDto { get; set; }

        public List<LengthInputDto> LengthInputsDto { get; set; }

        public List<BoxCountInputDto> BoxCountInputsDto { get; set; }

        public List<HeightInputDto> HeightInputsDto { get; set; }

    }
}
