﻿using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Authentication : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
