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
    public partial class students : Form
    {
        SqlConnection con = new SqlConnection(@"server=.; Database=Driving; Integrated Security=true;");
        public students()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();

        }
        void clear()
        {
            txtaddress.Clear();
            txtname.Clear();
            txtemail.Clear();
            txtid.Clear();
            txtphone.Clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Students where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dleted successfuly");
                                
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
               con.Close(); 
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Students (Name,Email,Phone,Address,DOB) VALUES (@Name,@Email,@Phone,@Address,@DOB)", con);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Address",txtaddress.Text);
                    cmd.Parameters.AddWithValue("@DOB",dtDOB.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("save seccessfuly");
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Students set Name=@Name, Email=@Email, Phone=@Phone, Address=@Address, DOB=@DOB where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@DOB", dtDOB.Value);
                    cmd.Parameters.AddWithValue("@Id",txtid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated seccessfuly");
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Students where Id=@Id", con);
                   
                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtname.Text = dr[1].ToString();
                        txtemail.Text = dr[2].ToString();
                        txtphone.Text = dr[3].ToString();
                        txtaddress.Text = dr[4].ToString();
                        dtDOB.Text = dr[5].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No match found!");
                    }
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
    }
}
