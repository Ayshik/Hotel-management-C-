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
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard(string uid)
        {
            InitializeComponent();
            label2.Text = uid;
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        BookingandGuest bg = new BookingandGuest();
        User u = new User();
        Transections t = new Transections();
        private void button8_Click(object sender, EventArgs e)
        {
            Login rr = new Login();
            rr.Visible = true;
            this.Visible = false;
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt = da.clintinfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt = da.roomdetailsall(bg);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = da.Receptonistinfo(u);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            receptionist_registration rr = new receptionist_registration(label2.Text);
            rr.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = da.transectioninfo(t);
            dataGridView1.DataSource = dt;
        }
    }
}
