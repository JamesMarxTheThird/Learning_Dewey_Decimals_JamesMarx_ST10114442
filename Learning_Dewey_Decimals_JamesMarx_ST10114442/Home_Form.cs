using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442
{
    public partial class Home_Form : Form
    {

        //-----------------------------------------------------------------------\\

        public Home_Form()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------\\

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        private void callNumbersBTN_Click(object sender, EventArgs e)
        {

           // MessageBox.Show("Feature is coming soon!");

            
            this.Hide();
            Shelf_Order CN = new Shelf_Order();
            CN.Show();
            
        }

        //-----------------------------------------------------------------------\\

        private void shelfOrderBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature is coming soon!");
            /*
            this.Hide();
            Replacing_Books SO = new Replacing_Books();
            SO.Show();
            */
        }

        //-----------------------------------------------------------------------\\

        private void bookAreasBTN_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Feature is coming soon!");

            /*
            this.Hide();
            Book_Areas BA = new Book_Areas();
            BA.Show();
            */
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mcpl.info/childrens/how-use-dewey-decimal-system");
        }

        private void posterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flickr.com/photos/appletonmaggie/5907672591");
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\
    }
}
