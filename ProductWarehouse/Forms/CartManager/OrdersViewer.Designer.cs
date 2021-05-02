
namespace ProductWarehouse
{
    partial class OrdersViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrdersGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersGridView
            // 
            this.OrdersGridView.AllowUserToAddRows = false;
            this.OrdersGridView.AllowUserToDeleteRows = false;
            this.OrdersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OrdersGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OrdersGridView.ColumnHeadersHeight = 29;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersGridView.Location = new System.Drawing.Point(0, 0);
            this.OrdersGridView.Name = "OrdersGridView";
            this.OrdersGridView.ReadOnly = true;
            this.OrdersGridView.RowHeadersWidth = 51;
            this.OrdersGridView.RowTemplate.Height = 29;
            this.OrdersGridView.Size = new System.Drawing.Size(482, 453);
            this.OrdersGridView.TabIndex = 0;
            // 
            // OrdersViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.OrdersGridView);
            this.Name = "OrdersViewer";
            this.Text = "Your Orders";
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersGridView;
    }
}