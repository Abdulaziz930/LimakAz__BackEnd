using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Language : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required,StringLength(3)]
        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<AuxiliarySection> AuxiliarySections { get; set; }

        public ICollection<Authentication> Authentications { get; set; }

        public Order Orders { get; set; }
    }
}
