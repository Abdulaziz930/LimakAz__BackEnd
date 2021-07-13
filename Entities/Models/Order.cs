﻿using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public string ButtonName { get; set; }

        public string ButtonUrl { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
