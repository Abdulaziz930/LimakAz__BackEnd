using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class QuestionContentDto
    {
        public int Id { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionHeaderTitle { get; set; }

        public string BreadcrumbPathname { get; set; }
    }
}
