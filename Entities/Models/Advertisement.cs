using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Advertisement : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(60)]
        public string Title { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime LastModificationDate { get; set; }

        public AdvertisementDetail AdvertisementDetail { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
