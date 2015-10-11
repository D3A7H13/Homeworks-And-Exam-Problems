using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commands = command.Split();
                if (command.Contains("exchange"))
                {
                    int index = int.Parse(commands[1]);
                    ExchangeAtIndex(ref array, index);
                }
                else if (command.Contains("max"))
                {
                    Max(array, commands[1]);
                }
                else if (command.Contains("min"))
                {
                    Min(array, commands[1]);
                }
                else if (command.Contains("first"))
                {
                    First(array, commands[2], int.Parse(commands[1]));
                }
                else if (command.Contains("last"))
                {
                    Last(array, commands[2], int.Parse(commands[1]));
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }
        private static void Last(int[] array, string type, int count)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> elements = new List<int>();
            int counter = 0;
            if (type == "odd")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0)
                    {
                        elements.Add(array[i]);
                        counter++;
                    }
                    if (counter == count)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0)
                    {
                        elements.Add(array[i]);
                        counter++;
                    }
                    if (counter == count)
                    {
                        break;
                    }
                }
            }
            elements.Reverse();
            Console.WriteLine("[{0}]", string.Join(", ", elements));
        }

        private static void First(int[] array, string type, int count)
        {
            if(count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> elements = new List<int>();
            int counter = 0;
            if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if(array[i] % 2 != 0)
                    {
                        elements.Add(array[i]);
                        counter++;
                    }
                    if(counter == count)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        elements.Add(array[i]);
                        counter++;
                    }
                    if (counter == count)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", elements));
        }

        private static void Min(int[] array, string type)
        {
            if (type == "odd")
            {
                int min = int.MaxValue;
                bool containsOdd = false;
                int minIndex = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        containsOdd = true;
                        if (min >= array[i])
                        {
                            min = array[i];
                            minIndex = i;
                        }
                    }

                }
                if (containsOdd)
                {
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }
            else
            {
                int min = int.MaxValue;
                bool containsOdd = false;
                int minIndex = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        containsOdd = true;
                        if (min >= array[i])
                        {
                            min = array[i];
                            minIndex = i;
                        }
                    }

                }
                if (containsOdd)
                {
                    Console.WriteLine(minIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static void Max(int[] array, string type)
        {
            if (type == "odd")
            {
                int max = int.MinValue;
                bool containsOdd = false;
                int maxIndex = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        containsOdd = true;
                        if (max <= array[i])
                        {
                            max = array[i];
                            maxIndex = i;
                        }
                    }

                }
                if (containsOdd)
                {
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }
            else
            {
                int max = int.MinValue;
                bool containsEven = false;
                int maxIndex = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        containsEven = true;
                        if (max <= array[i])
                        {
                            max = array[i];
                            maxIndex = i;
                        }
                    }

                }
                if (containsEven)
                {
                    Console.WriteLine(maxIndex);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static void ExchangeAtIndex(ref int[] array, int index)
        {
            if(index >= array.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            List<int> firstSub = new List<int>();
            List<int> list = array.ToList();
            for (int i = index + 1; i < list.Count; i++)
            {
                firstSub.Add(list[i]);
            }
            List<int> finalList = firstSub;
            for (int i = 0; i <= index; i++)
            {
                finalList.Add(list[i]);
            }
            array = finalList.ToArray();
        }
    }
}
