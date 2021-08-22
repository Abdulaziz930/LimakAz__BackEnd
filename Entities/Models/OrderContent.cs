using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class OrderContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string CodeTitle { get; set; }

        [Required]
        public string PriceTitle { get; set; }

        [Required]
        public string CountTitle { get; set; }

        [Required]
        public string LinkTitle { get; set; }

        [Required]
        public string ButtonTitle { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
