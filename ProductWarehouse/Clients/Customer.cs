﻿using Newtonsoft.Json;
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
    public class Customer : Client
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        private Customer(string fullName, string phoneNumber, string address, string email)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
        }
        [JsonConstructor]
        public Customer(string fullName, string phoneNumber, string address, string email, byte[] password)
            : this(fullName, phoneNumber, address, email)
        {
            HashedPassword = password;
        }
        public Customer(string fullName, string phoneNumber, string address, string email, string password)
            : this(fullName, password, address, email)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] nameBytes = Encoding.UTF8.GetBytes(fullName);
            byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
            passwordBytes.CopyTo(bytes, 0);
            nameBytes.CopyTo(bytes, passwordBytes.Length);
            HashedPassword = SHA256.Create().ComputeHash(bytes);
        }
    }
}