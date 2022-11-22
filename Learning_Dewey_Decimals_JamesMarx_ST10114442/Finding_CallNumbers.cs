using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442
{

	//Global variables
	//-----------------------------------------------------------------------\\

	public partial class Finding_CallNumbers : Form
    {

		private TreeView myTreeView;
		private bool before, click, manual;
		public static string selectedCN;
		public bool stopIterationTL = false;
		public bool stopIterationML = false;
		public bool stopIterationBL = false;
		public string[] multi_lineTXT;
		public string onlyLinesGen;
		public List<String> individualLines = new List<string>();

		public List<int> randomIndexes = new List<int>();
		public List<int> randomUserIndexes = new List<int>();


		public List<String> rndCns = new List<string>();
		public List<String> genCN = new List<string>();

		public List<String> rndUserCns = new List<string>();

		public List<string> newLinesList = new List<string>();

		public List<string> newUserLinesList = new List<string>();

		public List<String> individualStrings = new List<string>();


		public List<int> userNumbers = new List<int>();
		public List<int> userListNumbers = new List<int>();

		public static int timerCount = 40;


		public static TreeNodeCollection callNumberNodes;

		//public gen GN = new gen();

		public static int rndSel1;
		public static int rndSel2;
		public static int rndSel3;
		public static int rndSel4;
		public static int r5;

		public static int rndUserCategory;
		public static string userFull;
		public static string rndUserFull;
		public static string rndUserTop;
		public static string rndUserMiddle;
		public static string rndUserBottom;

		public static int rndIndexUser;

		public static string awe;

		public static string randomGenCN;

		public FindCN FCN = new FindCN();

		//-----------------------------------------------------------------------\\

		public Finding_CallNumbers()
        {
            InitializeComponent();

        }

        //-----------------------------------------------------------------------\\

        private void Shelf_Order_Load(object sender, EventArgs e)
        {

        }

		//-----------------------------------------------------------------------\\

		public void readTxtToArray()
		{

			var linesList = new List<string>();
			var fileStream = new FileStream("allCNLines.txt", FileMode.Open, FileAccess.Read);
			using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
			{
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{
					linesList.Add(line);
					//MessageBox.Show(line);
				}
			}

			multi_lineTXT = linesList.ToArray();

			splitImportedLines();
		}

		//-----------------------------------------------------------------------\\

		public void splitImportedLines()
		{

			foreach (var allLines in multi_lineTXT)
			{
				var allData = allLines.ToString().Split(';');

				foreach (string fullCategoryList in allData)
				{

					//string intVal = Regex.Replace(fullCategoryList, "[A-Za-z]", "");
					newLinesList.Add(fullCategoryList);
					//MessageBox.Show(fullCategoryList);
				}

			}

			//Setting the random list parameters
			int selectedMin = 0;
			int selectedMax = 9;
			int randomIndexCount = 9;
			randomIndexes = FCN.GenerateRandom(selectedMin, selectedMax, randomIndexCount);

			rndSel1 = randomIndexes[0];
			rndSel2 = randomIndexes[1];
			rndSel3 = randomIndexes[2];
			rndSel4 = randomIndexes[3];
			//int rndSel5 = randomIndexes[4];
			rndCns = new List<string>();
			//MessageBox.Show(randomIndexes[0].ToString());
			//genCN.Add(newLinesList[rndSel1]);
			rndCns.Add(newLinesList[rndSel1]);
			rndCns.Add(newLinesList[rndSel2]);
			rndCns.Add(newLinesList[rndSel3]);
			rndCns.Add(newLinesList[rndSel4]);

			//rndCns.Sort();
			
			Random r = new Random();
			r5 = r.Next(0, 4);
			awe = rndCns[r5];

		}

		//-----------------------------------------------------------------------\\

		public void addCollectionToView()
		{

			//string awezah = awe;
			//MessageBox.Show(awezah);
			foreach (string item in rndCns)
			{
				if (item == awe)
                {

					var other_data = item.Split(',');

                    foreach (string otherLine in other_data)
                    {
						userFull = Regex.Replace(otherLine, "[^0-9.]", "");
						individualLines.Add(userFull);
					}
					//MessageBox.Show("ily");
				}

				//MessageBox.Show(item);
				var TL_data = item.Split(',');


				foreach (string fullLine in TL_data)
				{
					string onlyNumbers = Regex.Replace(fullLine, "[^0-9.]", "");
					individualLines.Add(onlyNumbers);


				}

				//MessageBox.Show(onlyNumbers);

				var TL_values = item.Split(',');
				foreach (string fullValue in TL_values)
				{
					string onlyVal = Regex.Replace(fullValue, "[^A-Za-z.]", "");
					string minusDot = Regex.Replace(onlyVal, "[.]", "");
					individualStrings.Add(minusDot);

				}

				TreeNode node;

				foreach (string singleCN in individualLines)
				{
					string[] bottomLSplit = singleCN.Split('.');

					callNumberNodes = CN_TreeView.Nodes;

					foreach (string name in bottomLSplit)
					{
						//MessageBox.Show(name);
						if (callNumberNodes.ContainsKey(name))
						{
							node = callNumberNodes[name];
						}
						else
						{
							node = new TreeNode(name);

							node.Name = name;

							callNumberNodes.Add(node);

						}
						callNumberNodes = node.Nodes;
						//MessageBox.Show(name.ToString());
					}

				}

			}


			//MessageBox.Show(userFull);
		}

		//-----------------------------------------------------------------------\\

		public void splitFullGenCN()
		{
			//userFull = onlyLinesGen;
			int rndIndexUser = individualLines.FindIndex(a => a.Contains(userFull));
			//MessageBox.Show(individualStrings[rndIndexUser]);
			
			if (individualLines.Contains(userFull))
			{
				int indexx = individualLines.FindIndex(x => x.Contains(userFull));

				//MessageBox.Show(indexx.ToString());
			}
			
			genCategoryLBL.Text = individualStrings[rndIndexUser];

			if (individualLines.Contains(awe))
			{
				 rndIndexUser = individualLines.FindIndex(a => a.Contains(awe));
				/*	
			foreach (string fullLineGen in TL_data)
					{
						onlyLinesGen = Regex.Replace(fullLineGen, "[^0-9.]", "");
						individualLines.Add(onlyLinesGen);
						//MessageBox.Show(onlyLinesGen);
						userFull = onlyLinesGen;

					}
				*/

				//string awezahh = individualStrings[rndIndexUser];
				//MessageBox.Show(awezahh);
				genCategoryLBL.Text = individualStrings[rndIndexUser];
			}

			rndUserBottom = userFull.Right(3); 
			rndUserTop = userFull.Left(3);
			rndUserMiddle = userFull.Substring(4, 3);
			//MessageBox.Show(rndUserTop + " " + rndUserMiddle + " " + rndUserBottom);

		}

		//-----------------------------------------------------------------------\\

		//-----------------------><=>==EVENT-HANDLERS==<=><----------------------\\

		//-----------------------------------------------------------------------\\

		private void blueHelpIcon_Click(object sender, EventArgs e)
        {

            MessageBox.Show("The full instruction can be read on the readme");

        }

		//-----------------------------------------------------------------------\\

		private void startFindBTN_Click(object sender, EventArgs e)
        {
			timerCount = 40;
			//Displaying the label with the timer, setting the time to 30s and starting it
			countDownLBL.Show();
			//timerCount = 40;
			findCNTimer.Start();
			nodeSelPB.Value = 0;
			rndCns.Clear();
			individualLines.Clear();

			CN_TreeView.Nodes.Clear();

			randomIndexes.Clear();
			newLinesList.Clear();
			FCN.listNunbers.Clear();
			FCN.numbers.Clear();

			individualStrings.Clear();
			genCategoryLBL.Text = "";
			newUserLinesList.Clear();
			rndUserCns.Clear();
			randomUserIndexes.Clear();



			readTxtToArray();
			addCollectionToView();
			//rndIndexUser = individualLines.FindIndex(a => a.Contains(userFull));
			//MessageBox.Show(rndIndexUser.ToString());
			//rndCns.Sort();
			splitFullGenCN();
			//user_CN_Index_Gen();
			//rndCns.Sort();
		}

		//-----------------------------------------------------------------------\\

		private void CN_TreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
			/*
			before = true;
			click = false;
			if (!manual)
			e.Cancel = true;
			*/
		}

		//-----------------------------------------------------------------------\\

		private void CN_TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
			/*
			before = true;
			click = false;
			if (!manual)
			e.Cancel = true;
			*/
		}

		//-----------------------------------------------------------------------\\

		private void CN_TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
			//before = false;
			//click = true;
			
			selectedCN = "";
			selectedCN = CN_TreeView.SelectedNode.Text;
			if (selectedCN.Equals(rndUserBottom))
            {
				nodeSelPB.Value = 3;
				MessageBox.Show("You have selected the correct, exact category for the generated description, well done! \nThe game will now reset with a time reduction");
				
				startFindBTN.PerformClick();
				timerCount = 30;
				nodeSelPB.Value = 0;
			}
            else
            {
				nodeSelPB.Value += 1;
				MessageBox.Show("This could be correct, this could be wrong, find out on your final node!");
			}

			//Cool code that prevents expansion based on selections but couldnt get it to iterate properly, and couldnt restart on game reset.
			/*
				if (selectedCN.Equals(rndUserTop))
				{
					MessageBox.Show("You have selected the correct, exact category for the generated description, well done! 2");


					before = false;
					click = true;
					//stopIterationTL = true;
					string newCN = CN_TreeView.SelectedNode.Text;
					if (newCN.Equals(rndUserMiddle))
					{
						MessageBox.Show("You have selected the correct, exact category for the generated description, well done!");
						if (before && !click)
						{

							manual = true;
							if (e.Node.IsExpanded)
								e.Node.Collapse();
							else
								e.Node.Expand();
							manual = false;
						}

						before = false;
						click = true;
						stopIterationML = true;
						string newCN2 = CN_TreeView.SelectedNode.Text;
						if (newCN2.Equals(rndUserBottom))
						{
							MessageBox.Show("You have selected the correct, exact category for the generated description, well done!");
						}
					}
				}
			*/
			/*
			if (stopIterationTL == true)
            {

				if (stopIterationML == true)
				{
					if (selectedCN.Equals(rndUserBottom))
					{
						MessageBox.Show("You have selected the correct, exact category for the generated description, well done!");
						selectedCN = "";
						stopIterationML = false;
					}
					else
					{
						MessageBox.Show("Wrong category");
						selectedCN = "";
						
					}
				}
				else
				{
					if (selectedCN.Equals(rndUserMiddle))
					{
						if (before && !click)
						{

							manual = true;
							if (e.Node.IsExpanded)
								e.Node.Collapse();
							else
								e.Node.Expand();
							manual = false;
						}

						before = false;
						click = true;
						stopIterationML = true;
					}
					else
					{
						MessageBox.Show("This middle-level category does not fit the generated description. \nPlease try again.");
						selectedCN = "";
						before = false;
						click = true;
						//stopIterationML = true;
					}
				}

			}
            else
            {

				if (selectedCN.Equals(rndUserTop))
				{

					if (before && !click)
					{

						manual = true;
						if (e.Node.IsExpanded)
							e.Node.Collapse();
						else
							e.Node.Expand();
						manual = false;

					}
					before = false;
					click = true;
					stopIterationTL = true;
				}
				else
				{
					MessageBox.Show("This top-level category does not fit the generated description. \nPlease try again.");
					selectedCN = "";
					before = false;
					click = true;
				}
			}
			*/
			
		}

		//-----------------------------------------------------------------------\\

		private void exitBTN_Click(object sender, EventArgs e)
        {
			System.Environment.Exit(1);
		}

        private void setTimerBTN_Click(object sender, EventArgs e)
        {

			if (timeCountTB.Text == String.Empty || timeCountTB.Text.Any(c => !char.IsDigit(c)))
            {
				MessageBox.Show("Please enter an amount of seconds - only numbers");
				timeCountTB.Text = "";
            }
            else
            {
				timerCount = Convert.ToInt32(timeCountTB.Text);
				timeCountTB.Text = "";
			}

		}

		//-----------------------------------------------------------------------\\

		private void findCNTimer_Tick(object sender, EventArgs e)
        {
			//Setting the label text to the current time
			countDownLBL.Text = "Time left: " + timerCount--.ToString();

			//Allowing the user to restart if they don't make the count down
			if (timerCount < 0)
			{
				findCNTimer.Stop();
				MessageBox.Show("You ran out of time before finding the correct category!");

			}
			if (timerCount == 10)
			{

			}
		}

		//-----------------------------------------------------------------------\\

		private void countDownLBL_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nodeSelPB_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------\\

        private void turnOffTimerBTN_Click(object sender, EventArgs e)
        {
			countDownLBL.Hide();
			findCNTimer.Stop();
        }

		//-----------------------------------------------------------------------\\

		private void SO_HomeB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Form HF = new Home_Form();
            HF.Show();
        }

       


        //-----------------------------------END----------------------------------\\

    }
}
