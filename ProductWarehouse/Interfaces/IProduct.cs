using System.Drawing;

namespace ProductWarehouse
{
    public interface IProduct
    {
        string Name { get; set; }
        string VendorCode { get; set; }
        double Price { get; set; }
        int LeftInStock { get; set; }
        string Description { get; set; }
        Image Photo { get; set; }
    }
}