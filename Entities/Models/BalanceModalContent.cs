using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class BalanceModalContent : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string ModalHeader { get; set; }

        [Required]
        public string OldBalanceTitle { get; set; }

        [Required]
        public string AmountTitle { get; set; }

        [Required]
        public string NewBalanceTitle { get; set; }

        [Required]
        public string DateTimeTitle { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
