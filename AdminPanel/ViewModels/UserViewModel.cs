using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public int SerialNumber { get; set; }

        public string FinCode { get; set; }

        public DateTime BirthDay { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        public string Role { get; set; }
    }
}
