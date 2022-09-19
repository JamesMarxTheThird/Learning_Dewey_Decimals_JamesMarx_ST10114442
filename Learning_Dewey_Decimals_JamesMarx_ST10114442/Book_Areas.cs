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
    public partial class Book_Areas : Form
    {
        public Book_Areas()
        {
            InitializeComponent();
        }

        private void Book_Areas_Load(object sender, EventArgs e)
        {

        }

        private void BA_HomeB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Form HF = new Home_Form();
            HF.Show();
        }
    }
}
