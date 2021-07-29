﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Calculator : IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(50)]
        public string EmptyButtonName { get; set; }

        [Required, StringLength(50)]
        public string SumButtonName { get; set; }

        [Required, StringLength(50)]
        public string SumLabelName { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
