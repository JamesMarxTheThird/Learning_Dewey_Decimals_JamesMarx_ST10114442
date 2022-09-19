using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes
{
    public class BasicUtilities
    {
        public static Shelf_Order SO = new Shelf_Order();

        public string randomCallNumbers;

        public static int booksDisplayed_BU = 10;

        private static Random random_BU = new Random();

        public static string fullCN_BU;

        public List<string> unsortedCallNumbers_BU = new List<string>();
        public List<string> sortedCallNumbers_BU = new List<string>();
        
        public string outputValue;

        
        //-----------------------------------------------------------------------\\

        /// <summary>
        /// 
        /// </summary>
        public void createRandomCallNumbers()
        {
            var awe1 = "";
            //For loop that runs 10 tmies by default, and adds a new call number to the list view
            for (int i = 0; i < booksDisplayed_BU; i++)
            {

                //Generates the first 3 digit number

                //outputValue = "0" + generatedCN.ToString();
                int generatedCN = random_BU.Next(0, 1000);
                /*
                if (generatedCN > 0 && generatedCN < 10)
                {
                     awe1 = $"{generatedCN:D2}";
                }
                else if (generatedCN > 10 && generatedCN < 100)
                {
                     awe1 = $"{generatedCN:D1}";
                }
                else
                {

                }
                */

                //Generates the second 3 digit number
                int generateddCNDecimal = random_BU.Next(0, 1000);

                //Generates the 3 letters
                char randomChar = (char)random_BU.Next('A', 'Z');
                char randomChar2 = (char)random_BU.Next('A', 'Z');
                char randomChar3 = (char)random_BU.Next('A', 'Z');

                //Putting the call number into one string
                fullCN_BU = generatedCN.ToString() + "." + "\n" + generateddCNDecimal.ToString() + "\n" + " " + randomChar + randomChar2 + randomChar3;

                //Adding the full call number to the list view
                unsortedCallNumbers_BU.Add(fullCN_BU);
                sortedCallNumbers_BU.Add(fullCN_BU);

            }

        }

        //-----------------------------------------------------------------------\\

    }
}
