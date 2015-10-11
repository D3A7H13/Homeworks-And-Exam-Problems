using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShmoogleCounter
{
    class ShmoogleCounter
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"(?=\bint\b (\w+)[ );=]|\bdouble\b (\w+)[ );=])");
            StringBuilder sb = new StringBuilder();
            string command = Console.ReadLine();
            while (command != "//END_OF_CODE")
            {
                if(command.Contains("//"))
                {
                    command = Console.ReadLine();
                    continue;
                }
                sb.Append(command);
                sb.Append(" ");

                command = Console.ReadLine();
            }
            var result = rgx.Matches(sb.ToString());
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            foreach (Match varType in result)
            {
                if(varType.Groups[2].Value.Count() > 0)
                {
                    doubles.Add(varType.Groups[2].Value);
                }
                else
                {
                    ints.Add(varType.Groups[1].Value);
                }
            }
            if(doubles.Count > 0)
            {
                doubles.Sort();
                Console.WriteLine("Doubles: {0}", string.Join(", ", doubles));
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }
            if (ints.Count > 0)
            {
                ints.Sort();
                Console.WriteLine("Ints: {0}", string.Join(", ", ints));
            }
            else
            {
                Console.WriteLine("Ints: None");
            }
           
        }
    }
}
