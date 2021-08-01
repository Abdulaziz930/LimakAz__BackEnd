using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string IframeLocation { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
