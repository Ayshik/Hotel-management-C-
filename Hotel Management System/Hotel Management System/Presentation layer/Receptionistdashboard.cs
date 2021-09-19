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
    public partial class Receptionistdashboard : Form
    {
        public Receptionistdashboard(string uid)
        {
            InitializeComponent();
            label2.Text = uid;
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        Transections t = new Transections();
        BookingandGuest bg = new BookingandGuest();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           Login  rr = new Login();
            rr.Visible = true;
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt = da.roomdetailsall(bg);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Roomselection rr = new Roomselection(label2.Text);
            rr.Visible = true;
            this.Visible = false;
        }

        private void Receptionistdashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt = da.guestdetailsall(bg);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = da.roombookinfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Payment rr = new Payment(label2.Text);
            rr.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = da.transectioninfo(t);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Release rr = new Release(label2.Text);
            rr.Visible = true;
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Boyassign rr = new Boyassign(label2.Text);
            rr.Visible = true;
            this.Visible = false;
        }
    }
}
