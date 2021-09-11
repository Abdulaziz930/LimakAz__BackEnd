using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
