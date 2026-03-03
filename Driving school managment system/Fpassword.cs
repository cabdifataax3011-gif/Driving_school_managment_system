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
using System.Data.Sql;


namespace Driving_school_managment_system
{
    public partial class Fpassword : Form
    {
            SqlConnection con = new SqlConnection(@"Server=.;Database=Driving; Integrated Security = true;");
        public Fpassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where Username=@Username and Email=@Email and Fullname=@Fullname", con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);

            SqlDataReader dr = cmd.ExecuteReader(); 
            try
            {   
                
                if (dr.Read())
                {
                    MessageBox.Show("varified");
                    groupBox2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid username, email or fullname.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                dr.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtnewpasswor.Text == txtconpassword.Text)
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("Update Users set Password=@Password from Users where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtconpassword.Text);
                

               
                try
                {
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("password reseted");
                               
                    this.Close();
                    
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
            else
            {
                MessageBox.Show("Password does not match.");
            }
        }

        private void Fpassword_Load(object sender, EventArgs e)
        {

        }
    }
}
