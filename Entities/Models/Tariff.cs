using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Tariff : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int ConutryId { get; set; }

        public Country Country { get; set; }
    }
}
