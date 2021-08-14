using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ExpiredVerifyEmailToken : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
