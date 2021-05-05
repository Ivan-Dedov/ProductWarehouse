using System;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents the possible states of a customer order.
    /// </summary>
    [Flags]
    public enum OrderStatus
    {
        None = 0,
        Processed = 1,
        Purchased = 2,
        Shipped = 4,
        Closed = 8,
    }
}