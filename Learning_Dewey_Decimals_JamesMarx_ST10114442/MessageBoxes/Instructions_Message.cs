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
    public partial class Instructions_Message : Form
    {

        static Instructions_Message showInstructions;
        static string instructionsButtonID;
        public Instructions_Message()
        {
            InitializeComponent();
        }

        private void Instructions_Message_Load(object sender, EventArgs e)
        {

        }

        public static string ShowBox(string userControlsMessage)
        {
            showInstructions = new Instructions_Message();

            showInstructions.ShowDialog();
            return instructionsButtonID;
        }

        public static string ShowBox(string userControlsMessage, string controlTitle)
        {
            showInstructions = new Instructions_Message();

            showInstructions.ShowDialog();
            return instructionsButtonID;
        }




        private void backtoShelfBTN_Click(object sender, EventArgs e)
        {
            instructionsButtonID = "1";
            showInstructions.Dispose();
        }
    }
}
