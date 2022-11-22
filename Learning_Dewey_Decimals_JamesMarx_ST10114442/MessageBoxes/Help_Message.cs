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
    public partial class Help_Message : Form
    {

        static Help_Message showMessage;
        static string buttonID;
        public Help_Message()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string ShowBox(string userHelpMessage)
        {
            showMessage = new Help_Message();

            showMessage.ShowDialog();
            return buttonID;
        }

        public static string ShowBox(string userHelpMessage, string controlTitle)
        {
            showMessage = new Help_Message();

            showMessage.ShowDialog();
            return buttonID;
        }
    }
}
