using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// The form used for signing a new user up.
    /// </summary>
    public partial class SignUpForm : Form
    {
        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        public SignUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles clicking the Sign Up button.
        /// </summary>
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show(Messages.EmptyFullNameText, Messages.EmptyFullNameCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsPhoneCorrect(PhoneNumberTextBox.Text))
            {
                MessageBox.Show(Messages.IncorrectPhoneText, Messages.IncorrectPhoneCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show(Messages.EmptyAddressText, Messages.EmptyAddressCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show(Messages.EmptyEmailText, Messages.EmptyEmailCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsPasswordValid(PasswordTextBox.Text))
            {
                MessageBox.Show(Messages.InvalidPasswordText, Messages.InvalidPasswordCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ClientDatabase.Register(new Customer(FullNameTextBox.Text,
                    PhoneNumberTextBox.Text, AddressTextBox.Text, EmailTextBox.Text,
                    PasswordTextBox.Text));
                AuthorisationForm.SerializeCustomers();
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Messages.SignUpFailedCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Determines whether the input string is a valid 11-digit phone number.
        /// </summary>
        /// <param name="phone">The string to check.</param>
        /// <returns>true, if the string is a valid phone number; false, otherwise.</returns>
        private bool IsPhoneCorrect(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }
            if (phone.Length != 11)
            {
                return false;
            }

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the input string is a valid password.
        /// </summary>
        /// <param name="password">The string to check.</param>
        /// <returns>true, if the string is a valid password; false, otherwise.</returns>
        private bool IsPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                password.Length < 6 || password.Length > 20)
            {
                return false;
            }

            foreach (char c in password)
            {
                if (!Messages.AllowedPasswordChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}