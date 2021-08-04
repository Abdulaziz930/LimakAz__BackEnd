using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ContactContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string WriteUsTitle { get; set; }

        [Required]
        public string WriteUsButton { get; set; }

        [Required]
        public string BreadcrumbPathname { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
