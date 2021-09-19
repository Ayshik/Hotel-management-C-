using Hotel_Management_System.Presentation_layer;
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


namespace Hotel_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        User em = new User();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        Boolean state = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("TextBox cannot be empty");
            }
            else
            {
                em.UserId =Convert.ToString(textBox1.Text);
                em.Password = textBox2.Text;



                {
                    if (state == false)
                    {
                        dt = da.LoginO(em);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            OwnerDashboard rr = new OwnerDashboard();
                            rr.Visible = true;
                            this.Visible = false;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }


                {
                    if (state == false)
                    {
                        dt = da.LoginM(em);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            ManagerDashboard rr = new ManagerDashboard(textBox1.Text);
                            rr.Visible = true;
                            this.Visible = false;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }



                {
                    if (state == false)
                    {
                        dt = da.LoginR(em);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Receptionistdashboard acc = new Receptionistdashboard(textBox1.Text);
                            this.Visible = false;
                            acc.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                    if (state == false)
                    {
                        MessageBox.Show("Invalid id or password");
                    }




                }






            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
