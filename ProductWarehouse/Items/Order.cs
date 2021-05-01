using System;
using System.Collections.Generic;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a customer order of items from the Warehouse.
    /// </summary>
    public class Order
    {
        private static int orderNumber = 0;

        public List<OrderItem> Products { get; set; }
        public int OrderNumber { get; }
        public Customer Customer { get; }
        public DateTime Date { get; }
        public OrderState State { get; set; }

        public Order(Customer customer, List<OrderItem> products)
        {
            Customer = customer;
            Products = products;
            OrderNumber = orderNumber++;
            Date = DateTime.Now;
            State = OrderState.None;
        }
    }
}