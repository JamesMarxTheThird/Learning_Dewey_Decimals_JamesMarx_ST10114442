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
    public partial class Replacing_Books : Form
    {

        int GeneratedLBIndex = 0;
        int MovedLBIndex = 0;
        int first5LBIndex = 0;
        private static Random random = new Random();
        public static String fullCN;
        public Replacing_Books()
        {
            InitializeComponent();
            generateCallNumbers();
            //string[] callNumbers = new string[] { "115", "221", "400", "700" , "355", "650", "886", "908"};
            //RandomBookNumbersLB.Items.AddRange(callNumbers);
            //RandomBookNumbersLB
        }

        //-----------------------------------------------------------------------\\

        private void Shelf_Order_Load(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Form HF = new Home_Form();
            HF.Show();
        }

        //-----------------------------------------------------------------------\\

        private void LV_attributes()
        {
            //RandomBookNumbersLB.Lef
            //RandomBookNumbersLB.DrawItem += RandomBookNumbersLB_DrawItem;
        }

        //-----------------------------------------------------------------------\\

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        public static void RandomString()
        {
            
        }

        //-----------------------------------------------------------------------\\

        private void generateCallNumbers()
        {

            for (int i = 0; i < 10; i++)
            {
                int generatedCN = random.Next(0, 1000);

                int generateddCNDecimal = random.Next(0, 1000);

                char randomChar = (char)random.Next('A', 'Z');
                char randomChar2 = (char)random.Next('A', 'Z');
                char randomChar3 = (char)random.Next('A', 'Z');

                //string generatedInitials = random.NextBytes(A, Z)



                fullCN = generatedCN.ToString() + "." + generateddCNDecimal.ToString() + " " + randomChar + randomChar2 + randomChar3;
                RandomBookNumbersLB.Items.Add(fullCN);
            }

        }

        //-----------------------------------------------------------------------\\

        private void RandomBookNumbersLB_MouseDown(object sender, MouseEventArgs e)
        {

            try
            {
                
                ListBox NewLB = sender as ListBox;        
                GeneratedLBIndex = NewLB.IndexFromPoint(e.X, e.Y);
                if (GeneratedLBIndex >= 0 & e.Button == MouseButtons.Left)
                {
                    NewLB.DoDragDrop(NewLB.Items[GeneratedLBIndex].ToString(), DragDropEffects.Move);
                    NewLB.Items.RemoveAt(GeneratedLBIndex);

                    string currentCN = NewLB.Items[GeneratedLBIndex].ToString();

                    /*
                    if (NewLB.Items.Contains(fullCN))
                    {
                        MessageBox.Show("awe");
                    }
                    else
                    {
                        
                    }
                    */
                    
                }


            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }


        }

        //-----------------------------------------------------------------------\\

        private void bookOrderASC_DragEnter(object sender, DragEventArgs e)
        {

            try
            {

                if (e.Data.GetDataPresent(typeof(System.String)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //-----------------------------------------------------------------------\\

        private void bookOrderASC_DragDrop(object sender, DragEventArgs e)
        {

            try
            {

                ListBox NewLB2 = sender as ListBox;
                NewLB2.Items.Add(e.Data.GetData(typeof(System.String)).ToString());
                // bookOrderASC.Items.RemoveAt(MovedLBIndex);
                

            }

            catch (Exception ex)
            {
                
            }

        }

        //-----------------------------------------------------------------------\\



        



        //-----------------------------------------------------------------------\\

        private void button1_Click(object sender, EventArgs e)
        {

            RandomBookNumbersLB.Items.Clear();
            bookOrderASC.Items.Clear();
            generateCallNumbers();

        }

        //-----------------------------------------------------------------------\\

        private void bookOrderASC_MouseDown(object sender, MouseEventArgs e)
        {

            try
            {

                ListBox NewLB3 = sender as ListBox;
                MovedLBIndex = NewLB3.IndexFromPoint(e.X, e.Y);
                if (MovedLBIndex >= 0 & e.Button == MouseButtons.Left)
                    NewLB3.DoDragDrop(NewLB3.Items[MovedLBIndex].ToString(), DragDropEffects.Move);
                NewLB3.Items.RemoveAt(MovedLBIndex);
                /*
                if (NewLB3.Items.Contains(fullCN))
                {
                        
                }
                else
                {

                }
                */


            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }

        private void RandomBookNumbersLB_DragEnter(object sender, DragEventArgs e)
        {

            try
            {

                if (e.Data.GetDataPresent(typeof(System.String)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void RandomBookNumbersLB_DragDrop(object sender, DragEventArgs e)
        {

            try
            {

                ListBox NewLB4 = sender as ListBox;
                NewLB4.Items.Add(e.Data.GetData(typeof(System.String)).ToString());
                //bookOrderASC.Items.RemoveAt(GeneratedLBIndex);

            }

            catch (Exception ex)
            {

            }

        }

        private void blueHelpIcon_Click(object sender, EventArgs e)
        {

            MessageBox.Show("hi");

        }

        private void bookOrderASC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

    }
}
