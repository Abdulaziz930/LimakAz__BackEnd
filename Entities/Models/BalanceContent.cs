using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class BalanceContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ButtonName { get; set; }

        [Required]
        public string TableActionHeader { get; set; }

        [Required]
        public string TablePriceHeader { get; set; }

        [Required]
        public string TableDateHeader { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
