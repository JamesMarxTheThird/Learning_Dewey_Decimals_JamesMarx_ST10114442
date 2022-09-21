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

        //-----------------------------------------------------------------------\\

        //Global variables
        public static Shelf_Order SO = new Shelf_Order();

        public string randomCallNumbers;
       
        private static Random random_BU = new Random();

        public static string fullCN_BU;

        public List<string> unsortedCallNumbers_BU = new List<string>();

        public List<string> sortedCallNumbers_BU = new List<string>();
        
        public string outputValue;

        public static int booksDisplayed_BU = 10;

        public static int BooksDisplayed_BU { get => booksDisplayed_BU; set => booksDisplayed_BU = value; }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Creating our random call numbers for the normal game mode
        /// </summary>
        public void createRandomCallNumbers()
        {

            //For loop that runs 10 tmies by default, and adds a new call number to the list view
            for (int i = 0; i < booksDisplayed_BU; i++)
            {

                //Generates the first 3 digit number
                int generatedCN1 = random_BU.Next(0, 10);
                int generatedCN2 = random_BU.Next(0, 10);
                int generatedCN3 = random_BU.Next(0, 10);

                //Generates the 3 decimals
                int generateddCNDecimal1 = random_BU.Next(0, 10);
                int generateddCNDecimal2 = random_BU.Next(0, 10);
                int generateddCNDecimal3 = random_BU.Next(0, 10);

                //Generates the 3 letters
                char randomChar = (char)random_BU.Next('A', 'Z');
                char randomChar2 = (char)random_BU.Next('A', 'Z');
                char randomChar3 = (char)random_BU.Next('A', 'Z');

                //Putting the call number into one string
                fullCN_BU = generatedCN1.ToString() + generatedCN2.ToString() + generatedCN3.ToString() + "." + "\n" + generateddCNDecimal1.ToString() + generateddCNDecimal2.ToString() + generateddCNDecimal3.ToString() + "\n" + " " + randomChar + randomChar2 + randomChar3;

                //Adding the full call number to the list view
                unsortedCallNumbers_BU.Add(fullCN_BU);
                //sortedCallNumbers_BU.Add(fullCN_BU);

            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Generating 10 call numbers with the same first 3 digit number
        /// </summary>
        public void intermediateMode()
        {

            
            int generatedCN1 = random_BU.Next(0, 10);
            int generatedCN2 = random_BU.Next(0, 10);
            int generateddCNDecimal1 = random_BU.Next(0, 10);

            //For loop that runs 10 tmies by default, and adds a new call number to the list view
            for (int i = 0; i < booksDisplayed_BU; i++)
            {

                //Generates digit 3
                int generatedCN3 = random_BU.Next(0, 10);

                //Generates digit 5 and 6
                int generateddCNDecimal2 = random_BU.Next(0, 10);
                int generateddCNDecimal3 = random_BU.Next(0, 10);

                //Generates the 3 letters
                char randomChar = (char)random_BU.Next('A', 'Z');
                char randomChar2 = (char)random_BU.Next('A', 'Z');
                char randomChar3 = (char)random_BU.Next('A', 'Z');

                //Putting the call number into one string
                fullCN_BU = generatedCN1.ToString() + generatedCN2.ToString() + generatedCN3.ToString() + "." + "\n" + generateddCNDecimal1.ToString() + generateddCNDecimal2.ToString() + generateddCNDecimal3.ToString() + "\n" + " " + randomChar + randomChar2 + randomChar3;

                //Adding the full call number to the list view
                unsortedCallNumbers_BU.Add(fullCN_BU);
                //sortedCallNumbers_BU.Add(fullCN_BU);

            }

        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// Generating 13 call numbers with the same first 3 digits, the same first decimal and the same first initial
        /// </summary>
        public void advancedMode()
        {

            //Giving the call numbers the same digits at certain spots
            int generatedCN1 = random_BU.Next(0, 10);

            int generateddCNDecimal1 = random_BU.Next(0, 10);

            char randomChar = (char)random_BU.Next('A', 'Z');
            char randomChar2 = (char)random_BU.Next('A', 'Z');

            //For loop that runs 10 tmies by default, and adds a new call number to the list view
            for (int i = 0; i < booksDisplayed_BU; i++)
            {

                //generating the second two digits
                int generatedCN2 = random_BU.Next(0, 10);
                int generatedCN3 = random_BU.Next(0, 10);

                //Generating digits 4 and 5
                int generateddCNDecimal2 = random_BU.Next(0, 10);
                int generateddCNDecimal3 = random_BU.Next(0, 10);


                //Generates letter 3
                char randomChar3 = (char)random_BU.Next('A', 'Z');


                //Putting the call number into one string
                fullCN_BU = generatedCN1.ToString() + generatedCN2.ToString() + generatedCN3.ToString() + "." + "\n" + generateddCNDecimal1.ToString() + generateddCNDecimal2.ToString() + generateddCNDecimal3.ToString() + "\n" + " " + randomChar + randomChar2 + randomChar3;

                //Adding the full call number to the list view
                unsortedCallNumbers_BU.Add(fullCN_BU);
                //sortedCallNumbers_BU.Add(fullCN_BU);

            }

        }

        //-----------------------------------------------------------------------\\

    }
}
