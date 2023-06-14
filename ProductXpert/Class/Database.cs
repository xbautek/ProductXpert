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
        /// <summary>
        /// Checks if a user with the given username and password exists.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if a user with the given username and password exists; otherwise, false.</returns>
        public static bool CheckUser(string username, string password)
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                Employee first = new Employee(username, password);
                bool isRecordExists = _context.Employees.Any(p => p.Username == first.Username && first.Password == p.Password);
                return isRecordExists;
            }
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="secondname">The second name of the employee.</param>
        /// <param name="username">The username of the employee.</param>
        /// <param name="password">The password of the employee.</param>
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
