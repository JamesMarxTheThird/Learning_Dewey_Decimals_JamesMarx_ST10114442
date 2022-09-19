using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes;


namespace Learning_Dewey_Decimals_JamesMarx_ST10114442
{


    public partial class Shelf_Order : Form
    {
        //----------------------------------------------\\

        //Global variables

        // A random object that is referenced to generate random numbers, letters and colours
        private static Random random = new Random(); 

        //Creating random colour variable
        private static Color randomClr;

        //Creating a text colour object 
        Color textColor = new Color();

        //String to hold the entire call number
        public static string fullCN;

        //public static string secondCN;
        //int GeneratedCNIndex = 0;
        //int GeneratedCNIndex2 = 0;

        //Variable that holds an integer that represents the books shown
        //It can be changed by the user on the interface
        public static int booksDisplayed = 10;

        //A boolean, defaulted to false that helps show or hide informational labels
        public bool BTNchecked;

        //List that initially stores the randomly generated call numbers in their given order
        public List<string> unsortedCallNumbers = new List<string>();

        //Other list that will store the call numbers generated in that session in the correct order
        public List<string> sortedCallNumbers = new List<string>();

        BasicUtilities BU = new BasicUtilities();

        //-----------------------------------------------------------------------\\

        public Shelf_Order()
        {

            //Running the methods that make up the applications logic
            InitializeComponent();
            display_book_shapes();
            display_call_numbers();
            hideLabels();

        }

        //-----------------------------------------------------------------------\\

        //-----------------------><=>==GENERAL-METHODS==<=><---------------------\\

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This method adds tiles to the list view
        /// Then A DrawTtem event triggers the 'listView1_DrawItem' method which sets text and back color of the drawn item
        /// This adds then adds those draw items to the tiles in the list view
        /// </summary>
        public void display_book_shapes()
        {
             
            randomCN_LV.View = View.Tile;
            randomCN_LV.Alignment = ListViewAlignment.Default;
            randomCN_LV.OwnerDraw = true;
            randomCN_LV.AllowDrop = true;
            randomCN_LV.DrawItem += listView1_DrawItem;
            randomCN_LV.TileSize = new Size(50,
            randomCN_LV.ClientSize.Height - (SystemInformation.HorizontalScrollBarHeight + 4));

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// 
        /// </summary>
        public void display_call_numbers()
        {

            BU.createRandomCallNumbers();

            foreach (string CNItem in BU.unsortedCallNumbers_BU)
            {
                randomCN_LV.Items.Add(CNItem);
            }

            /*
            //For loop that runs 10 tmies by default, and adds a new call number to the list view
            for (int i = 0; i < booksDisplayed; i++)
            {

                //Generates the first 3 digit number
                int generatedCN = random.Next(0, 1000);

                //Generates the second 3 digit number
                int generateddCNDecimal = random.Next(0, 1000);

                //Generates the 3 letters
                char randomChar = (char)random.Next('A', 'Z');
                char randomChar2 = (char)random.Next('A', 'Z');
                char randomChar3 = (char)random.Next('A', 'Z');

                //Putting the call number into one string
                fullCN = generatedCN.ToString() + "." + generateddCNDecimal.ToString() + "\n" + " " + randomChar + randomChar2 + randomChar3;

                //Adding the full call number to the list view
                randomCN_LV.Items.Add(fullCN);

                unsortedCallNumbers.Clear();
                unsortedCallNumbers.Add(fullCN);
                sortedCallNumbers.Add(fullCN);
                // top5_LV.Items.Add(fullCN);
                sortingCallNumbersASC();

                getSortedList();

            }
            */

        }

        //-----------------------------------------------------------------------\\

        //
        public void hideLabels()
        {
            leftLBL.Hide();
            rightLBL.Hide();
            amountLBL.Hide();
            resetLBL.Hide();
            resultsLBL.Hide();
            tickLBL.Hide();
            ezLBL.Hide();
            normalLBL.Hide();
            hardLBL.Hide();
            insaneLBL.Hide();
            escLabel.Hide();
            hintLBL.Show();
        }

        //-----------------------------------------------------------------------\\

        //
        public void showLabels()
        {
            leftLBL.Show();
            rightLBL.Show();
            amountLBL.Show();
            resetLBL.Show();
            resultsLBL.Show();
            tickLBL.Show();
            ezLBL.Show();
            normalLBL.Show();
            hardLBL.Show();
            insaneLBL.Show();
            escLabel.Show();
            hintLBL.Hide();
        }

        //-----------------------------------------------------------------------\\

        //-----------------------><=>==EVENT-HANDLERS==<=><----------------------\\

        //-----------------------------------------------------------------------\\

        /// <summary>
        ///This drawitem event handler creates and fills the rectangle thats specified in the LV_Attributes method
        ///Currently sets text to black and back color to red
        /// </summary>
        public void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            //
            try
            {
                
                e.Graphics.FillRectangle(Brushes.IndianRed, e.Bounds);

                textColor = Color.Black;
                //
                e.Graphics.DrawRectangle(Pens.Black, e.Bounds);

                //This pen property sets the various attributes of the text 
                TextRenderer.DrawText(e.Graphics, e.Item.Text, randomCN_LV.Font, e.Bounds,
                                      textColor, Color.Empty,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter); //
                /*
                foreach (ListViewItem LV1 in randomCN_LV.Items)
                {
                    Pen blackPen = new Pen(Color.Black, 3);
                    PointF point1 = new PointF(100.0F, 100.0F);
                    PointF point2 = new PointF(147.0F, 100.0F);
                   // Point p1 = new Point(10);
                   // Point p2 = new Point(190);

                    
                  // e.Graphics.DrawLine()

                    e.Graphics.DrawLine(blackPen, point1, point2);
                }
                */

                //Setting the brush property for out rectangle / book
                //e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);

                //Setting the color of the rectangle


                //Performing a color swap as a book is clicked on the shelf
                /*
                if ((e.State & ListViewItemStates.Focused) != 0)
                {

                     //This sets the textcolor of the call numbers to a completely random one 
                     //As its initially clicked on
                     randomClr = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                     textColor = randomClr;

                }
                else
                {
                    // e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    //Setting it back to default color 
                    textColor = Color.Black;
                }
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //-----------------------------------------------------------------------\\

        private void Call_Numbers_Load(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        //
        private void CN_HomeB_Click(object sender, EventArgs e)
        {
            //Hiding the current shelf order page
            this.Hide();
            Home_Form HF = new Home_Form();
            //Going back to home page
            HF.Show();
        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Arrow button that moves the selected book to the left one space
        /// This works by removing it, aswell as the item to the left of it (".Index - 1")
        /// Then inserts the initial item to the left, and the left item to the right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveCNLeft_Click(object sender, EventArgs e)
        {

            try
            {

                if (ListViewItemStates.Selected != 0)
                {

                    int CNIndex = randomCN_LV.SelectedItems[0].Index;
                    int CNIndexInfront = randomCN_LV.SelectedItems[0].Index - 1;
                    var item = randomCN_LV.Items[CNIndex];
                    var frontItem = randomCN_LV.Items[CNIndexInfront];

                    if (CNIndex >= 0)
                    {
                        randomCN_LV.Items.RemoveAt(CNIndex);
                        randomCN_LV.Items.RemoveAt(CNIndexInfront);
                        randomCN_LV.Items.Insert(CNIndex - 1, item);
                        randomCN_LV.Items.Insert(CNIndexInfront + 1, frontItem);
                    }

                }

            }

            //Catch error handling is commented out due to useability
            //If a promt shows up everytime a user misclicks or tries to move an item before selecting it
            //it becomes frustrating and repetitive. Disabling this keeps the flow going.
            catch (Exception Ex)
            {
               // MessageBox.Show(Ex.ToString());
            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Action button that moves the selected book to the right one space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void moveCnRight_Click(object sender, EventArgs e)
        {

            try
            {

                if (ListViewItemStates.Selected != 0)
                {
                    ListViewItem selectedLVItemPlusOne = randomCN_LV.SelectedItems[0];
                    int cnIndex2 = selectedLVItemPlusOne.Index + 1;
                    int CNIndex0 = selectedLVItemPlusOne.Index;
                    int total = randomCN_LV.Items.Count;
                    var frontItem0 = randomCN_LV.Items[CNIndex0];
                    var frontItem2 = randomCN_LV.Items[cnIndex2];


                    if (CNIndex0 == 0)
                    {
                        randomCN_LV.Items.RemoveAt(cnIndex2);
                        randomCN_LV.Items.RemoveAt(CNIndex0);
                        randomCN_LV.Items.Insert(cnIndex2 - 1, frontItem2);
                        randomCN_LV.Items.Insert(CNIndex0 + 1, frontItem0);

                    }
                    else
                    {
                        randomCN_LV.Items.RemoveAt(cnIndex2);
                        randomCN_LV.Items.RemoveAt(CNIndex0);
                        randomCN_LV.Items.Insert(cnIndex2 - 1, frontItem2);
                        randomCN_LV.Items.Insert(CNIndex0 + 1, frontItem0);

                    }

                }

            }
            catch (Exception Ex)
            {
               // MessageBox.Show(Ex.ToString());
            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This button toggles the informational labels from hidden to shown on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            

            if (BTNchecked != true)
            {
                showLabels();
                BTNchecked = true;
            }
            else
            {
                hideLabels();
                BTNchecked = false;                        
            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setGameModeBTN_Click(object sender, EventArgs e)
        {

            if (easyRB.Checked)
            {

            }
            else if (normalRB.Checked)
            {
                //resetGameBTN.PerformClick();
                booksDisplayed = 15;
            }
            else if (hardRB.Checked)
            {
                booksDisplayed = 20;
            }
            else if (insaneRB.Checked)
            {
                booksDisplayed = 20;
            }

        }

        //-----------------------------------------------------------------------\\

        private void normalRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        public void SplitAndSortMethod()
        {

            try
            {
                /*
                BU.unsortedCallNumbers_BU = BU.unsortedCallNumbers_BU
                .Select(x => x.Split(new char[] { '.' }))
                .Select(x =>
                    {
                        string[] lastParts = x[2].Split(new char[] { ' ' });
                        return new { a = Convert.ToInt32(x[0]), b = Convert.ToInt32(x[1]), c = lastParts[0] };
                    })
                    .OrderBy(x => x.a).ThenBy(x => x.b).ThenBy(x => x.c)
                    .Select(x => string.Format("{123}.{456} {A}{B}{C}", x.a, x.b, x.c))
                    .ToList();
                
                BU.unsortedCallNumbers_BU.Reverse();
                foreach (string str in BU.unsortedCallNumbers_BU)
                {
                    BU.sortedCallNumbers_BU.Add(str);
                    
                }
                
                foreach (string items in BU.unsortedCallNumbers_BU)
                {
                    string[] separator = new string[] { "." };
                    string[] separator2 = new string[] { " " };
                    var sortedItems = BU.unsortedCallNumbers_BU
                        .OrderByDescending(s => int.Parse(s.Split(separator, StringSplitOptions.None)[1]))
                        .OrderByDescending(s => int.Parse(s.Split(separator, StringSplitOptions.None)[0]))
                        .ToString();
                    listBox1.Items.Add(sortedItems);
                }
                */
                foreach (string items in BU.unsortedCallNumbers_BU)
                {
                    string awe = BU.unsortedCallNumbers_BU
                .OrderByDescending(v => string.Concat(v.Split('.').Select(x => x.PadLeft(3, '0'))))
                .ToString();

                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }




        }

        /// <summary>
        /// This button uses sorting methods to check if the call numbers are in apropriate order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkAnswersBTN_Click(object sender, EventArgs e)
        {

            //SortingAlgorithm SA = new SortingAlgorithm();
            SplitAndSortMethod();

            /*           
            randomCN_LV.Sort();
            sortedCallNumbers.Sort();
            if (randomCN_LV.Items.ToString() == sortedCallNumbers.ToString())
            {
                MessageBox.Show("awe poes");
            }
            else
            {
                MessageBox.Show("rahhhhhhhhhhhhhhhhhhhhh");
            }
            */

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Event handler to enable optional gameplay using keyboard input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shelf_Order_KeyDown(object sender, KeyEventArgs e)
        {
            //If the user wants to, the 'A' key will perform the same function as the left arrow button
            if (e.KeyCode == Keys.A)
            {
                moveCNLeft.PerformClick();
            }

            //The 'D' key will trigger the right arrow button
            else if (e.KeyCode == Keys.D)
            {
                moveCnRight.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                checkAnswersBTN.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                CN_HomeB.PerformClick();
            }

            if (e.KeyCode == Keys.F5)
            {
                resetGameBTN.PerformClick();
            }
        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This button restarts the game and adds new call numbers 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetGameBTN_Click(object sender, EventArgs e)
        {
            //Clearing the listview of the current books
            randomCN_LV.Clear();
            BU.unsortedCallNumbers_BU.Clear();

            //Reusing methods to randomly generate call numbers and draw books
            display_book_shapes();
            display_call_numbers();

        }


        //-----------------------------------------------------------------------\\

    }
}
