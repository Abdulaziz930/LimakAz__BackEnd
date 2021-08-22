using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Status : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Key { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
