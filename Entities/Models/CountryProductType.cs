using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CountryProductType : IEntity
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
