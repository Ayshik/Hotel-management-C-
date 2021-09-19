using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Hotel_Management_System.Business_logic_layer;

namespace Hotel_Management_System.DataAccess_layer
{

    public class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=AYSH-STAR;Initial Catalog=HotelMS;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }



        public int CreateAccountrecep(User u)
        {
            int i = 0;
            string query = "INSERT INTO RecepLogin(Name,Password,Email,Phone,Address,Gender,AssignDate) VALUES ('" + u.UserName + "','" + u.Password + "','" + u.Email + "','" + u.PhoneNumber + "','" + u.Address + "','" + u.Gender + "','" + DateTime.Now + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }

        public int UserName(User u)
        {
            int i = 0;
            string query = "UPDATE RecepLogin SET UserName='" + u.Autoid + "' WHERE Id='" + u.UserId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }



        public DataTable Resepuid(User u)
        {
            string query = string.Format("SELECT  Id FROM RecepLogin where  Name='" + u.UserName + "' and Phone='" + u.PhoneNumber + "' and Address= '" + u.Address + "' and Email='" + u.Email + "' and Gender='" + u.Gender + "' and Password='" + u.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable LoginR(User e)
        {
            string query = string.Format("Select * from RecepLogin where UserName= '" + e.UserId + "' and Password='" + e.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable LoginM(User e)
        {
            string query = string.Format("Select * from ManLogin where UserName= '" + e.UserId + "' and Password='" + e.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;
        }



        public DataTable LoginO(User e)
        {
            string query = string.Format("Select * from OwnerLogin where UserName= '" + e.UserId + "' and Password='" + e.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;
        }



        public DataTable roomdetailsall(BookingandGuest bg)
        {
            string query = string.Format("Select Sl,Roomno,Roomtype,RoomPrice from RoomBooking ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable roomfree(BookingandGuest bg)
        {
            string query = string.Format("Select Sl,Roomno,Roomtype,RoomPrice from RoomBooking where Roomstatus='Free'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable roomsearch(BookingandGuest bg)
        {
            string query = string.Format("Select Sl,Roomno,Roomtype,RoomPrice from RoomBooking where Roomtype='" + bg.roomtype + "' and Roomstatus='Free'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }



        public int roombooking(BookingandGuest bg)
        {
            int i = 0;
            int j = 0;
            string query = "INSERT INTO Guestinfo(Name,Phone,Address,Email,Nid,Dob,Gender,Payment,Roomno,Bookedby,Time) VALUES ('" + bg.gname + "','" + bg.gphone + "','" + bg.gaddress + "','" + bg.gemail + "','" + bg.gnid + "','" + bg.gdob + "','" + bg.ggender + "','" + bg.gpayment + "','" + bg.groomno + "','" + bg.bookedby + "','" + DateTime.Now + "')";
            string query2 = "UPDATE RoomBooking SET Roomstatus='Booked',Bookedby='" + bg.bookedby + "',Bookedfor='" + bg.gname + "',Totalpay='" + bg.totalpay + "',Bookeddate='" + DateTime.Now + "',Boy='Not Assigned' WHERE Roomno='" + bg.groomno + "'";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            i = cmd.ExecuteNonQuery();
            j = cmd2.ExecuteNonQuery();
            //con.Close();
            return i;

            
        }

        public DataTable guestdetailsall(BookingandGuest bg)
        {
            string query = string.Format("Select Name,Phone,Address,Email,Nid,Dob,Gender,Time from Guestinfo ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable roombookinfo(BookingandGuest bg)
        {
            string query = string.Format("Select * from RoomBooking where Roomstatus='Booked' ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable roomsearchforpayment(BookingandGuest bg)
        {
            string query = string.Format("Select * from RoomBooking where Roomno='" + bg.groomno + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }



        public int updatepayment(BookingandGuest bg)
        {
            int i = 0;
            int j = 0;
            string query = "UPDATE Guestinfo SET Payment='" + bg.gpayment + "' WHERE Roomno='" + bg.groomno + "'";
            string query2 = "UPDATE RoomBooking SET Totalpay='" + bg.gpayment + "' WHERE Roomno='" + bg.groomno + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            i = cmd.ExecuteNonQuery();
            j = cmd2.ExecuteNonQuery();
            //con.Close();
            return i;


        }

        public int transection(Transections u)
        {
            int i = 0;
            string query = "INSERT INTO transectios(GuestName,RoomNo,Roomtype,Previousamount,Newpay,Totalamount,Receivedby,Paymentdate) VALUES ('" + u.guestname + "','" + u.roomno + "','" + u.roomtype + "','" + u.previousamount + "','" + u.newpay + "','" + u.totalamount + "','" + u.receivedby + "','" + DateTime.Now + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }



        public DataTable transectioninfo(Transections t)
        {
            string query = string.Format("Select * from transectios");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }



        public int release(BookingandGuest bg)
        {
            int i = 0;
            string query = "UPDATE RoomBooking SET Roomstatus='Free' WHERE Roomno='" + bg.groomno + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }




        public DataTable boyassigninfo(BookingandGuest bg)
        {
            string query = string.Format("Select * from RoomBooking where Boy='Not Assigned' ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }



        public int assignboy(BookingandGuest bg)
        {
            int i = 0;
            string query = "UPDATE RoomBooking SET Boy='" + bg.boyname + "' WHERE Roomno='" + bg.groomno + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }


        public DataTable clintinfo(BookingandGuest bg)
        {
            string query = string.Format("Select * from RoomBooking where Roomstatus='Booked' order by Sl DESC ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable Receptonistinfo(User bg)
        {
            string query = string.Format("Select * from RecepLogin ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public DataTable Managerinfo(User bg)
        {
            string query = string.Format("Select * from ManLogin ");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }



        public int CreateAccountman(User u)
        {
            int i = 0;
            string query = "INSERT INTO ManLogin(Name,Password,Email,Phone,Address,Gender,AssignDate) VALUES ('" + u.UserName + "','" + u.Password + "','" + u.Email + "','" + u.PhoneNumber + "','" + u.Address + "','" + u.Gender + "','" + DateTime.Now + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }

        public int UserNameman(User u)
        {
            int i = 0;
            string query = "UPDATE ManLogin SET UserName='" + u.Autoid + "' WHERE Id='" + u.UserId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }

        public DataTable Manuid(User u)
        {
            string query = string.Format("SELECT  Id FROM ManLogin where  Name='" + u.UserName + "' and Phone='" + u.PhoneNumber + "' and Address= '" + u.Address + "' and Email='" + u.Email + "' and Gender='" + u.Gender + "' and Password='" + u.Password + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


    }

}