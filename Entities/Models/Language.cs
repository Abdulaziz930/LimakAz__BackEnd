using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<AuxiliarySection> AuxiliarySections { get; set; }

        public ICollection<Authentication> Authentications { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
