
namespace ProductWarehouse
{
    partial class PaymentReport
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
            this.AmountPaidTextBox = new System.Windows.Forms.TextBox();
            this.ExportReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AmountPaidTextBox
            // 
            this.AmountPaidTextBox.Location = new System.Drawing.Point(121, 144);
            this.AmountPaidTextBox.Name = "AmountPaidTextBox";
            this.AmountPaidTextBox.Size = new System.Drawing.Size(236, 27);
            this.AmountPaidTextBox.TabIndex = 0;
            // 
            // ExportReportButton
            // 
            this.ExportReportButton.Location = new System.Drawing.Point(186, 202);
            this.ExportReportButton.Name = "ExportReportButton";
            this.ExportReportButton.Size = new System.Drawing.Size(111, 39);
            this.ExportReportButton.TabIndex = 1;
            this.ExportReportButton.Text = "Get Report";
            this.ExportReportButton.UseVisualStyleBackColor = true;
            this.ExportReportButton.Click += new System.EventHandler(this.ExportReportButton_Click);
            // 
            // PaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.ExportReportButton);
            this.Controls.Add(this.AmountPaidTextBox);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "PaymentReport";
            this.Text = "Payment Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AmountPaidTextBox;
        private System.Windows.Forms.Button ExportReportButton;
    }
}