using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenMenuInterface.Models
{
    public class OrderEditModel
    {
        public int OrderKey { get; set; }
        public int MenuKey { get; set; }
        public string Comment { get; set; }
    }
}
