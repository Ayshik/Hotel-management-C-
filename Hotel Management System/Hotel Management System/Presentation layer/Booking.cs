using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_System.Business_logic_layer;
using Hotel_Management_System.DataAccess_layer;


namespace Hotel_Management_System.Presentation_layer
{
    public partial class Booking : Form
    {
        public Booking(string uid,string rid)
        {
            InitializeComponent();
            label7.Text = uid;
            label10.Text = rid;
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        BookingandGuest bg = new BookingandGuest();

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox2.Text == "" || textBoxUname.Text == "" || textBoxPass.Text == "" || comboBox1.Text == "" || textBoxEmail.Text == "" || textBoxMobile.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                bg.gname = textBoxUname.Text;
                bg.gphone = textBoxMobile.Text;
                bg.gaddress = textBoxPass.Text;
                bg.gemail = textBoxEmail.Text;
                bg.gnid = textBox1.Text;
                bg.gdob = dateTimePicker1.Text;
                bg.ggender = comboBox1.Text;
                bg.gpayment = textBox2.Text;
                bg.bookedby = label7.Text;
                    bg.groomno = label10.Text;
                    bg.totalpay= textBox2.Text;

                int i = da.roombooking(bg);
                 if (i > 0)
                 {
                     MessageBox.Show("Succesfully Booked");
                 }
                 else
                 {
                     MessageBox.Show("Server under maintanance");
                 }
               

            }
        }

        private void ownersignupback_Click(object sender, EventArgs e)
        {
            Roomselection rr = new Roomselection(label7.Text);
            rr.Visible = true;
            this.Visible = false;
        }
    }
    
}
