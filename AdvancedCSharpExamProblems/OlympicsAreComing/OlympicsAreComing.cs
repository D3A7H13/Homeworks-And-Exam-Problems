using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlympicsAreComing
{
    class OlympicsAreComing
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, int> wins = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> playersPerCountry = new Dictionary<string, HashSet<string>>();

            while (!command.Equals("report"))
            {
                string[] details = command.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
                string[] temp = details[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] temp2 = details[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                details[0] = string.Join(" ", temp);
                details[1] = string.Join(" ", temp2);

                

                if (wins.ContainsKey(details[1]))
                {
                    wins[details[1]]++;
                    playersPerCountry[details[1]].Add(details[0]);
                }
                else
                {
                    wins.Add(details[1], 1);
                    playersPerCountry.Add(details[1], new HashSet<string>());
                    playersPerCountry[details[1]].Add(details[0]);
                }


                command = Console.ReadLine();
            }


            foreach (KeyValuePair<string, int> country in wins.OrderByDescending(c => c.Value))
            {
                var count = playersPerCountry[country.Key];
                Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, count.Count, country.Value);
            }
        }

    }


    public class Country
    {
        public Country()
        {
            this.Players = new HashSet<string>();
        }

        public int Count { get; set; }
        public HashSet<string> Players { get; set; }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace OlympicsAreComing
//{
//    class OlympicsAreComing
//    {
//        static void Main(string[] args)
//        {
//            string command = Console.ReadLine();

//            Dictionary<string, int> money = new Dictionary<string, int>();
//            Dictionary<string, List<string>> venues = new Dictionary<string, List<string>>();

//            while (!command.Equals("End"))
//            {
//                string[] data = command.Split().ToArray();
//                if (data.Length < 4)
//                {
//                    command = Console.ReadLine();
//                    continue;
//                }
//                string name = string.Empty;
//                string venue = string.Empty;
//                int ticketsC = int.Parse(data[data.Length - 1]);
//                int ticketsP = int.Parse(data[data.Length - 2]);
//                int venueIndex = 0;
//                for (int i = 0; i < 3; i++)
//                {
//                    if (data[i].Contains("@"))
//                    {
//                        venueIndex = i;
//                        break;
//                    }
//                    name += data[i] + " ";
//                }
//                for (int i = venueIndex; i < data.Length - 2; i++)
//                {
//                    venue += data[i] + " ";
//                }
//                venue.Trim();
//                name.Trim();
                
//                if(venues.ContainsKey(venue))
//                {
//                    if(venues[venue].Contains(name))
//                    {
//                        money[name] += (ticketsC * ticketsP);
//                    }
//                    else
//                    {
//                        venues[venue].Add(name);
//                        money.Add(name, (ticketsC * ticketsP));
//                    }
//                }
//                else
//                {
//                    venues.Add(venue, new List<string>());
//                    venues[venue].Add(name);
//                    money.Add(name, (ticketsC * ticketsP));
//                }

//                command = Console.ReadLine();
//            }

//            foreach (var venue in venues)
//            {
//                var list = venue.Value;
//                Console.WriteLine(venue.Key);
//                foreach (var singer in list)
//                {
//                    Console.WriteLine("#  {0}-> {1}", singer, money[singer]);
//                }
//            }
//        }

//    }
//}
