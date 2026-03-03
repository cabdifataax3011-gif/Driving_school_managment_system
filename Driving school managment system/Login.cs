using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Driving_school_managment_system
{
    public partial class Login : Form
    {

        SqlConnection con = new SqlConnection(@"Server=.;Database=Driving; Integrated Security = true;");


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Users where Username=@user and Password=@pass", con);
                cmd.Parameters.AddWithValue("@user", txtuser.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Dash dash1 = new Dash();
                    dash1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtpassword.UseSystemPasswordChar == true)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fpassword fp = new Fpassword();
            fp.ShowDialog();
            

        }
    }
}
