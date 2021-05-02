
namespace ProductWarehouse
{
    partial class CsvExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvExporter));
            this.ExportCsvButton = new System.Windows.Forms.Button();
            this.QuantityThresholdLabel = new System.Windows.Forms.Label();
            this.QuantityNumericUD = new System.Windows.Forms.NumericUpDown();
            this.InstructionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportCsvButton
            // 
            this.ExportCsvButton.Location = new System.Drawing.Point(142, 209);
            this.ExportCsvButton.Name = "ExportCsvButton";
            this.ExportCsvButton.Size = new System.Drawing.Size(196, 32);
            this.ExportCsvButton.TabIndex = 0;
            this.ExportCsvButton.Text = "Export to CSV";
            this.ExportCsvButton.UseVisualStyleBackColor = true;
            this.ExportCsvButton.Click += new System.EventHandler(this.ExportCsvButton_Click);
            // 
            // QuantityThresholdLabel
            // 
            this.QuantityThresholdLabel.Location = new System.Drawing.Point(12, 46);
            this.QuantityThresholdLabel.Name = "QuantityThresholdLabel";
            this.QuantityThresholdLabel.Size = new System.Drawing.Size(171, 20);
            this.QuantityThresholdLabel.TabIndex = 1;
            this.QuantityThresholdLabel.Text = "Item Quantity Threshold:";
            this.QuantityThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuantityNumericUD
            // 
            this.QuantityNumericUD.Location = new System.Drawing.Point(189, 44);
            this.QuantityNumericUD.Name = "QuantityNumericUD";
            this.QuantityNumericUD.Size = new System.Drawing.Size(281, 27);
            this.QuantityNumericUD.TabIndex = 2;
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InstructionLabel.Location = new System.Drawing.Point(12, 100);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(458, 85);
            this.InstructionLabel.TabIndex = 3;
            this.InstructionLabel.Text = resources.GetString("InstructionLabel.Text");
            this.InstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CsvExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.QuantityNumericUD);
            this.Controls.Add(this.QuantityThresholdLabel);
            this.Controls.Add(this.ExportCsvButton);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "CsvExporter";
            this.Text = "Create CSV Report";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportCsvButton;
        private System.Windows.Forms.Label QuantityThresholdLabel;
        private System.Windows.Forms.NumericUpDown QuantityNumericUD;
        private System.Windows.Forms.Label InstructionLabel;
    }
}