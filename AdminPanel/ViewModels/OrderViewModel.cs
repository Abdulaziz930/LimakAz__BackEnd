using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }
    }
}
