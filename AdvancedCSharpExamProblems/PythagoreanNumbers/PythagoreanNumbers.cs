using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanNumbers
{
    class PythagoreanNumbers
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            int[] numbers = new int[nums];
            for (int i = 0; i < nums; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int count = 0;
           
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        int firstPow = (int)Math.Pow(numbers[i], 2);
                        int secondPow = (int)Math.Pow(numbers[j], 2);
                        int thirdPow = (int)Math.Pow(numbers[k], 2);

                        if(firstPow + secondPow == thirdPow)
                        {
                            count++;
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", Math.Min(numbers[i], numbers[j]), Math.Max(numbers[i], numbers[j]), numbers[k]);
                        }
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
