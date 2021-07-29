using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Tab : IEntity
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Key { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
