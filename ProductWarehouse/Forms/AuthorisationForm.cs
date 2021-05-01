using System;
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
                this.Hide();
                WarehouseViewer form = new WarehouseViewer();
                form.Closed += (s, args) => this.Close();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.LoginFailedText, Messages.LoginFailedCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}