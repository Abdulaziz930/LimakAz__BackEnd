using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Price : IEntity
    {
        public int Id { get; set; }

        public decimal PriceCount { get; set; }

        public int TariffId { get; set; }

        public Tariff Tariff { get; set; }
    }
}
