using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes the form which displays the customer's cart.
    /// </summary>
    public partial class CartForm : Form
    {
        /// <summary>
        /// The customer whose cart it is.
        /// </summary>
        private Customer customer;
        /// <summary>
        /// The current order with all the items.
        /// </summary>
        private Order order;

        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        /// <param name="customer">The customer whose cart to show.</param>
        /// <param name="order">The current active order of this customer (not added to the overall
        /// order lits).</param>
        public CartForm(Customer customer, Order order)
        {
            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;
            MaximumSize = SystemInformation.PrimaryMonitorSize;

            this.customer = customer;
            this.order = order;

            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Count");
            dt.Columns.Add("Total Price");

            foreach (var item in order.Products)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Item.Name;
                dr[1] = item.Price;
                dr[2] = item.Count;
                dr[3] = Math.Round(item.Price * item.Count, 2);
                dt.Rows.Add(dr);
            }

            CartDataGridView.DataSource = dt;
        }

        /// <summary>
        /// Forms a new Order from the items in the cart.
        /// </summary>
        private void ProceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            if (order.Products.Count > 0)
            {
                customer.Orders.Add(order);
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                DialogResult = DialogResult.No;
                MessageBox.Show(Messages.EmptyCartText, Messages.EmptyCartCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}