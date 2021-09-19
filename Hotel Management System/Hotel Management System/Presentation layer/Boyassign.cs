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
    public partial class Boyassign : Form
    {
        public Boyassign(string uid)
        {
            InitializeComponent();
            label10.Text = uid;
            label14.Visible = false;
        }


        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        Transections t = new Transections();
        BookingandGuest bg = new BookingandGuest();


        private void Boyassign_Load(object sender, EventArgs e)
        {
            dt = da.boyassigninfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            label6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            label12.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            label14.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = da.boyassigninfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg.groomno = textBox1.Text;

            dt = da.roomsearchforpayment(bg);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label6.Text == "....." || label5.Text == "....." || label12.Text == ".....")
            {
                MessageBox.Show("Please select a Room For Assign");
            }
            else
            {



                bg.groomno = label14.Text;

                bg.boyname = textBox2.Text;

                int i = da.assignboy(bg);
                MessageBox.Show("Boy Assigned");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Receptionistdashboard rr = new Receptionistdashboard(label10.Text);
            rr.Visible = true;
            this.Visible = false;
        }
    }
}
