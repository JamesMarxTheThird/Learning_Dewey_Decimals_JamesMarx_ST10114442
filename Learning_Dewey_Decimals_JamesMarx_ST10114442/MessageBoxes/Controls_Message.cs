using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442.MessageBoxes
{
    public partial class Controls_Message : Form
    {

        static Controls_Message showControls;
        static string buttonID;

        public Controls_Message()
        {
            InitializeComponent();
        }

        private void Controls_Message_Load(object sender, EventArgs e)
        {

        }

        public static string ShowBox(string userControlsMessage)
        {
            showControls = new Controls_Message();

            showControls.ShowDialog();
            return buttonID;
        }

        public static string ShowBox(string userControlsMessage, string controlTitle)
        {
            showControls = new Controls_Message();

            showControls.ShowDialog();
            return buttonID;
        }

        private void back2shelfBTN_Click(object sender, EventArgs e)
        {
            buttonID = "1";
            showControls.Dispose();
        }
    }
}
