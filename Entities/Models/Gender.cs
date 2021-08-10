using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Gender : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
