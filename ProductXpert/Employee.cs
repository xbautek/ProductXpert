using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProductXpert
{
    public class Employee
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; private set; }

        public Employee(string name, string secondName, string login, string password)
        {
            Name = name;
            SecondName = secondName;
            Username = login;
            PasswordHash = GeneratePasswordHash(password);
        }

        public Employee(string login, string password)
        {
            Username = login;
            PasswordHash = GeneratePasswordHash(password);
        }

        private string GeneratePasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Konwertuj hasło na tablicę bajtów
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Oblicz skrót hasła
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Konwertuj skrót na zapis szesnastkowy
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                return hash;
            }
        }

        public bool VerifyPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Konwertuj wprowadzone hasło na tablicę bajtów
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Oblicz skrót dla wprowadzonego hasła
                byte[] inputHashBytes = sha256.ComputeHash(passwordBytes);

                // Konwertuj skrót wprowadzonego hasła na zapis szesnastkowy
                string inputHash = BitConverter.ToString(inputHashBytes).Replace("-", "");

                // Porównaj skróty hasła
                return PasswordHash.Equals(inputHash);
            }
        }
    }
}
