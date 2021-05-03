
namespace ProductWarehouse
{
    partial class AllOrdersViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllOrdersViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DisplayToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToggleDisplayButton = new System.Windows.Forms.ToolStripButton();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.DisplayToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayToolStrip
            // 
            this.DisplayToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DisplayToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleDisplayButton});
            this.DisplayToolStrip.Location = new System.Drawing.Point(0, 0);
            this.DisplayToolStrip.Name = "DisplayToolStrip";
            this.DisplayToolStrip.Size = new System.Drawing.Size(800, 27);
            this.DisplayToolStrip.TabIndex = 1;
            // 
            // ToggleDisplayButton
            // 
            this.ToggleDisplayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToggleDisplayButton.Image = ((System.Drawing.Image)(resources.GetObject("ToggleDisplayButton.Image")));
            this.ToggleDisplayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToggleDisplayButton.Name = "ToggleDisplayButton";
            this.ToggleDisplayButton.Size = new System.Drawing.Size(154, 24);
            this.ToggleDisplayButton.Text = "Toggle Order Display";
            this.ToggleDisplayButton.Click += new System.EventHandler(this.ToggleDisplayButton_Click);
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.AllowUserToAddRows = false;
            this.OrdersDataGridView.AllowUserToDeleteRows = false;
            this.OrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OrdersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersDataGridView.Location = new System.Drawing.Point(0, 27);
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.RowHeadersVisible = false;
            this.OrdersDataGridView.RowHeadersWidth = 51;
            this.OrdersDataGridView.RowTemplate.Height = 29;
            this.OrdersDataGridView.Size = new System.Drawing.Size(800, 423);
            this.OrdersDataGridView.TabIndex = 2;
            // 
            // AllOrdersViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrdersDataGridView);
            this.Controls.Add(this.DisplayToolStrip);
            this.Name = "AllOrdersViewer";
            this.Text = "All Orders";
            this.DisplayToolStrip.ResumeLayout(false);
            this.DisplayToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip DisplayToolStrip;
        private System.Windows.Forms.ToolStripButton ToggleDisplayButton;
        private System.Windows.Forms.DataGridView OrdersDataGridView;
    }
}