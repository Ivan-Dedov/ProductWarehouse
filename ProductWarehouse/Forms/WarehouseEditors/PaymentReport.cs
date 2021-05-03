using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    public partial class PaymentReport : Form
    {
        public PaymentReport()
        {
            InitializeComponent();
        }

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