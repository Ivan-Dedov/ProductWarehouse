using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// The form used to authorise the user.
    /// </summary>
    public partial class AuthorisationForm : Form
    {
        public AuthorisationForm()
        {
            InitializeComponent();
            DeserializeDatabase();
        }

        /// <summary>
        /// Handles clicking the Sign Up button: opens a new form to register
        /// a new user.
        /// </summary>
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm form = new SignUpForm();
            form.Closed += (s, args) => this.Show();
            form.Show();
        }
        /// <summary>
        /// Handles clicking the Log In button: checks the validity of the user's e-mail and
        /// password, and opens a WarehouseViewer form.
        /// </summary>
        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (ClientDatabase.Authorize(EmailTextBox.Text, PasswordTextBox.Text))
            {
                Client client = ClientDatabase.GetClient(EmailTextBox.Text);

                this.Hide();
                WarehouseViewer form = new WarehouseViewer(client);
                form.Closed += (s, args) => this.Close();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.LoginFailedText, Messages.LoginFailedCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SerializeCustomers()
        {
            foreach (var kvp in ClientDatabase.Customers)
            {
                Customer c = kvp.Value;
                foreach (var order in c.Orders)
                {
                    foreach (var item in order.Products)
                    {
                        item.Item.Parent = null;
                    }
                }
            }

            using StreamWriter sw = new StreamWriter(Constants.CustomersDirectory);
            string serializedCustomers = JsonConvert.SerializeObject(ClientDatabase.Customers);
            sw.Write(serializedCustomers);
        }

        private void AuthorisationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeCustomers();
        }

        private void DeserializeDatabase()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Constants.CustomersDirectory))
                {
                    string line = sr.ReadToEnd();
                    ClientDatabase.Customers = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(line);
                }

                foreach(var customer in ClientDatabase.Customers)
                {
                    foreach(var order in customer.Value.Orders)
                    {
                        Order.OrderNumbers.Add(order.OrderNumber);
                    }
                }
            }
            catch
            {
                MessageBox.Show(Messages.CouldNotDeserializeText, Messages.CouldNotDeserializeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}