using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class OrdersViewer : Form
    {
        private Customer customer;

        public OrdersViewer(Customer customer)
        {
            this.customer = customer;

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

            foreach (var order in customer.Orders)
            {
                DataRow dr = dt.NewRow();
                dr[0] = order.OrderNumber;

                double total = 0;
                dr[1] = string.Empty;
                for (int i = 0; i < order.Products.Count; i++)
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

                bool hasAnyFlags = false;
                if (order.Status.HasFlag(OrderStatus.Processed))
                {
                    dr[4] += "Processed";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Paid))
                {
                    dr[4] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Purchased";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Shipped))
                {
                    dr[4] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Shipped";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Closed))
                {
                    dr[4] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Closed";
                    hasAnyFlags = true;
                }
                if (!hasAnyFlags)
                {
                    dr[4] = "None";
                }

                dt.Rows.Add(dr);
            }

            OrdersGridView.DataSource = dt;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn()
            {
                Name = "PurchaseButton",
                HeaderText = "Actions",
                Text = "Purchase",
                UseColumnTextForButtonValue = true
            };
            OrdersGridView.Columns.Add(button);
            OrdersGridView.CellClick += OnClick;
        }

        private void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == OrdersGridView.Columns["PurchaseButton"].Index &&
                e.RowIndex >= 0 && e.RowIndex < OrdersGridView.Rows.Count)
            {
                Order order = customer.Orders[e.RowIndex];
                if (order.Status.HasFlag(OrderStatus.Processed))
                {
                    order.Status |= OrderStatus.Paid;
                }
                else
                {
                    MessageBox.Show(Messages.CannotPayText, Messages.CannotPayCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}