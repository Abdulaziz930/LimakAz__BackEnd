using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class AdvertisementHeader : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Breadcrumb { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
