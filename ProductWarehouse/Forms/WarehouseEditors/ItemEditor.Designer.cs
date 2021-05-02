
namespace ProductWarehouse
{
    partial class ItemEditor
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
            this.ItemTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.ProductItemTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.SectionItemTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.TextBoxesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.InfoTextLabel = new System.Windows.Forms.Label();
            this.WarningTextLabel = new System.Windows.Forms.Label();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.SortingCodeLabel = new System.Windows.Forms.Label();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.ParentLabel = new System.Windows.Forms.Label();
            this.ParentNameLabel = new System.Windows.Forms.Label();
            this.SortingVendorCodeTextBox = new System.Windows.Forms.TextBox();
            this.VendorCodeLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.LeftInStockLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PhotoLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.LeftInStockNumericUD = new System.Windows.Forms.NumericUpDown();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.AddPhotoButton = new System.Windows.Forms.Button();
            this.ImageDirectoryLabel = new System.Windows.Forms.Label();
            this.DeletePhotoButton = new System.Windows.Forms.Button();
            this.ItemTypeGroupBox.SuspendLayout();
            this.TextBoxesTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftInStockNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemTypeGroupBox
            // 
            this.ItemTypeGroupBox.Controls.Add(this.ProductItemTypeRadioButton);
            this.ItemTypeGroupBox.Controls.Add(this.SectionItemTypeRadioButton);
            this.ItemTypeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ItemTypeGroupBox.Name = "ItemTypeGroupBox";
            this.ItemTypeGroupBox.Size = new System.Drawing.Size(113, 99);
            this.ItemTypeGroupBox.TabIndex = 1;
            this.ItemTypeGroupBox.TabStop = false;
            this.ItemTypeGroupBox.Text = "Item Type";
            // 
            // ProductItemTypeRadioButton
            // 
            this.ProductItemTypeRadioButton.AutoSize = true;
            this.ProductItemTypeRadioButton.Location = new System.Drawing.Point(17, 57);
            this.ProductItemTypeRadioButton.Name = "ProductItemTypeRadioButton";
            this.ProductItemTypeRadioButton.Size = new System.Drawing.Size(81, 24);
            this.ProductItemTypeRadioButton.TabIndex = 1;
            this.ProductItemTypeRadioButton.TabStop = true;
            this.ProductItemTypeRadioButton.Text = "Product";
            this.ProductItemTypeRadioButton.UseVisualStyleBackColor = true;
            this.ProductItemTypeRadioButton.CheckedChanged += new System.EventHandler(this.ProductItemTypeRadioButton_CheckedChanged);
            this.ProductItemTypeRadioButton.MouseEnter += new System.EventHandler(this.OnProductItemTypeHover);
            this.ProductItemTypeRadioButton.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // SectionItemTypeRadioButton
            // 
            this.SectionItemTypeRadioButton.AutoSize = true;
            this.SectionItemTypeRadioButton.Location = new System.Drawing.Point(17, 27);
            this.SectionItemTypeRadioButton.Name = "SectionItemTypeRadioButton";
            this.SectionItemTypeRadioButton.Size = new System.Drawing.Size(79, 24);
            this.SectionItemTypeRadioButton.TabIndex = 0;
            this.SectionItemTypeRadioButton.TabStop = true;
            this.SectionItemTypeRadioButton.Text = "Section";
            this.SectionItemTypeRadioButton.UseVisualStyleBackColor = true;
            this.SectionItemTypeRadioButton.CheckedChanged += new System.EventHandler(this.SectionItemTypeRadioButton_CheckedChanged);
            this.SectionItemTypeRadioButton.MouseEnter += new System.EventHandler(this.OnSectionItemTypeHover);
            this.SectionItemTypeRadioButton.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(405, 512);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(172, 29);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Create Item";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            this.OKButton.MouseEnter += new System.EventHandler(this.OnConfirmButtonHover);
            this.OKButton.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // TextBoxesTableLayoutPanel
            // 
            this.TextBoxesTableLayoutPanel.ColumnCount = 1;
            this.TextBoxesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TextBoxesTableLayoutPanel.Controls.Add(this.InfoTextLabel, 0, 0);
            this.TextBoxesTableLayoutPanel.Controls.Add(this.WarningTextLabel, 0, 1);
            this.TextBoxesTableLayoutPanel.Location = new System.Drawing.Point(132, 13);
            this.TextBoxesTableLayoutPanel.Name = "TextBoxesTableLayoutPanel";
            this.TextBoxesTableLayoutPanel.RowCount = 2;
            this.TextBoxesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TextBoxesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TextBoxesTableLayoutPanel.Size = new System.Drawing.Size(838, 144);
            this.TextBoxesTableLayoutPanel.TabIndex = 3;
            // 
            // InfoTextLabel
            // 
            this.InfoTextLabel.AutoSize = true;
            this.InfoTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoTextLabel.Location = new System.Drawing.Point(3, 0);
            this.InfoTextLabel.Name = "InfoTextLabel";
            this.InfoTextLabel.Size = new System.Drawing.Size(832, 57);
            this.InfoTextLabel.TabIndex = 0;
            this.InfoTextLabel.Text = "Information";
            // 
            // WarningTextLabel
            // 
            this.WarningTextLabel.AutoSize = true;
            this.WarningTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WarningTextLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningTextLabel.Location = new System.Drawing.Point(3, 57);
            this.WarningTextLabel.Name = "WarningTextLabel";
            this.WarningTextLabel.Size = new System.Drawing.Size(832, 87);
            this.WarningTextLabel.TabIndex = 1;
            this.WarningTextLabel.Text = "Warning";
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ItemNameLabel.Location = new System.Drawing.Point(12, 191);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(114, 27);
            this.ItemNameLabel.TabIndex = 4;
            this.ItemNameLabel.Text = "Name:";
            this.ItemNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ItemNameLabel.MouseEnter += new System.EventHandler(this.OnItemNameHover);
            this.ItemNameLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // SortingCodeLabel
            // 
            this.SortingCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.SortingCodeLabel.Location = new System.Drawing.Point(12, 232);
            this.SortingCodeLabel.Name = "SortingCodeLabel";
            this.SortingCodeLabel.Size = new System.Drawing.Size(114, 25);
            this.SortingCodeLabel.TabIndex = 5;
            this.SortingCodeLabel.Text = "Sorting Code*:";
            this.SortingCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SortingCodeLabel.MouseEnter += new System.EventHandler(this.OnSortingVendorCodeHover);
            this.SortingCodeLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Location = new System.Drawing.Point(132, 191);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(838, 27);
            this.ItemNameTextBox.TabIndex = 6;
            this.ItemNameTextBox.TextChanged += new System.EventHandler(this.ItemNameTextBox_TextChanged);
            this.ItemNameTextBox.MouseEnter += new System.EventHandler(this.OnItemNameHover);
            this.ItemNameTextBox.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // ParentLabel
            // 
            this.ParentLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ParentLabel.Location = new System.Drawing.Point(12, 158);
            this.ParentLabel.Name = "ParentLabel";
            this.ParentLabel.Size = new System.Drawing.Size(114, 25);
            this.ParentLabel.TabIndex = 7;
            this.ParentLabel.Text = "Parent:";
            this.ParentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ParentLabel.MouseEnter += new System.EventHandler(this.OnParentNameHover);
            this.ParentLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // ParentNameLabel
            // 
            this.ParentNameLabel.AutoSize = true;
            this.ParentNameLabel.ForeColor = System.Drawing.Color.Gray;
            this.ParentNameLabel.Location = new System.Drawing.Point(132, 160);
            this.ParentNameLabel.Name = "ParentNameLabel";
            this.ParentNameLabel.Size = new System.Drawing.Size(108, 20);
            this.ParentNameLabel.TabIndex = 8;
            this.ParentNameLabel.Text = "PARENT NAME";
            this.ParentNameLabel.MouseEnter += new System.EventHandler(this.OnParentNameHover);
            this.ParentNameLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // SortingVendorCodeTextBox
            // 
            this.SortingVendorCodeTextBox.Location = new System.Drawing.Point(132, 231);
            this.SortingVendorCodeTextBox.Name = "SortingVendorCodeTextBox";
            this.SortingVendorCodeTextBox.Size = new System.Drawing.Size(838, 27);
            this.SortingVendorCodeTextBox.TabIndex = 9;
            this.SortingVendorCodeTextBox.TextChanged += new System.EventHandler(this.SortingVendorCodeTextBox_TextChanged);
            this.SortingVendorCodeTextBox.MouseEnter += new System.EventHandler(this.OnSortingVendorCodeHover);
            this.SortingVendorCodeTextBox.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // VendorCodeLabel
            // 
            this.VendorCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.VendorCodeLabel.Location = new System.Drawing.Point(13, 231);
            this.VendorCodeLabel.Name = "VendorCodeLabel";
            this.VendorCodeLabel.Size = new System.Drawing.Size(114, 25);
            this.VendorCodeLabel.TabIndex = 10;
            this.VendorCodeLabel.Text = "Vendor Code:";
            this.VendorCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VendorCodeLabel.MouseEnter += new System.EventHandler(this.OnSortingVendorCodeHover);
            this.VendorCodeLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // PriceLabel
            // 
            this.PriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.PriceLabel.Location = new System.Drawing.Point(13, 273);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(113, 22);
            this.PriceLabel.TabIndex = 11;
            this.PriceLabel.Text = "Price:";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PriceLabel.MouseEnter += new System.EventHandler(this.OnPriceHover);
            this.PriceLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // LeftInStockLabel
            // 
            this.LeftInStockLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeftInStockLabel.Location = new System.Drawing.Point(13, 313);
            this.LeftInStockLabel.Name = "LeftInStockLabel";
            this.LeftInStockLabel.Size = new System.Drawing.Size(113, 20);
            this.LeftInStockLabel.TabIndex = 12;
            this.LeftInStockLabel.Text = "Left in Stock:";
            this.LeftInStockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LeftInStockLabel.MouseEnter += new System.EventHandler(this.OnLeftInStockHover);
            this.LeftInStockLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 354);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(114, 23);
            this.DescriptionLabel.TabIndex = 13;
            this.DescriptionLabel.Text = "Description*:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DescriptionLabel.MouseEnter += new System.EventHandler(this.OnDescriptionHover);
            this.DescriptionLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // PhotoLabel
            // 
            this.PhotoLabel.BackColor = System.Drawing.Color.Transparent;
            this.PhotoLabel.Location = new System.Drawing.Point(11, 464);
            this.PhotoLabel.Name = "PhotoLabel";
            this.PhotoLabel.Size = new System.Drawing.Size(114, 27);
            this.PhotoLabel.TabIndex = 14;
            this.PhotoLabel.Text = "Photo*:";
            this.PhotoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PhotoLabel.MouseEnter += new System.EventHandler(this.OnPhotoHover);
            this.PhotoLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(132, 271);
            this.PriceTextBox.MaxLength = 16;
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(183, 27);
            this.PriceTextBox.TabIndex = 15;
            this.PriceTextBox.Text = "0";
            this.PriceTextBox.TextChanged += new System.EventHandler(this.PriceTextBox_TextChanged);
            this.PriceTextBox.MouseEnter += new System.EventHandler(this.OnPriceHover);
            this.PriceTextBox.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // LeftInStockNumericUD
            // 
            this.LeftInStockNumericUD.Location = new System.Drawing.Point(132, 311);
            this.LeftInStockNumericUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LeftInStockNumericUD.Name = "LeftInStockNumericUD";
            this.LeftInStockNumericUD.Size = new System.Drawing.Size(202, 27);
            this.LeftInStockNumericUD.TabIndex = 16;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(132, 352);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(838, 95);
            this.DescriptionTextBox.TabIndex = 17;
            this.DescriptionTextBox.MouseEnter += new System.EventHandler(this.OnDescriptionHover);
            this.DescriptionTextBox.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // AddPhotoButton
            // 
            this.AddPhotoButton.Location = new System.Drawing.Point(132, 462);
            this.AddPhotoButton.Name = "AddPhotoButton";
            this.AddPhotoButton.Size = new System.Drawing.Size(183, 29);
            this.AddPhotoButton.TabIndex = 18;
            this.AddPhotoButton.Text = "Select Image...";
            this.AddPhotoButton.UseVisualStyleBackColor = true;
            this.AddPhotoButton.Click += new System.EventHandler(this.AddPhotoButton_Click);
            this.AddPhotoButton.MouseEnter += new System.EventHandler(this.OnPhotoHover);
            this.AddPhotoButton.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // ImageDirectoryLabel
            // 
            this.ImageDirectoryLabel.ForeColor = System.Drawing.Color.Gray;
            this.ImageDirectoryLabel.Location = new System.Drawing.Point(352, 464);
            this.ImageDirectoryLabel.Name = "ImageDirectoryLabel";
            this.ImageDirectoryLabel.Size = new System.Drawing.Size(618, 25);
            this.ImageDirectoryLabel.TabIndex = 19;
            this.ImageDirectoryLabel.Text = "No image selected.";
            this.ImageDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImageDirectoryLabel.MouseEnter += new System.EventHandler(this.OnPhotoHover);
            this.ImageDirectoryLabel.MouseLeave += new System.EventHandler(this.ClearInformation);
            // 
            // DeletePhotoButton
            // 
            this.DeletePhotoButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeletePhotoButton.ForeColor = System.Drawing.Color.Red;
            this.DeletePhotoButton.Location = new System.Drawing.Point(318, 462);
            this.DeletePhotoButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeletePhotoButton.Name = "DeletePhotoButton";
            this.DeletePhotoButton.Size = new System.Drawing.Size(31, 29);
            this.DeletePhotoButton.TabIndex = 20;
            this.DeletePhotoButton.Text = "X";
            this.DeletePhotoButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DeletePhotoButton.UseVisualStyleBackColor = true;
            this.DeletePhotoButton.Visible = false;
            this.DeletePhotoButton.Click += new System.EventHandler(this.DeletePhotoButton_Click);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.DeletePhotoButton);
            this.Controls.Add(this.ImageDirectoryLabel);
            this.Controls.Add(this.AddPhotoButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.LeftInStockNumericUD);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.PhotoLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.LeftInStockLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.VendorCodeLabel);
            this.Controls.Add(this.SortingVendorCodeTextBox);
            this.Controls.Add(this.ParentNameLabel);
            this.Controls.Add(this.ParentLabel);
            this.Controls.Add(this.ItemNameTextBox);
            this.Controls.Add(this.SortingCodeLabel);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.TextBoxesTableLayoutPanel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ItemTypeGroupBox);
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ItemEditor";
            this.Text = "Create Item";
            this.ItemTypeGroupBox.ResumeLayout(false);
            this.ItemTypeGroupBox.PerformLayout();
            this.TextBoxesTableLayoutPanel.ResumeLayout(false);
            this.TextBoxesTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftInStockNumericUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ItemTypeGroupBox;
        private System.Windows.Forms.RadioButton ProductItemTypeRadioButton;
        private System.Windows.Forms.RadioButton SectionItemTypeRadioButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TableLayoutPanel TextBoxesTableLayoutPanel;
        private System.Windows.Forms.Label InfoTextLabel;
        private System.Windows.Forms.Label WarningTextLabel;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label SortingCodeLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.Label ParentLabel;
        private System.Windows.Forms.Label ParentNameLabel;
        private System.Windows.Forms.TextBox SortingVendorCodeTextBox;
        private System.Windows.Forms.Label VendorCodeLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label LeftInStockLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PhotoLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.NumericUpDown LeftInStockNumericUD;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Button AddPhotoButton;
        private System.Windows.Forms.Label ImageDirectoryLabel;
        private System.Windows.Forms.Button DeletePhotoButton;
    }
}