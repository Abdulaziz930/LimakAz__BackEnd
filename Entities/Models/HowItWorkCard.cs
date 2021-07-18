using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class HowItWorkCard : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(250)]
        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
