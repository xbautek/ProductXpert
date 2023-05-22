using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductXpert.Classes
{
    internal class Materials
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public double Waga { get; set; }

        public Materials(string nazwa, string opis, double cena, double waga)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Waga = waga;
        }
    }
}
