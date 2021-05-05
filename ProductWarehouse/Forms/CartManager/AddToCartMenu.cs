using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes a menu for adding an item to the Cart.
    /// </summary>
    public partial class AddToCartMenu : Form
    {
        /// <summary>
        /// The order to which to add the item.
        /// </summary>
        private Order order;
        /// <summary>
        /// The selected item.
        /// </summary>
        private Product product;

        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        /// <param name="order">The order to which to add the item.</param>
        /// <param name="product">The selected item.</param>
        public AddToCartMenu(Order order, Product product)
        {
            this.order = order;
            this.product = product;

            InitializeComponent();

            ProductNameValueLabel.Text = product.Name;
            VendorCodeLabel.Text = product.VendorCode;

            DescriptionValueLabel.Text = product.Description;
            ProductPhotoPictureBox.Image = product.Photo;

            PriceValueLabel.Text =
                $"{product.Price} x {(int)ItemCountNumericUD.Value} = " +
                $"{Math.Round(product.Price * (int)ItemCountNumericUD.Value, 2)}";
            ItemCountNumericUD.Maximum = product.LeftInStock;
        }

        /// <summary>
        /// Handles clicking the Add To Cart button.
        /// </summary>
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if ((int)ItemCountNumericUD.Value > 0)
            {
                order.Products.Add(new OrderItem(product, (int)ItemCountNumericUD.Value));
                this.Close();
            }
            else
            {
                MessageBox.Show(Messages.ProductAddingFailedText, Messages.ProductAddingFailedCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Calculates the price of the selected item (depending on its count).
        /// </summary>
        private void ItemCountNumericUD_ValueChanged(object sender, EventArgs e)
        {
            PriceValueLabel.Text =
                $"{product.Price} x {(int)ItemCountNumericUD.Value} = " +
                $"{Math.Round(product.Price * (int)ItemCountNumericUD.Value, 2)}";
        }
    }
}