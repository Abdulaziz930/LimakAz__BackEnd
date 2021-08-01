using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Service : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string ServiceTitle { get; set; }

        [Required]
        public string ServiceValue { get; set; }

        public bool IsDeleted { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
