using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Security.Cryptography;

namespace ProductXpert.Class;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Employee(string lastName, string firstName, string username, string password)
    {
        LastName = lastName;
        FirstName = firstName;
        Username = username;
        Password = GeneratePasswordHash(password);
    }

    public Employee(string username, string password)
    {
        Username = username;
        Password = GeneratePasswordHash(password);
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
            return Password.Equals(inputHash);
        }
    }
}
