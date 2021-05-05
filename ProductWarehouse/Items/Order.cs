using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a customer order of items from the Warehouse.
    /// </summary>
    public class Order
    {
        #region Properties
        public static List<long> OrderNumbers { get; set; } = new List<long>();

        public List<OrderItem> Products { get; set; }
        public long OrderNumber { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        #endregion

        #region Constructors
        [JsonConstructor]
        private Order(Customer customer, List<OrderItem> products, long orderNumber,
            DateTime date, OrderStatus status)
        {
            Customer = customer;
            Products = products;
            OrderNumber = orderNumber;
            Date = date;
            Status = status;
        }
        public Order(Customer customer, List<OrderItem> products)
        {
            Customer = customer;
            Products = products;
            OrderNumber = GetOrderNumber();
            Date = DateTime.Now;
            Status = OrderStatus.None;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new individual number for the order.
        /// </summary>
        private long GetOrderNumber()
        {
            Random r = new Random();
            DateTime t = DateTime.Now;
            string orderNumber;
            long number;

            do
            {
                orderNumber = t.Ticks.ToString()[9..] + r.Next(0, 100000).ToString();
            } while (!long.TryParse(orderNumber, out number) || OrderNumbers.Contains(number));
            return number;
        }
        #endregion
    }
}