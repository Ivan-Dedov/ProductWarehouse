using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProductWarehouse
{
    /// <summary>
    /// The database that stores the information of all clients and the salesman for the warehouse.
    /// </summary>
    [Serializable]
    public static class ClientDatabase
    {
        /// <summary>
        /// The salesman of the warehouse.
        /// </summary>
        private static readonly Salesman salesman =
            new Salesman(Constants.SalesmanFullName,
                         Constants.SalesmanPhoneNumber,
                         Constants.SalesmanAddress,
                         Constants.SalesmanEmail,
                         Constants.SalesmanPassword);
        /// <summary>
        /// The dictionary containing all the registered customers. E-mails represent keys.
        /// </summary>
        private static Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

        /// <summary>
        /// Registers a new client in the database.
        /// </summary>
        /// <param name="customer">The client to register.</param>
        public static void Register(Customer customer)
        {
            if (customers.ContainsKey(customer.Email) || salesman.Email == customer.Email)
            {
                throw new ArgumentException("A client with this e-mail already exists.");
            }
            customers.Add(customer.Email, customer);
        }
        /// <summary>
        /// Deletes the specified client from the database.
        /// </summary>
        /// <param name="customer">The client to remove.</param>
        public static void Delete(Customer customer)
        {
            if (!customers.ContainsKey(customer.Email))
            {
                throw new KeyNotFoundException("A client with this e-mail does not exist.");
            }
            customers.Remove(customer.Email);
        }

        /// <summary>
        /// Authorizes a client by checking their login and password.
        /// </summary>
        /// <param name="login">The login of the client.</param>
        /// <param name="password">The password of the client.</param>
        /// <returns>true, if the client has been authorized successfully; false, otherwise.</returns>
        public static bool Authorize(string login, string password)
        {
            if (customers.ContainsKey(login))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] nameBytes = Encoding.UTF8.GetBytes(customers[login].FullName);
                byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
                passwordBytes.CopyTo(bytes, 0);
                nameBytes.CopyTo(bytes, passwordBytes.Length);

                byte[] hashedPassword = SHA256.Create().ComputeHash(bytes);

                return Enumerable.SequenceEqual(customers[login].HashedPassword, hashedPassword);
            }
            else
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] nameBytes = Encoding.UTF8.GetBytes(salesman.FullName);
                byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
                passwordBytes.CopyTo(bytes, 0);
                nameBytes.CopyTo(bytes, passwordBytes.Length);

                byte[] hashedPassword = SHA256.Create().ComputeHash(bytes);

                return Enumerable.SequenceEqual(salesman.HashedPassword, hashedPassword);
            }
        }
    }
}