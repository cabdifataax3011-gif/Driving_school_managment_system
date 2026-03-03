using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_school_managment_system
{
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }
        void moveIt(object sender)
        {
            panel10.Top = ((Button)sender).Top;
            panel10.Height = ((Button)sender).Height;

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashbourd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            moveIt(sender);
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            moveIt(sender);
        }

        private void btnIntructors_Click(object sender, EventArgs e)
        {
            moveIt(sender);
        }

        private void btncourses_Click(object sender, EventArgs e)
        {
            moveIt(sender);
        }

        private void btnExrollments_Click(object sender, EventArgs e)
        {
            moveIt(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
