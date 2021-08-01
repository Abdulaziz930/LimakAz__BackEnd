using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Icon { get; set; }

        public bool IsDeleted { get; set; }
    }
}
