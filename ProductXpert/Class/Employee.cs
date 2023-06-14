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

    /// <summary>
    /// Initializes a new instance of the Employee class using the provided data.
    /// </summary>
    /// <param name="lastName">The last name of the employee.</param>
    /// <param name="firstName">The first name of the employee.</param>
    /// <param name="username">The username of the employee.</param>
    /// <param name="password">The password of the employee.</param>
    public Employee(string lastName, string firstName, string username, string password)
    {
        LastName = lastName;
        FirstName = firstName;
        Username = username;
        Password = GeneratePasswordHash(password);
    }

    /// <summary>
    /// Initializes a new instance of the Employee class using the provided data.
    /// </summary>
    /// <param name="username">The username of the employee.</param>
    /// <param name="password">The password of the employee.</param>
    public Employee(string username, string password)
    {
        Username = username;
        Password = GeneratePasswordHash(password);
    }

    /// <summary>
    /// Generates a password hash using the SHA256 algorithm.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The password hash as a string.</returns>
    private string GeneratePasswordHash(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", "");

            return hash;
        }
    }
    /// <summary>
    /// Verifies the provided password by comparing it with the stored password hash.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <returns>True if the provided password is correct, otherwise false.</returns>
    public bool VerifyPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] inputHashBytes = sha256.ComputeHash(passwordBytes);

            string inputHash = BitConverter.ToString(inputHashBytes).Replace("-", "");

            return Password.Equals(inputHash);
        }
    }
}
