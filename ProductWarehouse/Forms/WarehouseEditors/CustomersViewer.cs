using System;
using System.Data;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class CustomersViewer : Form
    {
        public CustomersViewer()
        {
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;

            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("#");
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Phone Number");
            dt.Columns.Add("Address");
            dt.Columns.Add("E-mail");
            dt.Columns.Add("Total Amount Paid");

            int index = 1;
            foreach (Customer customer in ClientDatabase.Customers.Values)
            {
                DataRow dr = dt.NewRow();
                dr[0] = index++;
                dr[1] = customer.FullName;
                dr[2] = customer.PhoneNumber;
                dr[3] = customer.Address;
                dr[4] = customer.Email;
                dr[5] = customer.TotalAmountPaid;
                dt.Rows.Add(dr);
            }

            ClientsDataGridView.DataSource = dt;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn()
            {
                Name = "ViewOrdersButton",
                HeaderText = "Actions",
                Text = "View Orders",
                UseColumnTextForButtonValue = true
            };
            ClientsDataGridView.Columns.Add(button);
            ClientsDataGridView.CellClick += OnClick;
        }

        private void OnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ClientsDataGridView.Columns["ViewOrdersButton"].Index &&
                e.RowIndex >= 0 && e.RowIndex < ClientsDataGridView.Rows.Count)
            {
                Customer customer = ClientDatabase.Customers[ClientsDataGridView[5, e.RowIndex].Value.ToString()];

                OrdersViewer form = new OrdersViewer(true, customer);
                form.ShowDialog();
            }
        }
    }
}