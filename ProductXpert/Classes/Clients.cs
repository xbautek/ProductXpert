using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductXpert.Classes
{
    internal class Clients
    {
        public string CompanyName { get; set; }
        public byte PhoneNumber { get; set; }
        public string Email { get; set; }

        public Clients(string c, byte p, string e)
        {
            CompanyName = c;
            PhoneNumber = p;
            Email = e;
        }
    }
}
