using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes a form which creates a report about paid orders.
    /// </summary>
    public partial class PaymentReport : Form
    {
        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        public PaymentReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles clicking the Export button.
        /// </summary>
        private void ExportReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                double amountPaid = double.Parse(AmountPaidTextBox.Text);
                if (amountPaid < 0)
                {
                    throw new ArgumentException("Amount paid has to be non-negative.");
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Save your CSV report",
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                        sw.Write(GetCsv(amountPaid));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Builds the CSV file.
        /// </summary>
        /// <param name="amountPaid">The threshold amount of money.</param>
        /// <returns>The string to put in the csv.</returns>
        private string GetCsv(double amountPaid)
        {
            string res = "Customer Name,E-mail,Address,Phone Number,Total Amount Paid,Threshold Amount" + Environment.NewLine;

            List<Customer> customers = new List<Customer>();
            foreach (Customer customer in ClientDatabase.Customers.Values)
            {
                if (customer.TotalAmountPaid > amountPaid)
                {
                    customers.Add(customer);
                }
            }
            customers.Sort((x, y) => x.TotalAmountPaid.CompareTo(y.TotalAmountPaid) * (-1));

            foreach (var customer in customers)
            {
                res += $"\"{customer.FullName.Replace("\"", "\"\"")}\"," +
                       $"\"{customer.Email.Replace("\"", "\"\"")}\"," +
                       $"\"{customer.Address.Replace("\"", "\"\"")}\"," +
                       $"\"{customer.PhoneNumber}\"," +
                       $"{customer.TotalAmountPaid.ToString().Replace(',', '.')},{amountPaid}" + Environment.NewLine;
            }

            return res;
        }
    }
}