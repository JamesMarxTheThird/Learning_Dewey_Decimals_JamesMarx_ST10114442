using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning_Dewey_Decimals_JamesMarx_ST10114442.Classes
{
    public class FindCN
    {

		public List<int> numbers = new List<int>();
		public List<int> listNunbers = new List<int>();

		public string nodeID
        {
            get;
            set;
        }

        public string nodeText
        {
            get;
            set;
        }

		public List<int> GenerateRandom(int minRange, int maxRange, int total)
		{
			Random random = new Random();
			int count = 0;

			for (int i = 0; i < total; i++)
			{
				listNunbers.Add(i);
			}
			while (listNunbers.Count > 0)
			{
				int number = random.Next(minRange, maxRange + 1);
				if (!numbers.Contains(number) && listNunbers.Count > 0)
				{
					numbers.Add(number);
					listNunbers.Remove(count);
					count++;
				}
			}

			return numbers;
		}



	}

}
