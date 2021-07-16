using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Calculator : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string EmptyButtonName { get; set; }

        public string SumButtonName { get; set; }

        public string SumLabelName { get; set; }

        public bool IsDeleted { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
