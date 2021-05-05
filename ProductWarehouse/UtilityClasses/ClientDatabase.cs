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
        #region Properties
        /// <summary>
        /// The salesman of the warehouse.
        /// </summary>
        public static Salesman Salesman { get; set; } =
            new Salesman(Constants.SalesmanFullName,
                         Constants.SalesmanPhoneNumber,
                         Constants.SalesmanAddress,
                         Constants.SalesmanEmail,
                         Constants.SalesmanPassword);
        /// <summary>
        /// The dictionary containing all the registered customers. E-mails represent keys.
        /// </summary>
        public static Dictionary<string, Customer> Customers { get; set; } = new Dictionary<string, Customer>();
        #endregion

        #region Methods
        /// <summary>
        /// Registers a new client in the database.
        /// </summary>
        /// <param name="customer">The client to register.</param>
        public static void Register(Customer customer)
        {
            if (Customers.ContainsKey(customer.Email) || Salesman.Email == customer.Email)
            {
                throw new ArgumentException("A client with this e-mail already exists.");
            }
            Customers.Add(customer.Email, customer);
        }
        /// <summary>
        /// Deletes the specified client from the database.
        /// </summary>
        /// <param name="customer">The client to remove.</param>
        public static void Delete(Customer customer)
        {
            if (!Customers.ContainsKey(customer.Email))
            {
                throw new KeyNotFoundException("A client with this e-mail does not exist.");
            }
            Customers.Remove(customer.Email);
        }

        /// <summary>
        /// Authorizes a client by checking their login and password.
        /// </summary>
        /// <param name="login">The login of the client.</param>
        /// <param name="password">The password of the client.</param>
        /// <returns>true, if the client has been authorized successfully; false, otherwise.</returns>
        public static bool Authorize(string login, string password)
        {
            if (Customers.ContainsKey(login))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] nameBytes = Encoding.UTF8.GetBytes(Customers[login].FullName);
                byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
                passwordBytes.CopyTo(bytes, 0);
                nameBytes.CopyTo(bytes, passwordBytes.Length);

                byte[] hashedPassword = SHA256.Create().ComputeHash(bytes);

                return Enumerable.SequenceEqual(Customers[login].HashedPassword, hashedPassword);
            }
            else
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] nameBytes = Encoding.UTF8.GetBytes(Salesman.FullName);
                byte[] bytes = new byte[passwordBytes.Length + nameBytes.Length];
                passwordBytes.CopyTo(bytes, 0);
                nameBytes.CopyTo(bytes, passwordBytes.Length);

                byte[] hashedPassword = SHA256.Create().ComputeHash(bytes);

                return Enumerable.SequenceEqual(Salesman.HashedPassword, hashedPassword);
            }
        }

        /// <summary>
        /// Returns the customer based on their e-mail. Throws an exception if none found.
        /// </summary>
        /// <param name="email">The email to look up.</param>
        /// <returns>The customer with this e-mail, if they exist. Throws an exception, otherwise.</returns>
        public static Client GetClient(string email)
        {
            if (Customers.ContainsKey(email))
            {
                return Customers[email];
            }
            if (Salesman.Email == email)
            {
                return Salesman;
            }
            throw new KeyNotFoundException("No client with such a name exists.");
        }
        #endregion
    }
}