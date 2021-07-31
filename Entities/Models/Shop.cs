using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Shop : IEntity
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsRecommended { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModificationDate { get; set; }

        public ICollection<ShopCountry> ShopCountries { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
