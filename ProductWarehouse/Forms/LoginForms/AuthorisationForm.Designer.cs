
namespace ProductWarehouse
{
    partial class AuthorisationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.SignUpSuggestionLabel = new System.Windows.Forms.Label();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(125, 34);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(327, 27);
            this.EmailTextBox.TabIndex = 0;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Location = new System.Drawing.Point(12, 35);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(98, 25);
            this.EmailLabel.TabIndex = 1;
            this.EmailLabel.Text = "E-mail:";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(12, 77);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(98, 25);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(125, 76);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(327, 27);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(181, 131);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(121, 38);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "Log in";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // SignUpSuggestionLabel
            // 
            this.SignUpSuggestionLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignUpSuggestionLabel.ForeColor = System.Drawing.Color.Gray;
            this.SignUpSuggestionLabel.Location = new System.Drawing.Point(141, 193);
            this.SignUpSuggestionLabel.Name = "SignUpSuggestionLabel";
            this.SignUpSuggestionLabel.Size = new System.Drawing.Size(202, 66);
            this.SignUpSuggestionLabel.TabIndex = 5;
            this.SignUpSuggestionLabel.Text = "Don\'t have an account yet? Click below to sign up!";
            this.SignUpSuggestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(193, 254);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(94, 29);
            this.SignUpButton.TabIndex = 6;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // AuthorisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.SignUpSuggestionLabel);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EmailTextBox);
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "AuthorisationForm";
            this.Text = "Authorise";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorisationForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label SignUpSuggestionLabel;
        private System.Windows.Forms.Button SignUpButton;
    }
}