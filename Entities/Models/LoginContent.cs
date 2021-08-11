using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class LoginContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string RememberMeLabel { get; set; }

        [Required]
        public string ForgotPasswordName { get; set; }

        [Required]
        public string ButtonName { get; set; }

        [Required]
        public string RegisterLinkName { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
