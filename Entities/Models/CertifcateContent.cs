using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class CertifcateContent : IEntity
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
