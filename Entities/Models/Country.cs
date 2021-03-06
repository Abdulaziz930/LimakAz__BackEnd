using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Country : IEntity
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public Tab Tab { get; set; }

        public ICollection<ShopCountry> ShopCountries { get; set; }

        public ICollection<Tariff> Tariffs { get; set; }

        public ICollection<AddressContent> AddressContents { get; set; }
    }
}
