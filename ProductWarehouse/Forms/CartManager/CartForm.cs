using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class CartForm : Form
    {
        private Customer customer;
        private Order order;

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
                dr[3] = item.Price * item.Count;
                dt.Rows.Add(dr);
            }

            CartDataGridView.DataSource = dt;
        }

        private void ProceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            if (order.Products.Count > 0)
            {
                customer.Orders.Add(order);
                Close();
            }
            else
            {
                MessageBox.Show(Messages.EmptyCartText, Messages.EmptyCartCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}