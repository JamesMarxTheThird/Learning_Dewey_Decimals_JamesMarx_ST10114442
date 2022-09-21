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
using Learning_Dewey_Decimals_JamesMarx_ST10114442.MessageBoxes;


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

        //Making gloabl objects of the other forms
        BasicUtilities BU = new BasicUtilities();
        Controls_Message CM = new Controls_Message();
        Instructions_Message IM = new Instructions_Message();

        public static int timerCount = 0;

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
            randomCN_LV.Alignment = ListViewAlignment.Left;
            randomCN_LV.OwnerDraw = true;
            randomCN_LV.AllowDrop = true;
            randomCN_LV.DrawItem += listView1_DrawItem;
            randomCN_LV.TileSize = new Size(50,
            randomCN_LV.ClientSize.Height - (SystemInformation.HorizontalScrollBarHeight + 4));

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This method adds the call numbers for the normal game mode into our list view and list
        /// </summary>
        public void display_call_numbers()
        {

            //Calling 10 random call numbers
            BU.createRandomCallNumbers();

            foreach (string CNItem in BU.unsortedCallNumbers_BU)
            {
                //Adding to the 'Shelf' or listview
                randomCN_LV.Items.Add(CNItem);
            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This method adds the call numbers for the intermediate game mode into our list view and list
        /// </summary>
        public void display_intermediate_call_numbers()
        {

            //Calling 10 random, intermediate mode call nunmbers : the same first, second and fourth digit
            BU.intermediateMode();

            //Loop to display call numbers in intermediate mode
            foreach (string CNItem in BU.unsortedCallNumbers_BU)
            {
                randomCN_LV.Items.Add(CNItem);
            }
        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This method adds the call numbers for the advanced game mode into our list view and list
        /// </summary>
        public void display_advanced_call_numbers()
        {
            //Calling 13 random, advanced mode call nunmbers : the same first, fourth, seventhg and eighth digits
            BU.advancedMode();

            //Loop to display call numbers in advanced mode
            foreach (string CNItem in BU.unsortedCallNumbers_BU)
            {
                randomCN_LV.Items.Add(CNItem);
            }
        }

        //Toggle hint labels off
        public void hideLabels()
        {
            leftLBL.Hide();
            rightLBL.Hide();
            amountLBL.Hide();
            resetLBL.Hide();
            resultsLBL.Hide();
            tickLBL.Hide();
            escLabel.Hide();
            timerLabel.Hide();
            hintLBL.Show();
        }

        //-----------------------------------------------------------------------\\

        //Toggle hint labels on
        public void showLabels()
        {
            leftLBL.Show();
            rightLBL.Show();
            amountLBL.Show();
            resetLBL.Show();
            resultsLBL.Show();
            tickLBL.Show();
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //-----------------------------------------------------------------------\\

        //
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
                //MessageBox.Show("Please note the game is fully playable through mouse input, but various keyboard controlls can be used\nindicated by the '[]' in the hint labels. ");
            }
            else
            {
                hideLabels();
                BTNchecked = false;
            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This button checks which game modes is selected, and sets the game conditions based off the mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setGameModeBTN_Click(object sender, EventArgs e)
        {

            //Normal game mode
            if (normalRB.Checked)
            {

                BasicUtilities.booksDisplayed_BU = 10;

                //Completely random call numbers
                resetGameBTN.PerformClick();
                countDown.Stop();
                timerLabel.Hide();

            }

            //Intermediate game mode
            else if (hardRB.Checked)
            {

                BasicUtilities.booksDisplayed_BU = 10;

                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();

                //Call numbers with the same first, second and fourth digit
                display_intermediate_call_numbers();

                //Displaying the label with the timer, setting the time to 30s and starting it
                timerLabel.Show();
                timerCount = 40;
                countDown.Start();
                

            }
            else if (insaneRB.Checked)
            {

                BasicUtilities.booksDisplayed_BU = 13;

                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();

                //Call numbers with the same first, fourth, seventhg and eighth digits
                display_advanced_call_numbers();

                //Displaying the label with the timer, setting the time to 20s and starting it
                timerLabel.Show();
                timerCount = 25;
                countDown.Start();

            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Ascendingly Ordering the list of call numbers then comparing that sequence to the users sequence once check button has been clicked
        /// This compares strings with the format {1}{2}{3}.{4}{5}{6} {A}{B}{C}, and will sort them based on all digits and letters in the string
        /// </summary>
        public void OrderByAndCompare()
        {

            try
            {

                //This loop iterates depending on the amount of books in our listview
                foreach (ListViewItem unsortedCallNumbers in randomCN_LV.Items)
                {

                    //Our alterante list adds the listview item upon iteration.
                    //Listview item is converted to a text value using linq and inputs it to list
                    BU.sortedCallNumbers_BU = randomCN_LV.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();

                }

                //Using Linq to create a Var that represents a list of the call numbers in Ascending order
                //Var is the perfect element to incoporate linq, which can then be used to compare the users sequence to the correct one
                var sortedCN_ASC = BU.unsortedCallNumbers_BU.OrderBy(x => x);
                //Considering "OrderBy causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order."
                //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/orderby-clause
                //We can easily compare the sequence of our call number list to the sequence set on the ListView by clicking the check button

                //If the list of values in an order specified by the user has the same sequence as the ascending list ordered above the message below will show
                if (BU.sortedCallNumbers_BU.SequenceEqual(sortedCN_ASC))
                {
                    countDown.Stop();
                    
                    MessageBox.Show("Well done! you've sorted the call numbers " + "\nConsider the other game modes or more Information on the Home Page!");
                    
                }

                //Error message for the user
                else
                {
                    MessageBox.Show("The books are not in the correct order! \nFeel free to reset the game or play another game mode");
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
            OrderByAndCompare();
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

            /*
            if (e.KeyCode == Keys.Enter)
            {
                checkAnswersBTN.PerformClick();
            }
            */

            //Escape button takes user back to the home screen
            if (e.KeyCode == Keys.Escape)
            {
                CN_HomeB.PerformClick();
            }

            //F5 key refresehes the game with new numbers based on the game mode selected
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
                
            if (normalRB.Checked)
            {
                BasicUtilities.booksDisplayed_BU = 10;

                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();
                display_call_numbers();
            }

            else if (hardRB.Checked)
            {
                BasicUtilities.booksDisplayed_BU = 10;

                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();

                //Call numbers with the same first, second and fourth digit
                display_intermediate_call_numbers();

                //Displaying the label with the timer, setting the time to 30s and starting it
                timerLabel.Show();
                timerCount = 30;
                countDown.Start();

            }

            else if (insaneRB.Checked)
            {
                BasicUtilities.booksDisplayed_BU = 13;

                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();

                //Call numbers with the same first, fourth, seventhg and eighth digits
                display_advanced_call_numbers();

                //Displaying the label with the timer, setting the time to 20s and starting it
                timerLabel.Show();
                timerCount = 20;
                countDown.Start();

            }
            else
            {

                BasicUtilities.booksDisplayed_BU = 10;
                //Clearing the listview of the current books
                randomCN_LV.Clear();
                BU.unsortedCallNumbers_BU.Clear();

                //Reusing methods to randomly generate call numbers and draw books
                display_book_shapes();
                display_call_numbers();

            }          

        }

        /// <summary>
        /// This button brings us a custom message box exaplning all background information about this game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void whatToDoBTN_Click(object sender, EventArgs e)
        {
            string message = Instructions_Message.ShowBox("Custom MessageBox ?", " New Message Box");
            if (message.Equals("1"))
            {
                IM.Hide();
            }

        }

        /// <summary>
        /// This button brings us a custom message box showing the user the controls to play the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void how2PlayBTN_Click(object sender, EventArgs e)
        {         

            string message = Controls_Message.ShowBox("Custom MessageBox ?", " New Message Box");
            if (message.Equals("1"))
            {
                CM.Hide();
            }
        }

        /// <summary>
        /// Sets the label text to the correct time per tick, based on the interval of 1000ms (1s) set in the properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countDown_Tick(object sender, EventArgs e)
        {

            //Setting the label text to the current time
            timerLabel.Text = "Time left: " + timerCount--.ToString();

            //Allowing the user to restart if they don't make the count down
            if (timerCount < 0)
            {
                countDown.Stop();
                MessageBox.Show("You ran out of time before sorting the books!");
                resetGameBTN.PerformClick();

            }
            if (timerCount == 10)
            {

            }
        }
    }
}
