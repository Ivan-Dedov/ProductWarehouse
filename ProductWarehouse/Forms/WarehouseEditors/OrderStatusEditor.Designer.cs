
namespace ProductWarehouse
{
    partial class OrderStatusEditor
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
            this.ProcessedCheckBox = new System.Windows.Forms.CheckBox();
            this.ShippedCheckBox = new System.Windows.Forms.CheckBox();
            this.ClosedCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfirmChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProcessedCheckBox
            // 
            this.ProcessedCheckBox.AutoSize = true;
            this.ProcessedCheckBox.Location = new System.Drawing.Point(87, 31);
            this.ProcessedCheckBox.Name = "ProcessedCheckBox";
            this.ProcessedCheckBox.Size = new System.Drawing.Size(97, 24);
            this.ProcessedCheckBox.TabIndex = 0;
            this.ProcessedCheckBox.Text = "Processed";
            this.ProcessedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShippedCheckBox
            // 
            this.ShippedCheckBox.AutoSize = true;
            this.ShippedCheckBox.Location = new System.Drawing.Point(87, 61);
            this.ShippedCheckBox.Name = "ShippedCheckBox";
            this.ShippedCheckBox.Size = new System.Drawing.Size(86, 24);
            this.ShippedCheckBox.TabIndex = 2;
            this.ShippedCheckBox.Text = "Shipped";
            this.ShippedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClosedCheckBox
            // 
            this.ClosedCheckBox.AutoSize = true;
            this.ClosedCheckBox.Location = new System.Drawing.Point(87, 91);
            this.ClosedCheckBox.Name = "ClosedCheckBox";
            this.ClosedCheckBox.Size = new System.Drawing.Size(76, 24);
            this.ClosedCheckBox.TabIndex = 3;
            this.ClosedCheckBox.Text = "Closed";
            this.ClosedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfirmChangesButton
            // 
            this.ConfirmChangesButton.Location = new System.Drawing.Point(61, 134);
            this.ConfirmChangesButton.Name = "ConfirmChangesButton";
            this.ConfirmChangesButton.Size = new System.Drawing.Size(158, 41);
            this.ConfirmChangesButton.TabIndex = 4;
            this.ConfirmChangesButton.Text = "Confirm Changes";
            this.ConfirmChangesButton.UseVisualStyleBackColor = true;
            this.ConfirmChangesButton.Click += new System.EventHandler(this.ConfirmChangesButton_Click);
            // 
            // OrderStatusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 203);
            this.Controls.Add(this.ConfirmChangesButton);
            this.Controls.Add(this.ClosedCheckBox);
            this.Controls.Add(this.ShippedCheckBox);
            this.Controls.Add(this.ProcessedCheckBox);
            this.MaximumSize = new System.Drawing.Size(300, 250);
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "OrderStatusEditor";
            this.Text = "Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ProcessedCheckBox;
        private System.Windows.Forms.CheckBox ShippedCheckBox;
        private System.Windows.Forms.CheckBox ClosedCheckBox;
        private System.Windows.Forms.Button ConfirmChangesButton;
    }
}