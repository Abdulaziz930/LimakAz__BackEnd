using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class CalculatorContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string CalculatorHeading { get; set; }

        [Required]
        public string ConverterTitle { get; set; }

        [Required]
        public string ConverterDescription { get; set; }

        [Required]
        public string ConverterButton { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
