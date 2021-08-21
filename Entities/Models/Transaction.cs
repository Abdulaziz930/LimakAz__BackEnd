using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }

        [Required]
        public decimal OldBalance { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
