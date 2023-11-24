using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba3Sem2
{

    public class Prepod
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Institute { get; set; }
        public string Service { get; set; }
        public Prepod(string s,string n, string m,string inst,string service) 
        {
            Surname = s;
            Name = n;
            MiddleName = m;
            Institute = inst;
            Service = service;
        }
    }
    public static class Extansion
    {
        public static string NameWrite(this Prepod prepod)
        {
            return prepod.Surname +" "+ prepod.Name[0] + ". " + prepod.MiddleName[0]+ "." ;
        }
    }
}
