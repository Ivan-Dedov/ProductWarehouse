
namespace ProductWarehouse
{
    partial class CartForm
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
            this.CartTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProceedToCheckoutButton = new System.Windows.Forms.Button();
            this.CartDataGridView = new System.Windows.Forms.DataGridView();
            this.CartTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CartTableLayoutPanel
            // 
            this.CartTableLayoutPanel.ColumnCount = 1;
            this.CartTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CartTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CartTableLayoutPanel.Controls.Add(this.ProceedToCheckoutButton, 0, 1);
            this.CartTableLayoutPanel.Controls.Add(this.CartDataGridView, 0, 0);
            this.CartTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.CartTableLayoutPanel.Name = "CartTableLayoutPanel";
            this.CartTableLayoutPanel.RowCount = 2;
            this.CartTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.CartTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.CartTableLayoutPanel.Size = new System.Drawing.Size(482, 453);
            this.CartTableLayoutPanel.TabIndex = 0;
            // 
            // ProceedToCheckoutButton
            // 
            this.ProceedToCheckoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProceedToCheckoutButton.Location = new System.Drawing.Point(3, 410);
            this.ProceedToCheckoutButton.Name = "ProceedToCheckoutButton";
            this.ProceedToCheckoutButton.Size = new System.Drawing.Size(476, 40);
            this.ProceedToCheckoutButton.TabIndex = 0;
            this.ProceedToCheckoutButton.Text = "Proceed to Checkout";
            this.ProceedToCheckoutButton.UseVisualStyleBackColor = true;
            this.ProceedToCheckoutButton.Click += new System.EventHandler(this.ProceedToCheckoutButton_Click);
            // 
            // CartDataGridView
            // 
            this.CartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CartDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CartDataGridView.Name = "CartDataGridView";
            this.CartDataGridView.ReadOnly = true;
            this.CartDataGridView.RowHeadersWidth = 51;
            this.CartDataGridView.RowTemplate.Height = 29;
            this.CartDataGridView.Size = new System.Drawing.Size(476, 401);
            this.CartDataGridView.TabIndex = 1;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.CartTableLayoutPanel);
            this.Name = "CartForm";
            this.Text = "Your Cart";
            this.CartTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CartTableLayoutPanel;
        private System.Windows.Forms.Button ProceedToCheckoutButton;
        private System.Windows.Forms.DataGridView CartDataGridView;
    }
}