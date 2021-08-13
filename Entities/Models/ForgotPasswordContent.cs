using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ForgotPasswordContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string ContentTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ButtonName { get; set; }

        [Required]
        public string SuccessMessageFirstSide { get; set; }

        [Required]
        public string SuccessMessageSecondSide { get; set; }

        [Required]
        public string SuccessMessageDescription { get; set; }

        public string Image { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
