using Core.Entities;
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

        public ICollection<Calculator> Calculators { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Weight> Weights { get; set; }

        public ICollection<UnitsOfLength> UnitsOfLengths { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }

        public ICollection<HowItWork> HowItWorks { get; set; }

        public ICollection<HowItWorkCard> HowItWorkCards { get; set; }

        public ICollection<Certificate> Certificates { get; set; }

        public ICollection<AdvertisimentTitle> AdvertisimentTitles { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }

        public ICollection<AdvertisementDetail> AdvertisementDetails { get; set; }

        public ICollection<Tariff> Tariffs { get; set; }

        public ICollection<ContactContent> ContactContents { get; set; }

        public ICollection<ShopContent> ShopContents { get; set; }

        public ICollection<CountryContent> CountryContents { get; set; }

        public ICollection<CalculatorIntormationContent> CalculatorIntormationContents { get; set; }

        public ICollection<CalculatorContent> CalculatorContents { get; set; }

        public ICollection<Rule> Rules { get; set; }

        public ICollection<RuleContent> RuleContents { get; set; }

        public ICollection<Question> Questions { get; set; }

        //public ICollection<Tab> Tabs { get; set; }
    }
}
