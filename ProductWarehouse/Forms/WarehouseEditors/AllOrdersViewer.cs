using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class AllOrdersViewer : Form
    {
        private bool displayActiveOnly = false;
        private List<Order> orders;

        public AllOrdersViewer()
        {
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;

            InitializeComponent();

            UpdateData();
        }

        private void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == OrdersDataGridView.Columns["ChangeOrderStatusButton"].Index &&
                e.RowIndex >= 0 && e.RowIndex < OrdersDataGridView.Rows.Count)
            {
                Order order = orders[e.RowIndex];
                OrderStatusEditor form = new OrderStatusEditor(order);
                form.ShowDialog();
                UpdateData();
            }
        }

        private void UpdateData()
        {
            orders = new List<Order>();
            foreach (Customer customer in ClientDatabase.Customers.Values)
            {
                foreach (Order order in customer.Orders)
                {
                    order.Customer = customer;
                    orders.Add(order);
                }
            }
            orders.Sort((x, y) => x.Date.CompareTo(y.Date));

            if (displayActiveOnly)
            {
                orders = orders.Where(x => !x.Status.HasFlag(OrderStatus.Closed)).ToList();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Order #");
            dt.Columns.Add("Ordered by");
            dt.Columns.Add("E-mail");
            dt.Columns.Add("Date");
            dt.Columns.Add("Items");
            dt.Columns.Add("Status");

            foreach (Order order in orders)
            {
                DataRow dr = dt.NewRow();
                dr[0] = order.OrderNumber;
                dr[1] = order.Customer.FullName;
                dr[2] = order.Customer.Email;
                dr[3] = order.Date;

                dr[4] = "";
                for(int i = 0; i < order.Products.Count; i++)
                {
                    OrderItem item = order.Products[i];
                    dr[4] += $"{item.Item.Name} (x{item.Count}) [{item.Price} per item]";
                    if (i < order.Products.Count - 1)
                    {
                        dr[4] += Environment.NewLine;
                    }
                }

                bool hasAnyFlags = false;
                if (order.Status.HasFlag(OrderStatus.Processed))
                {
                    dr[5] += "Processed";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Paid))
                {
                    dr[5] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Purchased";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Shipped))
                {
                    dr[5] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Shipped";
                    hasAnyFlags = true;
                }
                if (order.Status.HasFlag(OrderStatus.Closed))
                {
                    dr[5] += (hasAnyFlags ? Environment.NewLine : string.Empty) + "Closed";
                    hasAnyFlags = true;
                }
                if (!hasAnyFlags)
                {
                    dr[5] = "None";
                }

                dt.Rows.Add(dr);
            }

            OrdersDataGridView.Columns.Clear();
            OrdersDataGridView.DataSource = dt;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn()
            {
                Name = "ChangeOrderStatusButton",
                HeaderText = "Actions",
                Text = "Change Status",
                UseColumnTextForButtonValue = true,
            };
            OrdersDataGridView.Columns.Add(button);
            OrdersDataGridView.CellClick += OnClick;
        }

        private void ToggleDisplayButton_Click(object sender, EventArgs e)
        {
            displayActiveOnly = !displayActiveOnly;
            UpdateData();
        }
    }
}