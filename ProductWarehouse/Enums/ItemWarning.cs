using System;

namespace ProductWarehouse
{
    /// <summary>
    /// Contains the different warnings the user can accumulate
    /// while creating an item.
    /// </summary>
    [Flags]
    public enum ItemWarning
    {
        None = 0,
        NameRepeated = 1,
        InvalidVendorCode = 2,
        InvalidPrice = 4,
        ProductOutOfSection = 8,
    }
}