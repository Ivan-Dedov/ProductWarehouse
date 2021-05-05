using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes an item status editor form.
    /// </summary>
    public partial class OrderStatusEditor : Form
    {
        /// <summary>
        /// The order with which to work.
        /// </summary>
        private Order order;

        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        /// <param name="order">The order with which to work.</param>
        public OrderStatusEditor(Order order)
        {
            this.order = order;

            InitializeComponent();

            bool isProcessed = order.Status.HasFlag(OrderStatus.Processed);
            ProcessedCheckBox.Checked = isProcessed;
            ProcessedCheckBox.Enabled = !isProcessed;
            if (!isProcessed)
            {
                ShippedCheckBox.Enabled = false;
                ClosedCheckBox.Enabled = false;
            }
            else
            {
                if (order.Status.HasFlag(OrderStatus.Purchased))
                {
                    bool isShipped = order.Status.HasFlag(OrderStatus.Shipped);
                    ShippedCheckBox.Checked = isShipped;
                    ShippedCheckBox.Enabled = !isShipped;
                    if (!isShipped)
                    {
                        ClosedCheckBox.Enabled = false;
                    }
                    else
                    {
                        bool isClosed = order.Status.HasFlag(OrderStatus.Closed);
                        ClosedCheckBox.Checked = isClosed;
                        ClosedCheckBox.Enabled = !isClosed;
                    }
                }
                else
                {
                    ShippedCheckBox.Enabled = false;
                    ClosedCheckBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Handles clicking the Confirm changes button.
        /// </summary>
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
            this.Close();
        }
    }
}