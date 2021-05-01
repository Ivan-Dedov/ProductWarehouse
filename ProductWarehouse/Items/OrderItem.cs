namespace ProductWarehouse
{
    /// <summary>
    /// Represents an item within an order.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The item to be ordered.
        /// </summary>
        public Product Item { get; set; }
        /// <summary>
        /// The number of items to order.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// The price of the item to order.
        /// </summary>
        public double Price { get; private set; }

        public OrderItem(Product item, int count)
        {
            Item = item;
            Count = count;
            Price = item.Price;
        }
    }
}