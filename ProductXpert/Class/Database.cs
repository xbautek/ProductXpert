using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using ProductXpert.ViewModel;


namespace ProductXpert.Class
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
                Employee first = new Employee(username, password);
                bool isRecordExists = _context.Employees.Any(p => p.Username == first.Username && first.Password == p.Password);
                return isRecordExists;
            }
        }

        public static void AddUser(string name, string secondname, string username, string password)
        {
            Employee pracownik = new Employee(name, secondname, username, password);


            using (ProductXpertContext _context = new ProductXpertContext())
            {
                _context.Employees.Add(pracownik);
                _context.SaveChanges();
            }


        }


    }
}
