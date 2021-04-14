using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a product - an item that can be held inside a Section.
    /// </summary>
    [Serializable]
    public class Product : IStorable, IProduct
    {
        #region Fields
        private double price;
        private int leftInStock;
        #endregion

        #region Properties
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Vendor Code")]
        public string VendorCode { get; set; }

        [DisplayName("Price")]
        public double Price
        {
            get
            {
                return Math.Round(price, 2);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be lower than zero.");
                }
                price = value;
            }
        }

        [DisplayName("Left In Stock")]
        public int LeftInStock
        {
            get
            {
                return leftInStock;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of items left in stock cannot be lower than zero.");
                }
                leftInStock = value;
            }
        }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Photo")]
        [JsonConverter(typeof(UtilityClasses.ImageConverter))]
        public Image Photo { get; set; }

        [Browsable(false)]
        public IContainer Parent { get; set; }
        #endregion

        #region Constructors
        private Product() { }
        public Product(IContainer parent, string name,
            string vendorCode, double price, int leftInStock)
        {
            Parent = parent;
            Name = name;
            VendorCode = vendorCode;
            Price = price;
            LeftInStock = leftInStock;
        }
        public Product(IContainer parent, string name,
            string vendorCode, double price, int leftInStock, string description)
            : this(parent, name, vendorCode, price, leftInStock)
        {
            Description = description;
        }
        public Product(IContainer parent, string name,
            string vendorCode, double price, int leftInStock, Bitmap photo)
            : this(parent, name, vendorCode, price, leftInStock)
        {
            Photo = photo;
        }
        public Product(IContainer parent, string name,
            string vendorCode, double price, int leftInStock,
            string description, Image photo)
            : this(parent, name, vendorCode, price, leftInStock, description)
        {
            Photo = photo;
        }
        #endregion
    }
}