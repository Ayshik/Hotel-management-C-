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
    public partial class Roomselection : Form
    {
        public Roomselection(string uid)
        {
            InitializeComponent();
            label10.Text = uid;
        }

        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        User u = new User();
        BookingandGuest bg = new BookingandGuest();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Roomselection_Load(object sender, EventArgs e)
        {
            
            dt = da.roomfree(bg);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bg.roomtype= comboBox2.Text;

            dt = da.roomsearch(bg);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = da.roomfree(bg);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            label6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label6.Text == "....."|| label6.Text == "")
            {
                MessageBox.Show("Please Select A room First");
            
            }

            else
            {
                Booking rr = new Booking(label10.Text,label6.Text);
                rr.Visible = true;
                this.Visible = false;

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
