using System;
using System.Collections.Generic;
using System.Linq;

namespace SrabskoUnleashed
{
    class SrabskoUnleashed
    {
        static void Main(string[] args)
        {
            Dictionary<string, names> info = new Dictionary<string, names>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] data = command.Split().ToArray();
                if (data.Length < 4 && data.Length > 8)
                {
                    command = Console.ReadLine();
                    continue;
                }
                string name = string.Empty;
                string venue = string.Empty;
                int ticketsC = 0;
                int ticketsP = 0;
                try
                {
                    ticketsC = int.Parse(data[data.Length - 1]);
                    ticketsP = int.Parse(data[data.Length - 2]);
                }
                catch
                {
                    command = Console.ReadLine();
                    continue;
                }

                int venueIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (data[i].Contains("@"))
                    {
                        venueIndex = i;
                        break;
                    }
                    name += data[i] + " ";
                }

                for (int i = venueIndex; i < data.Length - 2; i++)
                {
                    venue += data[i] + " ";
                }
                name = name.Remove(name.Length - 1);

                if (!info.ContainsKey(venue))
                {
                    info.Add(venue, new names(name, ticketsP * ticketsC));

                }
                else
                {
                    singers temp = new singers(name, ticketsP * ticketsC);
                    if (info[venue].set.Any(x => x.name == name))
                    {
                        int index = info[venue].set.IndexOf(info[venue].set.Where(p => p.name == name).FirstOrDefault());
                        info[venue].set[index].totalPrice += ticketsP * ticketsC;
                    }
                    else
                    {
                        info[venue].set.Add(temp);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var venue in info)
            {
                Console.WriteLine("{0}", venue.Key.Substring(1, venue.Key.Length - 2));
                var list = venue.Value.set;
                foreach (var singer in list.OrderByDescending(p => p.totalPrice))
                {
                    Console.WriteLine("#  {0}", singer.ToString());
                }
            }
        }
    }

    public class singers
    {
        public string name { get; set; }
        public int totalPrice { get; set; }

        public singers() { }
        public singers(string n, int tp)
        {
            this.name = n;
            this.totalPrice += tp;
        }

        public override string ToString()
        {
            return name + " -> " + totalPrice;
        }
        
    }
    public class names : singers
    {
        public List<singers> set { get; set; }

        public names(string n, int tp)
        {
            set = new List<singers>();
            set.Add(new singers(n, tp));
        }

    }
}