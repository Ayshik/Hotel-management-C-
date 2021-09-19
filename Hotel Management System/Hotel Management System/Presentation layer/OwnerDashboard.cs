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
    public partial class OwnerDashboard : Form
    {
        public OwnerDashboard()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        BookingandGuest bg = new BookingandGuest();
        User u = new User();
        Transections t = new Transections();

        private void OwnerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt = da.Managerinfo(u);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt = da.Receptonistinfo(u);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = da.transectioninfo(t);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Visible = false;
            l.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Managersignup l = new Managersignup();
            this.Visible = false;
            l.Visible = true;
        }
    }
}
