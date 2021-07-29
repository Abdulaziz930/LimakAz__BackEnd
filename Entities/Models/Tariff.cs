using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Tariff : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
