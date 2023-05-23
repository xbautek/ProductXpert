using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductXpert.Classes
{
    internal class Materials
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Wage { get; set; }

        public Materials(string n, string d, double p, double w)
        {
            Name = n;
            Description = d; 
            Price = p; 
            Wage = w;
        }
    }
}
