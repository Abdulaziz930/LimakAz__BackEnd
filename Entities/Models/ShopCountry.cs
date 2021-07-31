using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ShopCountry : IEntity
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
