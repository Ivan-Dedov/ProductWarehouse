using System;
using System.Security.Cryptography;
using System.Text;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents the salesman for the Warehouse.
    /// </summary>
    [Serializable]
    public class Salesman : Client
    {
        public Salesman(string fullName, string phoneNumber, string address, string email, string password)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] nameBytes = Encoding.UTF8.GetBytes(fullName);
            byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
            passwordBytes.CopyTo(bytes, 0);
            nameBytes.CopyTo(bytes, passwordBytes.Length);
            HashedPassword = SHA256.Create().ComputeHash(bytes);
        }
    }
}