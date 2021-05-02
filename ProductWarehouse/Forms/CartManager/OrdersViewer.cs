using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class OrdersViewer : Form
    {
        public OrdersViewer(Customer customer)
        {
            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;
            MaximumSize = SystemInformation.PrimaryMonitorSize;

            InitializeComponent();

            this.Text = customer.FullName;

            DataTable dt = new DataTable();
            dt.Columns.Add("Order #");
            dt.Columns.Add("Products");
            dt.Columns.Add("Total Price");
            dt.Columns.Add("Order Date");
            dt.Columns.Add("Status");
            dt.Columns.Add("Actions");

            foreach (var order in customer.Orders)
            {
                DataRow dr = dt.NewRow();
                dr[0] = order.OrderNumber;

                double total = 0;
                dr[1] = string.Empty;
                for(int i = 0; i < order.Products.Count; i++)
                {
                    OrderItem item = order.Products[i];
                    dr[1] += $"{item.Item.Name} (x{item.Count}) [{item.Price} per item]";
                    if (i < order.Products.Count - 1)
                    {
                        dr[1] += Environment.NewLine;
                    }
                    total += item.Count * item.Price;
                }

                dr[2] = Math.Round(total, 2);
                dr[3] = order.Date;
                dr[4] = order.Status;
                dr[5] = string.Empty;

                dt.Rows.Add(dr);
            }

            OrdersGridView.DataSource = dt;
        }
    }
}