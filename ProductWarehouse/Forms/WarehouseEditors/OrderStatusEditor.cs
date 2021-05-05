using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class OrderStatusEditor : Form
    {
        private Order order;

        public OrderStatusEditor(Order order)
        {
            this.order = order;

            InitializeComponent();

            ProcessedCheckBox.Checked = order.Status.HasFlag(OrderStatus.Processed);
            ShippedCheckBox.Checked = order.Status.HasFlag(OrderStatus.Shipped);
            ClosedCheckBox.Checked = order.Status.HasFlag(OrderStatus.Closed);
        }

        private void ConfirmChangesButton_Click(object sender, EventArgs e)
        {
            if (ProcessedCheckBox.Checked)
            {
                order.Status |= OrderStatus.Processed;
            }
            else
            {
                order.Status &= ~OrderStatus.Processed;
            }

            if (ShippedCheckBox.Checked)
            {
                order.Status |= OrderStatus.Shipped;
            }
            else
            {
                order.Status &= ~OrderStatus.Shipped;
            }

            if (ClosedCheckBox.Checked)
            {
                order.Status |= OrderStatus.Closed;
            }
            else
            {
                order.Status &= ~OrderStatus.Closed;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}