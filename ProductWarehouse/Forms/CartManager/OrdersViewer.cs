using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes a form where the user can see all of their orders.
    /// </summary>
    public partial class OrdersViewer : Form
    {
        /// <summary>
        /// The customer whose orders to see.
        /// </summary>
        private Customer customer;
        /// <summary>
        /// Boolean variable: true, if the user logged in is a salesman; false, otherwise.
        /// </summary>
        private bool viewAsSalesman;

        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        /// <param name="viewAsSalesman">Should the form be displayed in salesman mode.</param>
        /// <param name="customer">The customer whose orders to show.</param>
        public OrdersViewer(bool viewAsSalesman, Customer customer)
        {
            this.viewAsSalesman = viewAsSalesman;
            this.customer = customer;

            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;
            MaximumSize = SystemInformation.PrimaryMonitorSize;

            InitializeComponent();

            this.Text = customer.FullName + "\'s Orders";

            UpdataData();
        }

        /// <summary>
        /// Updates the data in the data grid.
        /// </summary>
        private void UpdataData()
        {
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
                if (order.Status.HasFlag(OrderStatus.Purchased))
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

            OrdersDataGridView.Columns.Clear();
            OrdersDataGridView.DataSource = dt;

            if (!viewAsSalesman)
            {
                DataGridViewButtonColumn button = new DataGridViewButtonColumn()
                {
                    Name = "PurchaseButton",
                    HeaderText = "Actions",
                    Text = "Purchase",
                    UseColumnTextForButtonValue = true
                };
                OrdersDataGridView.Columns.Add(button);
                OrdersDataGridView.CellClick -= OnClick;
                OrdersDataGridView.CellClick += OnClick;
            }
        }

        /// <summary>
        /// Handles clicking the Purchase button.
        /// </summary>
        private void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == OrdersDataGridView.Columns["PurchaseButton"].Index &&
                e.RowIndex >= 0 && e.RowIndex < OrdersDataGridView.Rows.Count)
            {
                Order order = customer.Orders[e.RowIndex];
                if (order.Status.HasFlag(OrderStatus.Processed) &&
                    !order.Status.HasFlag(OrderStatus.Purchased) &&
                    !order.Status.HasFlag(OrderStatus.Shipped) &&
                    !order.Status.HasFlag(OrderStatus.Closed))
                {
                    order.Status |= OrderStatus.Purchased;
                    UpdataData();
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