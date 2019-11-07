using System;
using System.Collections.Generic;
using System.Linq;

namespace immediateSmallerElement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter test case count : ");
            string val = Console.ReadLine();
            int testCount = Convert.ToInt32(val);
            Dictionary<int, List<int>> elementCollection = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> resultCollection = new Dictionary<int, List<int>>();

            for (int i = 0; i < testCount; i++)
            {
                //Console.Write(String.Format("Enter element count for {0} .test case : ", i + 1));
                //string val2 = Console.ReadLine();
                //int elementCount = Convert.ToInt32(val2);
                List<int> elements = new List<int>();

                //for (int j = 0; j < elementCount; j++)
                //{
                //    Console.Write(String.Format("Enter {0} .element : ", j + 1));
                //    elements.Add(Convert.ToInt32(Console.ReadLine()));
                //}
                Console.Write(i.ToString() + ". : Enter elements with space character  : ");
                string sElements = Console.ReadLine();
                //elements = sElements.Split(' ').Select(Int32.Parse).ToList();

                elements = Array.ConvertAll(sElements.Split(' '), int.Parse).ToList();

                elementCollection.Add(i, elements);


            }


            resultCollection = findSmaller(elementCollection);
            foreach (int item in resultCollection.Keys)
            {
                List<int> newElements = resultCollection[item];
                string stringElements = null;
                for (int i = 0; i < newElements.Count; i++)
                {
                    stringElements += newElements[i] + " ";
                }
                Console.WriteLine(item.ToString() + ". array : " + stringElements);
            }

            Console.ReadKey();

        }

        private static Dictionary<int, List<int>> findSmaller(Dictionary<int, List<int>> elementCollection)
        {
            Dictionary<int, List<int>> procesCollection = new Dictionary<int, List<int>>();

            foreach (int item in elementCollection.Keys)
            {
                List<int> vElements = elementCollection[item];
                List<int> newElements = new List<int>();

                int i = 1;
                do
                {
                    if (vElements[i] < vElements[i - 1])
                    {
                        newElements.Add(vElements[i]);
                    }
                    else
                    {
                        newElements.Add(-1);
                    }

                    i++;

                    if (i >= vElements.Count)
                    {
                        newElements.Add(-1);
                    }
                }
                while (i < vElements.Count);


                procesCollection.Add(item, newElements);

            }
            return procesCollection;
        }
    }
}
