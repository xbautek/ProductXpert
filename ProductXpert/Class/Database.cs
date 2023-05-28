using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ProductXpert.ViewModel;


namespace ProductXpert
{
    internal class Database
    {
        public Database()
        {
        }

        public static bool CheckUser(string username, string password)
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                Pracownicy first = new Pracownicy(username, password);
                bool isRecordExists = _context.Pracownicy.Any(p => p.Login == first.Login && first.Haslo == p.Haslo);
                return isRecordExists;
            }
        }

        public static void AddUser(string name, string secondname, string username, string password)
        {

            Pracownicy pracownik = new Pracownicy(name, secondname, username, password);


            using (ProductXpertContext _context = new ProductXpertContext())
                {
                    _context.Pracownicy.Add(pracownik);
                    _context.SaveChanges();
                }

            
        }

        
    }
}
