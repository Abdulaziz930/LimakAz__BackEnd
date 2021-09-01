using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public string UserName { get; set; }
    }
}
