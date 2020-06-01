using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenMenuInterface.Models
{
    public class UserModel
    {
        public int UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeKey { get; set; }
        public int GroupKey { get; set; }
    }
}
