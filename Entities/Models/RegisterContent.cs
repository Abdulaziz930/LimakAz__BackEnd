using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class RegisterContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string ProfileTitle { get; set; }

        [Required]
        public string IDTitle { get; set; }

        [Required]
        public string RuleTitle { get; set; }

        [Required]
        public string RegisterTitle { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
