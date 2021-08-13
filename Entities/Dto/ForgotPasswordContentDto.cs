using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ForgotPasswordContentDto
    {
        public int Id { get; set; }

        public string PageTitle { get; set; }

        public string ContentTitle { get; set; }

        public string Description { get; set; }

        public string ButtonName { get; set; }

        public string SuccessMessageFirstSide { get; set; }

        public string SuccessMessageSecondSide { get; set; }

        public string SuccessMessageDescription { get; set; }

        public string Image { get; set; }
    }
}
