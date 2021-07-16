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

        public Order Orders { get; set; }

        public Calculator Calculator { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Weight> Weights { get; set; }

        public WeightInput WeightInput { get; set; }

        public ICollection<UnitsOfLength> UnitsOfLengths { get; set; }

        public WidthInput WidthInput { get; set; }

        public HeightInput HeightInput { get; set; }

        public LengthInput LengthInput { get; set; }

        public BoxCountInput BoxCountInput { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
