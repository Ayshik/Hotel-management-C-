using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management_System.DataAccess_layer;


namespace Hotel_Management_System.Business_logic_layer
{
    public class BookingandGuest
    {
        DataAccess da = new DataAccess();

        public string roomtype { get; set; }
        public string roomprice { get; set; }
        public string roomstatus { get; set; }
        public string bookedby { get; set; }
        public string guestname { get; set; }
        public string totalpay { get; set; }
        public string bookeddate { get; set; }
        public string gname { get; set; }
        public string gphone { get; set; }
        public string gemail { get; set; }
        public string gaddress { get; set; }
        public string gnid { get; set; }
        public string gdob { get; set; }
        public string ggender { get; set; }
        public string gpayment { get; set; }
        public string groomno { get; set; }
        public string boyname { get; set; }




    }
}
