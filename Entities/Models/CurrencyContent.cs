using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class CurrencyContent : IEntity
    {
        public int Id { get; set; }

        [Required,StringLength(3)]
        public string RateTitle { get; set; }

        public bool IsDeleted { get; set; }
    }
}
