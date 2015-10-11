using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TextTransformer
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"([$&%'])([^$&%']+)\1");
            string command = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (!command.Equals("burp"))
            {
                sb.Append(command);
                command = Console.ReadLine();
            }
            string input = sb.ToString();
            Regex.Replace(input, "\\s+", " ");

            var results = rgx.Matches(input);
            sb.Clear();
            foreach (Match match in results)
            {
                char special = Convert.ToChar(match.Groups[1].Value);
                char[] text = match.Groups[2].Value.ToCharArray();
                char[] newText = new char[text.Length];
                int weight = 0;

                switch(special)
                {
                    case '$':
                        weight = 1;
                        break;
                    case '%':
                        weight = 2;
                        break;
                    case '&':
                        weight = 3;
                        break;
                    case '\'':
                        weight = 4;
                        break;
                }
                for (int i = 0; i < text.Length; i++)
                {
                    if(i % 2 == 0)
                    {
                        newText[i] = (char)((int)text[i] + weight);
                    }
                    else
                    {
                        newText[i] = (char)((int)text[i] - weight);
                    }
                }

                sb.Append(string.Join("", newText));
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
