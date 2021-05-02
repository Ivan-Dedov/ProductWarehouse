using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class AddToCartMenu : Form
    {
        private Order order;
        private Product product;

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

        private void ItemCountNumericUD_ValueChanged(object sender, EventArgs e)
        {
            PriceValueLabel.Text =
                $"{product.Price} x {(int)ItemCountNumericUD.Value} = " +
                $"{Math.Round(product.Price * (int)ItemCountNumericUD.Value, 2)}";
        }
    }
}