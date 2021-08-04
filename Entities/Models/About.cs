using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class About : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AboutTitle { get; set; }

        public string Image { get; set; }

        [Required]
        public string BreadcrumbPathname { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
