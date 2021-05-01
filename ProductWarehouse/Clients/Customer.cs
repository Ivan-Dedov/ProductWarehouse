using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a customer who can purchase and order items from the Warehouse.
    /// </summary>
    [Serializable]
    public class Customer
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte[] HashedPassword { get; protected set; }
        public List<Order> Orders { get; set; }
        
        public Customer(string fullName, string phoneNumber, string address, string email, string password)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            HashedPassword = SHA256.Create().ComputeHash(passwordBytes);
        }
    }
}