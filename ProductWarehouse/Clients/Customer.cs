using Newtonsoft.Json;
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
        #region Properties
        /// <summary>
        /// The total amount of money this Customer has paid for in all of the orders.
        /// </summary>
        public double TotalAmountPaid
        {
            get
            {
                double totalAmountPaid = 0;
                foreach (var order in Orders)
                {
                    if (order.Status.HasFlag(OrderStatus.Purchased))
                    {
                        foreach (var item in order.Products)
                        {
                            totalAmountPaid += item.Price * item.Count;
                        }
                    }
                }
                return Math.Round(totalAmountPaid, 2);
            }
        }
        public List<Order> Orders { get; set; } = new List<Order>();
        #endregion

        #region Constructors
        private Customer(string fullName, string phoneNumber, string address, string email)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
        }

        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="fullName">Their full name.</param>
        /// <param name="phoneNumber">Their phone number.</param>
        /// <param name="address">Their address.</param>
        /// <param name="email">Their e-mail.</param>
        /// <param name="password">Their password (hashed).</param>
        [JsonConstructor]
        public Customer(string fullName, string phoneNumber, string address, string email, byte[] password)
            : this(fullName, phoneNumber, address, email)
        {
            HashedPassword = password;
        }

        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="fullName">Their full name.</param>
        /// <param name="phoneNumber">Their phone number.</param>
        /// <param name="address">Their address.</param>
        /// <param name="email">Their e-mail.</param>
        /// <param name="password">Their password (unhashed).</param>
        public Customer(string fullName, string phoneNumber, string address, string email, string password)
            : this(fullName, phoneNumber, address, email)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] nameBytes = Encoding.UTF8.GetBytes(fullName);
            byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
            passwordBytes.CopyTo(bytes, 0);
            nameBytes.CopyTo(bytes, passwordBytes.Length);
            HashedPassword = SHA256.Create().ComputeHash(bytes);
        }
        #endregion
    }
}