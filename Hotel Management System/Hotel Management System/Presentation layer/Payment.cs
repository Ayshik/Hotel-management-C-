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
    public partial class Payment : Form
    {
        public Payment(string uid)
        {
            InitializeComponent();
            label14.Visible = false;
            label10.Text = uid;
        }

        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        Transections t = new Transections();
        BookingandGuest bg = new BookingandGuest();

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dt = da.roombookinfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = da.roombookinfo(bg);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg.groomno = textBox1.Text;

            dt = da.roomsearchforpayment(bg);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || label6.Text == "....." || label5.Text == "....." || label12.Text == ".....")
            {
                MessageBox.Show("Please select a Room For Payment");
            }
            else
            {
                int max = Convert.ToInt32(textBox2.Text);
                int min = Convert.ToInt32(label12.Text);
                int total = max + min;
                //label15.Text = total.ToString();

                if (textBox2.Text == "" || max <= '0')
                {
                    MessageBox.Show("Please Write an amount for pay");
                }
                else
                {
                    bg.gpayment = total.ToString();

                    bg.groomno = label14.Text;


                    int i = da.updatepayment(bg);
                    if (i > 0)
                    {

                        t.guestname = label5.Text;
                            t.roomno = label14.Text;
                        t.roomtype = label6.Text;
                        t.previousamount = label12.Text;
                        t.newpay = textBox2.Text;
                        t.totalamount = total.ToString();
                        t.receivedby = label10.Text;
                            
                        int v = da.transection(t);
                        MessageBox.Show("Payment done ");
                    }
                    else
                    {
                        MessageBox.Show("Server under maintanance");
                    }
                }



            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
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