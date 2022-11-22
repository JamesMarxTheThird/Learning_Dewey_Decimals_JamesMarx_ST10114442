using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes
{
    public class BookAreas
    {

        //Global variables




        public List<int> listNumbers = new List<int>();

        public static Dictionary<string, string> callNumberPrefix = new Dictionary<string, string>(); // The dictionary holding the call numbers

        public static Dictionary<string, string> callNumberDescription = new Dictionary<string, string>(); // The dictionary holding the descriptions

        public List<String> randomlyDisplayedCN = new List<string>(); // This contains the randomly selected call numbers after being called

        public List<String> randomlySelectedTrueDesc = new List<string>(); // This contains the randomly selected descriptions after being called

        public List<String> selectedCallNumbers = new List<string>();

        public List<String> randomlySelectedFalseDesc = new List<string>();


        public Random rnd = new Random();
        
        public int generatedCN;

        //-----------------------------------------------------------------------\\



        //-----------------------------------------------------------------------\\


        //-----------------------------------------------------------------------\\

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="rndDesc"></param>
        /// <returns></returns>
        public IEnumerable<TValue> RandomDictionaryDescriptions<TKey, TValue>(IDictionary<TKey, TValue> rndDesc)
        {


            Random rnd2 = new Random();
            List<TValue> values = Enumerable.ToList(rndDesc.Values);
            int size = rndDesc.Count;
            while (true)
            {
                yield return values[rnd2.Next(size)];
            }
        }

        //-----------------------------------------------------------------------\\

        //Here we are simply adding our set call numbers and descriptions to our dictionary
        public void addDictionaryValues()
        {
            callNumberDescription.Clear();
            callNumberPrefix.Clear();

            callNumberPrefix.Add("000", "000");
            callNumberPrefix.Add("100", "100");
            callNumberPrefix.Add("200", "200");
            callNumberPrefix.Add("300", "300");
            callNumberPrefix.Add("400", "400");
            callNumberPrefix.Add("500", "500");
            callNumberPrefix.Add("600", "600");
            callNumberPrefix.Add("700", "700");
            callNumberPrefix.Add("800", "800");
            callNumberPrefix.Add("900", "900");

            Random rnd = new Random();
            var randomDescriptions = rnd.Next(1, 3);
            randomDescriptions = Convert.ToInt32(randomDescriptions);

            //
            if (randomDescriptions == 1)
            {

                callNumberDescription.Add("000", "Information that people could be expected to know.");
                callNumberDescription.Add("100", "This study focuses on the nature of knowledge, reality and existence.");
                callNumberDescription.Add("200", "Sometimes referred to as a cult-like environment.");
                callNumberDescription.Add("300", "The study of societies and relationships.");
                callNumberDescription.Add("400", "It was developed through an evolution of gestures.");
                callNumberDescription.Add("500", "Aims at gaining an understanding of the natural & social world.");
                callNumberDescription.Add("600", "Equipment derived from scientific knowledge.");
                callNumberDescription.Add("700", "Picasso is globally known in this field.");
                callNumberDescription.Add("800", "Written works of lasting artistic merit.");
                callNumberDescription.Add("900", "A study and reflection of past events.");

            }
            else
            {

                callNumberDescription.Add("000", "Information accumulated through various medians.");
                callNumberDescription.Add("100", "This field studies the mind and behaviour.");
                callNumberDescription.Add("200", "The belief of a super human controlling power.");
                callNumberDescription.Add("300", "Anthropology is a main branch of this study.");
                callNumberDescription.Add("400", "Technically derived from latin.");
                callNumberDescription.Add("500", "Aims at gaining an understanding of the natural & social world.");
                callNumberDescription.Add("600", "AI and TVs would be in this category.");
                callNumberDescription.Add("700", "Picasso is globally known in this field.");
                callNumberDescription.Add("800", "Refers to works of the creative imagination.");
                callNumberDescription.Add("900", "The study of change over time");

            }



        }

        //-----------------------------------------------------------------------\\

        /// <summary>
        /// This method was found at https://stackoverflow.com/questions/1028136/random-entry-from-dictionary/1040477#1040477
        /// Then adapted so that the while loop returns no duplicate
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="rndDict"></param>
        /// <returns></returns>
        public IEnumerable<TValue> RandomDictionaryItems<TKey, TValue>(IDictionary<TKey, TValue> rndDict)
        {

            Random rand = new Random();
            Dictionary<TKey, TValue> values = new Dictionary<TKey, TValue>(rndDict);
            while (values.Count > 0)
            {
                TKey randomKey = values.Keys.ElementAt(rand.Next(0, values.Count)); 
                TValue randomValue = values[randomKey];
                values.Remove(randomKey);
                yield return randomValue;
            }
        }

        //-----------------------------------------------------------------------\\
        
        /// <summary>
        /// Here we iterate through our created dictionary of randomly called call numbers
        /// Taking 7 of them and adding them to a list
        /// This will help alot with the comparison
        /// </summary>
        public void generateLeftandRight()
        {

            randomlySelectedTrueDesc.Clear();
            randomlySelectedFalseDesc.Clear();
            randomlyDisplayedCN.Clear();

            //Dictionary<string, object> dict = GetDictionary();
            foreach (object cnValue in RandomDictionaryItems(callNumberPrefix).Take(7))
            {

                randomlyDisplayedCN.Add(cnValue.ToString());
                
                foreach (object descValue in RandomDictionaryItems(callNumberDescription).Take(7))
                {

                    randomlySelectedTrueDesc.Add(descValue.ToString());         

                }

            }   
            
        }

        //-----------------------------------------------------------------------\\

    }

}


