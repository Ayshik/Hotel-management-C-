using Hotel_Management_System.DataAccess_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.Business_logic_layer
{
    public class User
    {
        DataAccess da = new DataAccess();

        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Autoid { get; set; }


    }
}
