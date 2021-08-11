using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class LoginContentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string RememberMeLabel { get; set; }

        public string ForgotPasswordName { get; set; }

        public string ButtonName { get; set; }

        public string RegisterLinkName { get; set; }
    }
}
