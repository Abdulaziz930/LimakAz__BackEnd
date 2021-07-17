﻿using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ProductType : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
