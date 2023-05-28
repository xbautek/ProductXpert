using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProductXpert;

public partial class Pracownicy
{
    public int Id { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public Pracownicy()
    {
    }

    public Pracownicy(string name, string secondName, string login, string password)
    {
        Imie = name;
        Nazwisko = secondName;
        Login = login;
        Haslo = GeneratePasswordHash(password);
    }

    public Pracownicy(string login, string password)
    {
        Login = login;
        Haslo = GeneratePasswordHash(password);
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
            return Haslo.Equals(inputHash);
        }
    }
}
