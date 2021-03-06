using Hotel_Management_System.Business_logic_layer;
using Hotel_Management_System.DataAccess_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Presentation_layer
{
    public partial class receptionist_registration : Form
    {
        public receptionist_registration(string uid)
        {
            InitializeComponent();
            label10.Text = uid;
            label10.Visible = false;
        }

        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        User u = new User();
        private void receptionist_registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                u.UserName = textBox1.Text;
                u.Password = textBox5.Text;

                u.Address = textBox4.Text;
                u.PhoneNumber = textBox3.Text;

                u.Email = textBox2.Text;
                u.Gender = comboBox1.Text;

                int i = da.CreateAccountrecep(u);
               /* if (i > 0)
                {
                    MessageBox.Show("Succesfully Created");
                }
                else
                {
                    MessageBox.Show("Error");
                }*/
                dt = da.Resepuid(u);
                if (dt.Rows.Count == 1)
                {
                    String uid= dt.Rows[0][0].ToString();
                    String prefix = "Rep-";
                    string username = String.Concat(prefix,uid);
                    u.UserId = uid.ToString();
                    u.Autoid = username.ToString();
                    int l = da.UserName(u);

                    if (l > 0)
                    {
                        MessageBox.Show("Succesfully Created please note down Username");
                    }
                    else
                    {
                        MessageBox.Show("Server Busy");
                    }

                    label7.Text = username.ToString();

                }
                else
                {
                    MessageBox.Show("Error in acc num");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerDashboard m = new ManagerDashboard(label10.Text);
        }
    }
}
