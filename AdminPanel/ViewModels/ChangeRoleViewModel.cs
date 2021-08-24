using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; }
    }
}
