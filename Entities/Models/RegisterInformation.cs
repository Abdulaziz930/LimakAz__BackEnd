using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class RegisterInformation : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ButtonName { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
