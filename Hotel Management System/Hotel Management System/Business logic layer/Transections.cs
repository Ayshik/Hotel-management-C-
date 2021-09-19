using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management_System.DataAccess_layer;

namespace Hotel_Management_System.Business_logic_layer
{
   public class Transections
    {

        DataAccess da = new DataAccess();

        public string guestname { get; set; }
        public string roomno { get; set; }
        public string roomtype { get; set; }
        public string previousamount { get; set; }
        public string newpay { get; set; }
        public string totalamount { get; set; }
        public string receivedby { get; set; }
        public string paymentdate { get; set; }
    }
}
