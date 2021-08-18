using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class UserDto
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Surname { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int SerialNumber { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime BirthDay { get; set; }

        public string Gender { get; set; }

        [Required]
        public string FinCode { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
