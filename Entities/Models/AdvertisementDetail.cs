﻿using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class AdvertisementDetail : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }
    }
}
