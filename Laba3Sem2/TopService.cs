using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3Sem2
{
    public class TopService
    {
        public string Name { get; set; }
        public int amount = 0;
        public TopService(string serv,int amount)
        {
            this.amount = amount;
            Name = serv;
        }
        public static List<TopService> TOP(List<Prepod> prepods)
        {
            List<string> list = new(prepods.Select(x=>x.Service));
            List<TopService> topServices = new List<TopService>(
                list.Select(g => new TopService(g, list.Count(x => x == g))))
                .OrderByDescending(x => x.amount)
                .DistinctBy(x => x.Name)
                .ToList();
            return topServices;
        }
        public static void ColorChange(string serv)
        {
            if (serv == "Discord")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(serv);
                Console.ResetColor();
            }
            else if (serv == "Zoom")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(serv);
                Console.ResetColor();
            }
            else if (serv == "WebinarSFU")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(serv);
                Console.ResetColor();
            }
        }
        public static bool IsService(string serv)
        {
            if (serv == "Discord")
            {
                return true;
            }
            if (serv == "WebinarSFU")
            {
                return true;
            }
            if (serv == "Zoom")
            {
                return true;
            }
            return false;
        }
    }

}
