using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class SettingContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string ProfileTitle { get; set; }

        [Required]
        public string ChangePasswordTitle { get; set; }

        [Required]
        public string ButtonName { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
