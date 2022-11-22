using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes;
using Learning_Dewey_Decimals_JamesMarx_ST10114442.MessageBoxes;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442
{
    public partial class Book_Areas : Form
    {

        //-----------------------------------------------------------------------\\
        //Global variables 

        public Point possieStart;
        public Point possieEnd;

        Pen p;

        public List<String> chosenDesc = new List<string>(); //The label selected (right side) gets added to this list so the program can eventually match them
        public bool resetPage;
        public Pen r;
        public Home_Form HF = new Home_Form();

        Help_Message HM = new Help_Message();

        public BookAreas BA_Class = new BookAreas(); // Please check the BookAreas class for more code relating to this page

        public List<String> chosenCNs = new List<string>(); //The label selected (left side) gets added to this list so the program can eventually match them

        public static List<int> randomIndexNumber = new List<int>();
        public static Dictionary<string, string> callNumberMatch = new Dictionary<string, string>();

        public string itemSelected;

        public int sideChoice;

        //Setting the coount down time of our timer
        public static int timerCount = 40;

        //Variables that will hold the random index, of our random list
        public static int aRnd;
        public static int bRnd;
        public static int cRnd;
        public static int dRnd;
        public static int eRnd;
        public static int fRnd;
        public static int gRnd;

        //-----------------------------------------------------------------------\\

        public Book_Areas()
        {
            InitializeComponent();
           
        }

        //-----------------------------------------------------------------------\\



        private void Book_Areas_Load(object sender, EventArgs e)
        {
            hideLabels();
            countDownLBL.Hide();
            //mainPanel.BringToFront();
        }

        //-----------------------------------------------------------------------\\

        public void mainPanel_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
           
        }

        //-----------------------------------------------------------------------\\

        //Methods to help easily hide, show, enable or disable the labels used to display the dictionary items

        public void enableLabels()
        {
            heading1LBL.Enabled = true;
            heading2LBL.Enabled = true;
            heading3LBL.Enabled = true;
            heading4LBL.Enabled = true;

            desc1LBL.Enabled = true;
            desc2LBL.Enabled = true;
            desc3LBL.Enabled = true;
            desc4LBL.Enabled = true;
            desc5LBL.Enabled = true;
            desc6LBL.Enabled = true;
            desc7LBL.Enabled = true;
        }

        public void disableLabels()
        {
            heading1LBL.Enabled = false;
            heading2LBL.Enabled = false;
            heading3LBL.Enabled = false;
            heading4LBL.Enabled = false;

            desc1LBL.Enabled = false;
            desc2LBL.Enabled = false;
            desc3LBL.Enabled = false;
            desc4LBL.Enabled = false;
            desc5LBL.Enabled = false;
            desc6LBL.Enabled = false;
            desc7LBL.Enabled = false;
        }

        public void showLabels()
        {
            heading1LBL.Show();
            heading2LBL.Show();
            heading3LBL.Show();
            heading4LBL.Show();

            desc1LBL.Show();
            desc2LBL.Show();
            desc3LBL.Show();
            desc4LBL.Show();
            desc5LBL.Show();
            desc6LBL.Show();
            desc7LBL.Show();

            quickInstrLBL.Hide();
        }

        public void hideLabels()
        {
            heading1LBL.Hide();
            heading2LBL.Hide();
            heading3LBL.Hide();
            heading4LBL.Hide();

            desc1LBL.Hide();
            desc2LBL.Hide();
            desc3LBL.Hide();
            desc4LBL.Hide();
            desc5LBL.Hide();
            desc6LBL.Hide();
            desc7LBL.Hide();

            quickInstrLBL.Show();
        }

        //-----------------------------------------------------------------------\\

        //-----------------------><=>==EVENT-HANDLERS==<=><----------------------\\

        //-----------------------------------------------------------------------\\

        //Return home button 
        private void BA_HomeB_Click(object sender, EventArgs e)
        {
            this.Hide();      
            Home_Form HF = new Home_Form();
            HF.Show();
        }

        //-----------------------------------------------------------------------\\

        //This method was origionally going to be a reset and start was seperate
        //but to avoid confusion I just made the start, reset aswell
        //NOTE: I tried my absolute best to implement an undo button.
        //Although it worked, by drawing over existing ones with the bg color,
        //it only worked if you draw the lines on the form, not a panel, creating many many other issues including just refreshing them
        //But I can always show you the code if you like
        private void resetButton_Click(object sender, EventArgs e)
        {
            
            startGameButton.PerformClick();
        }

        //-----------------------------------------------------------------------\\

        //The heading mouse clicks I set my start points and grab the randomly generated, randomly placed value
        private void heading1LBL_MouseClick(object sender, MouseEventArgs e)
        {

            //Here I add make the starting position the label X and Y location
                possieStart = new Point(heading1LBL.Location.X, heading1LBL.Location.Y);
                chosenCNs.Add(heading1LBL.Text);

            
            //I disable the labels so they can't be selected for two items
            heading1LBL.Enabled = false;
        }

        private void heading2LBL_MouseClick(object sender, MouseEventArgs e)
        {

            possieStart = new Point(heading2LBL.Location.X, heading2LBL.Location.Y);
            chosenCNs.Add(heading2LBL.Text);
            //leftSideValues.Add(heading1LBL.Text);
            heading2LBL.Enabled = false;
        }

        private void heading3LBL_MouseClick(object sender, MouseEventArgs e)
        {

            possieStart = new Point(heading3LBL.Location.X, heading3LBL.Location.Y);
            chosenCNs.Add(heading3LBL.Text);
            //leftSideValues.Add(heading1LBL.Text);
            heading3LBL.Enabled = false;
        }

        private void heading4LBL_MouseClick(object sender, MouseEventArgs e)
        {


            possieStart = new Point(heading4LBL.Location.X, heading4LBL.Location.Y);
            chosenCNs.Add(heading4LBL.Text);
            //leftSideValues.Add(heading1LBL.Text);
            heading4LBL.Enabled = false;
            //disableLabels();
        }

        //This method gets the line end point and draws the line
        private void desc1LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc1LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                //This method get
                desc1LBL.Enabled = false;
                //Setting our line endpoint
                possieEnd = new Point(desc1LBL.Location.X, desc1LBL.Location.Y);

                //Setting our line colour
                p = new Pen(Color.Purple);
                p.Width = 3;

                //Adding progress to our progress bar
                gameProgress.PerformStep();

                //Adding selected label value to a list
                chosenDesc.Add(desc1LBL.Text);

                //Drawing the line with the selected start and end
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }


                //Disabling the labels if the user has matched 4
                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }

            }

        }

        private void desc2LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc2LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc2LBL.Enabled = false;
                possieEnd = new Point(desc2LBL.Location.X, desc2LBL.Location.Y);
                p = new Pen(Color.MediumPurple);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc2LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }
                


                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }

            }
        }

        private void desc3LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc3LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc3LBL.Enabled = false;
                possieEnd = new Point(desc3LBL.Location.X, desc3LBL.Location.Y);
                p = new Pen(Color.Navy);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc3LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }

                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }
            }
        }

        private void desc4LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc4LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc4LBL.Enabled = false;
                possieEnd = new Point(desc4LBL.Location.X, desc4LBL.Location.Y);
                p = new Pen(Color.Blue);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc4LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }

                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }
            }
        }

        private void desc5LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc5LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc5LBL.Enabled = false;
                possieEnd = new Point(desc5LBL.Location.X, desc5LBL.Location.Y);
                p = new Pen(Color.DarkCyan);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc5LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }

                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }
            }
        }

        private void desc6LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc6LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc6LBL.Enabled = false;
                possieEnd = new Point(desc6LBL.Location.X, desc6LBL.Location.Y);
                p = new Pen(Color.LightBlue);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc6LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }

                if (chosenDesc.Count == 4)
                {
                    disableLabels();
                }
            }
        }

        private void desc7LBL_MouseClick(object sender, MouseEventArgs e)
        {
            if (heading1LBL.Enabled == false && heading2LBL.Enabled == false && heading3LBL.Enabled == false && heading4LBL.Enabled == false && desc7LBL.Enabled == false)
            {
                MessageBox.Show("awe");
            }
            else
            {
                desc7LBL.Enabled = false;
                possieEnd = new Point(desc7LBL.Location.X, desc7LBL.Location.Y);
                p = new Pen(Color.Cyan);
                p.Width = 3;
                gameProgress.PerformStep();
                chosenDesc.Add(desc7LBL.Text);
                using (Graphics g = mainPanel.CreateGraphics())
                {
                    g.DrawLine(p, possieStart, possieEnd); //Use whatever method to draw your line
                }

                if (chosenDesc.Count >= 4)
                {
                    disableLabels();
                }
            }
        }

        private void Book_Areas_Paint(object sender, PaintEventArgs e)
        {

        }

        //The apint event handler to help show the lines on the panel
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {

            }
        }

        //-----------------------------------------------------------------------\\

        //The rex x button to close the app, making sure it doesnt hang
        private void closeAppButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        //-----------------------------------------------------------------------\\

        //This '?' button pops up a custom message box, siomply explaining to the user how to play the game
        private void helpButton_Click(object sender, EventArgs e)
        {
            string message = Help_Message.ShowBox("Custom MessageBox ?", " New Message Box");

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This random list method was found at https://www.aspsnippets.com/questions/107134/Generate-10-ten-unique-random-numbers-in-Windows-Application-using-C-and-VBNet/
        /// Author : dharmendr
        /// This method helped me to shuffle the randomly selected dictionary items
        /// Once I had them randomly, I used this unique random list of 1 to 7 to shuffle the descriptions 
        /// And they displayed randomly with no duplicates
        /// </summary>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<int> GenerateRandom(int minRange, int maxRange, int total)
        {
            Random random = new Random();
            int count = 0;
            List<int> numbers = new List<int>();
            List<int> listMunbers = new List<int>();
            for (int i = 0; i < total; i++)
            {
                listMunbers.Add(i);
            }
            while (listMunbers.Count > 0)
            {
                int number = random.Next(minRange, maxRange + 1);
                if (!numbers.Contains(number) && listMunbers.Count > 0)
                {
                    numbers.Add(number);
                    listMunbers.Remove(count);
                    count++;
                }
            }

            return numbers;
        }

        //-----------------------------------------------------------------------\\

        //This method starts the game with the call numbers left and descriptions right
        public void startWithNumbersLeft()
        {

            //Defaulting the timer to 40
            if (timerCount <= 0)
            {
                timerCount = 40;
            }

            //Resetting componennts before start

            gameProgress.Value.Equals(0);
            //Displaying the label with the timer, setting the time to 30s and starting it
            countDownLBL.Show();
            //timerCount = 40;
            countDown.Start();

            enableLabels();
            chosenDesc.Clear();
            mainPanel.Refresh();
            Random rand = new Random();
            chosenCNs.Clear();
            chosenDesc.Clear();

            showLabels();

            //This simply adds the descriptions and call numbers to the dictionary
            BA_Class.addDictionaryValues();

            //This method in the BookAreas Class generates all 11 items needed to display
            BA_Class.generateLeftandRight();

            try
            {

                //Adding randomly selected items to the display
                heading1LBL.Text = BA_Class.randomlyDisplayedCN[0];
                heading2LBL.Text = BA_Class.randomlyDisplayedCN[1];
                heading3LBL.Text = BA_Class.randomlyDisplayedCN[2];
                heading4LBL.Text = BA_Class.randomlyDisplayedCN[3];

                //Setting the random list parameters
                int selectedMin = 1;
                int selectedMax = 7;
                int randomIndexCount = 7;
                List<int> randomIndexes = GenerateRandom(selectedMin, selectedMax, randomIndexCount);

                //creating variables that hold the random ints that will be the lists indexes for randomizing purposes.

                aRnd = randomIndexes[0];
                bRnd = randomIndexes[1];
                cRnd = randomIndexes[2];
                dRnd = randomIndexes[3];
                eRnd = randomIndexes[4];
                fRnd = randomIndexes[5];
                gRnd = randomIndexes[6];

                desc1LBL.Text = BA_Class.randomlySelectedTrueDesc[aRnd];
                desc2LBL.Text = BA_Class.randomlySelectedTrueDesc[bRnd];
                desc3LBL.Text = BA_Class.randomlySelectedTrueDesc[cRnd];
                desc4LBL.Text = BA_Class.randomlySelectedTrueDesc[dRnd];
                desc5LBL.Text = BA_Class.randomlySelectedTrueDesc[eRnd];
                desc6LBL.Text = BA_Class.randomlySelectedTrueDesc[fRnd];
                desc7LBL.Text = BA_Class.randomlySelectedTrueDesc[gRnd];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //This method is the same as the previous but the label values have been switched to alternate
        public void startWithDescLeft()
        {
            if (timerCount <= 0)
            {
                timerCount = 40;
            }

            gameProgress.Value.Equals(0);
            
            //Displaying the label with the timer, setting the time to 30s and starting it
            countDownLBL.Show();
            //timerCount = 40;
            countDown.Start();

            enableLabels();
            chosenDesc.Clear();
            mainPanel.Refresh();
            Random rand = new Random();
            chosenCNs.Clear();
            chosenDesc.Clear();

            showLabels();
            BookAreas.callNumberPrefix.Clear();
            BookAreas.callNumberDescription.Clear();
            // randomizeListOrder(BA_Class.randomlySelectedTrueDesc);
            BA_Class.addDictionaryValues();
            BA_Class.generateLeftandRight();

            try
            {
                heading1LBL.Text = BA_Class.randomlySelectedTrueDesc[0];
                heading2LBL.Text = BA_Class.randomlySelectedTrueDesc[1];
                heading3LBL.Text = BA_Class.randomlySelectedTrueDesc[2];
                heading4LBL.Text = BA_Class.randomlySelectedTrueDesc[3];

                int selectedMin = 0;
                int selectedMax = 6;
                int randomIndexCount = 7;
                List<int> randomIndexes = GenerateRandom(selectedMin, selectedMax, randomIndexCount);

                aRnd = randomIndexes[0];
                bRnd = randomIndexes[1];
                cRnd = randomIndexes[2];
                dRnd = randomIndexes[3];
                eRnd = randomIndexes[4];
                fRnd = randomIndexes[5];
                gRnd = randomIndexes[6];

                
                desc1LBL.Text = BA_Class.randomlyDisplayedCN[aRnd]; 
                desc2LBL.Text = BA_Class.randomlyDisplayedCN[bRnd];
                desc3LBL.Text = BA_Class.randomlyDisplayedCN[cRnd]; 
                desc4LBL.Text = BA_Class.randomlyDisplayedCN[dRnd]; 
                desc5LBL.Text = BA_Class.randomlyDisplayedCN[eRnd];
                desc6LBL.Text = BA_Class.randomlyDisplayedCN[fRnd];
                desc7LBL.Text = BA_Class.randomlyDisplayedCN[gRnd];
                
                /*
                desc1LBL.Text = BA_Class.randomlyDisplayedCN[0];
                desc2LBL.Text = BA_Class.randomlyDisplayedCN[1];
                desc3LBL.Text = BA_Class.randomlyDisplayedCN[2];
                desc4LBL.Text = BA_Class.randomlyDisplayedCN[3];
                desc5LBL.Text = BA_Class.randomlyDisplayedCN[4];
                desc6LBL.Text = BA_Class.randomlyDisplayedCN[5];
                desc7LBL.Text = BA_Class.randomlyDisplayedCN[6];
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            gameProgress.Value = 0;
            Random rnd = new Random();
            var randomStartMode = rnd.Next(1, 3);
            sideChoice = Convert.ToInt32(randomStartMode);

            //A simple 50 50 chance randomizer that will display the columns in a random, alternating fashion
            if (sideChoice == 1)
            {
                //The call number left method
                startWithNumbersLeft();
            }
            else
            {
                //The call number right method
                startWithDescLeft();
            }
            //
            
        }

        public void checkOutputCN()
        {

            string key1 = chosenCNs[0].ToString();
            string desc1 = chosenDesc[0].ToString();
            //string desc1 = "Aims at gaining an understanding of the natural and social world.";
            if (BookAreas.callNumberDescription.ContainsKey(key1) && BookAreas.callNumberDescription[key1].Equals(desc1))//== key of description
            {

                string key2 = chosenCNs[1].ToString();
                string desc2 = chosenDesc[1].ToString();
                //string desc1 = "Aims at gaining an understanding of the natural and social world.";
                if (BookAreas.callNumberDescription.ContainsKey(key2) && BookAreas.callNumberDescription[key2].Equals(desc2))//== key of description
                {

                    string key3 = chosenCNs[2].ToString();
                    string desc3 = chosenDesc[2].ToString();
                    //string desc1 = "Aims at gaining an understanding of the natural and social world.";
                    if (BookAreas.callNumberDescription.ContainsKey(key3) && BookAreas.callNumberDescription[key3].Equals(desc3))//== key of description
                    {

                        string key4 = chosenCNs[3].ToString();
                        string desc4 = chosenDesc[3].ToString();
                        //string desc1 = "Aims at gaining an understanding of the natural and social world.";
                        if (BookAreas.callNumberDescription.ContainsKey(key4) && BookAreas.callNumberDescription[key4].Equals(desc4))//== key of description
                        {

                            MessageBox.Show("You have successfully matched all 4 columns. Well done! \nFeel free to reset eith new random values");
                            countDown.Stop();
                        }
                        else
                        {
                            MessageBox.Show(key4 + " \nDid not match with the corresponding side, \nPlease reset and remember what " + key4 + " is not.");
                        }

                    }
                    else
                    {
                        MessageBox.Show(key3 + " \nDid not match with the corresponding side, \nPlease reset and remember what " + key3 + " is not.");
                    }

                }
                else
                {
                    MessageBox.Show(key2 + " \nDid not match with the corresponding side, \nPlease reset and remember what " + key2 + " is not.");
                }


            }
            else
            {
                MessageBox.Show(key1 + " \nDid not match with the corresponding side, \nPlease reset and remember what " + key1 + " is not.");
            }
        }

        //How I check the solutions when descriptions are on the right, I just needed to switch the keys and descriptions
        public void checkOutputDesc()
        {
            string key1 = chosenDesc[0].ToString();
            string desc1 = chosenCNs[0].ToString();

            string key2 = chosenDesc[1].ToString();
            string desc2 = chosenCNs[1].ToString();

            string key3 = chosenDesc[2].ToString();
            string desc3 = chosenCNs[2].ToString();

            string key4 = chosenDesc[3].ToString();
            string desc4 = chosenCNs[3].ToString();

            //string desc1 = "Aims at gaining an understanding of the natural and social world.";
            if (BookAreas.callNumberDescription.ContainsKey(key1) && BookAreas.callNumberDescription[key1].Equals(desc1)
                && BookAreas.callNumberDescription.ContainsKey(key2) && BookAreas.callNumberDescription[key2].Equals(desc2)
                && BookAreas.callNumberDescription.ContainsKey(key3) && BookAreas.callNumberDescription[key3].Equals(desc3)
                && BookAreas.callNumberDescription.ContainsKey(key4) && BookAreas.callNumberDescription[key4].Equals(desc4))
            {
                //== key of description
                MessageBox.Show("You have successfully matched all 4 columns. Well done! \nFeel free to reset eith new random values");
                countDown.Stop();
            }

            else
            {
                MessageBox.Show(" \nDid not match with the corresponding side, \nPlease reset.");
            }
        }

        public void checkOutputButton_Click(object sender, EventArgs e)
        {

            //The same method as before using the same choice, so that the program will check the mathces 
            //Depending if the call numbers displayed on the left or the right
            if (sideChoice == 1)
            {
                // I can put any number inbetween 1 and 200, will this work?
                // If we reach this if statement we have got a 0.5 chance?
                checkOutputCN();
            }
            else
            {
                checkOutputDesc();
            }


        }

        //The timer method declaration 
        private void countDown_Tick(object sender, EventArgs e)
        {

            //Setting the label text to the current time
            countDownLBL.Text = "Time left: " + timerCount--.ToString();

            //Allowing the user to restart if they don't make the count down
            if (timerCount < 0)
            {
                countDown.Stop();
                MessageBox.Show("You ran out of time before matching the columns!");
                

            }
            if (timerCount == 10)
            {

            }
        }

        //Making the timer editable depending on user choice
        private void button1_Click(object sender, EventArgs e)
        {
            timerCount = Convert.ToInt32(timerCountTB.Text);
            timerCountTB.Text = "";
        }

        //-----------------------------------------------------------------------\\
    }
}



