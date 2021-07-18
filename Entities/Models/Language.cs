using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Language : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required,StringLength(3)]
        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<AuxiliarySection> AuxiliarySections { get; set; }

        public ICollection<Authentication> Authentications { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Calculator> Calculators { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Weight> Weights { get; set; }

        public ICollection<WeightInput> WeightInputs { get; set; }

        public ICollection<UnitsOfLength> UnitsOfLengths { get; set; }

        public ICollection<WidthInput> WidthInputs { get; set; }

        public ICollection<HeightInput> HeightInputs { get; set; }

        public ICollection<LengthInput> LengthInputs { get; set; }

        public ICollection<BoxCountInput> BoxCountInputs { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }

        public ICollection<HowItWork> HowItWorks { get; set; }

        public ICollection<HowItWorkCard> HowItWorkCards { get; set; }
    }
}
