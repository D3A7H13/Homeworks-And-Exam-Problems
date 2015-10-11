using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TerroristWin
{
    class TerroristWin
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = string.Empty;

            Regex rgx = new Regex(@"(?:\|(.*?)\|)");
            var results = rgx.Matches(input);

            StringBuilder sb = new StringBuilder();
            sb.Append(input);
            foreach (Match match in results)
            {
                string bomb = match.Groups[1].Value;
                int matchIndex = match.Index;
                int len = bomb.Length + 2;
                char[] bombCode = bomb.ToCharArray();
                int result = 0;

                foreach (char symbol in bombCode)
                {
                    result += symbol;
                }

                int radius = result % 10;
                
                int startIndex;

                if (matchIndex - radius >= 0)
                {
                    startIndex = matchIndex - radius;
                    len += radius * 2;
                }
                else
                {
                    startIndex = 0;
                    len += radius;
                }

                if (startIndex + len > sb.Length)
                {
                    int endIntex = sb.Length - 1;
                    len = endIntex - startIndex + 1;
                }

                sb.Remove(startIndex, len);
                sb.Insert(startIndex, ".", len);
                output = sb.ToString();

            }
            Console.WriteLine(output);
        }
    }
}
