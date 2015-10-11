using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuckNumbers
{
    class StuckNumbers
    {
        static void Main(string[] args)
        {

            Console.ReadLine();

            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> results = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    for (int k = 0; k < numbers.Count; k++)
                    {
                        for (int c = 0; c < numbers.Count; c++)
                        {
                            string left = string.Empty,
                                   right = string.Empty;
                            if (i != j && i != k && i != c && j != k && j != c && k != c)
                            {
                                left = numbers[i] + numbers[j];
                                right = numbers[k] + numbers[c];
                            }

                            if (left == right && (left != string.Empty) && (right != string.Empty))
                            {
                                results.Add(numbers[i] + "|" + numbers[j] + "==" + numbers[k] + "|" + numbers[c]);
                            }
                        }
                    }
                }
            }
            if(results.Count > 0)
            {
                foreach (string result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
