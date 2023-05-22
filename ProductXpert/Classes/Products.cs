using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductXpert.Classes
{
    internal class Products
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int MinimalAmount { get; set; }

        public Products(string d, string n, double p, int a, int ma)
        {
            Description = d;
            Name = n;
            Price = p;
            Amount = a;
            MinimalAmount = ma;
        }


    }
}
