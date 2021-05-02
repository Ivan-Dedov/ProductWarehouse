
namespace ProductWarehouse
{
    partial class AddToCartMenu
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
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PriceValueLabel = new System.Windows.Forms.Label();
            this.ItemCountLabel = new System.Windows.Forms.Label();
            this.ItemCountNumericUD = new System.Windows.Forms.NumericUpDown();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.VendorCodeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ProductNameValueLabel = new System.Windows.Forms.Label();
            this.DescriptionValueLabel = new System.Windows.Forms.Label();
            this.ProductPhotoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCountNumericUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPhotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Location = new System.Drawing.Point(187, 406);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(111, 35);
            this.AddToCartButton.TabIndex = 0;
            this.AddToCartButton.Text = "Add to Cart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // PriceLabel
            // 
            this.PriceLabel.Location = new System.Drawing.Point(12, 353);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(92, 25);
            this.PriceLabel.TabIndex = 1;
            this.PriceLabel.Text = "Total Price:";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PriceValueLabel
            // 
            this.PriceValueLabel.Location = new System.Drawing.Point(114, 353);
            this.PriceValueLabel.Name = "PriceValueLabel";
            this.PriceValueLabel.Size = new System.Drawing.Size(356, 25);
            this.PriceValueLabel.TabIndex = 2;
            this.PriceValueLabel.Text = "PRICE";
            this.PriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemCountLabel
            // 
            this.ItemCountLabel.Location = new System.Drawing.Point(12, 315);
            this.ItemCountLabel.Name = "ItemCountLabel";
            this.ItemCountLabel.Size = new System.Drawing.Size(92, 25);
            this.ItemCountLabel.TabIndex = 3;
            this.ItemCountLabel.Text = "Count:";
            this.ItemCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ItemCountNumericUD
            // 
            this.ItemCountNumericUD.Location = new System.Drawing.Point(114, 315);
            this.ItemCountNumericUD.Name = "ItemCountNumericUD";
            this.ItemCountNumericUD.Size = new System.Drawing.Size(184, 27);
            this.ItemCountNumericUD.TabIndex = 4;
            this.ItemCountNumericUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemCountNumericUD.ValueChanged += new System.EventHandler(this.ItemCountNumericUD_ValueChanged);
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Location = new System.Drawing.Point(12, 9);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(96, 25);
            this.ProductNameLabel.TabIndex = 5;
            this.ProductNameLabel.Text = "Product:";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VendorCodeLabel
            // 
            this.VendorCodeLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VendorCodeLabel.ForeColor = System.Drawing.Color.Gray;
            this.VendorCodeLabel.Location = new System.Drawing.Point(114, 34);
            this.VendorCodeLabel.Name = "VendorCodeLabel";
            this.VendorCodeLabel.Size = new System.Drawing.Size(356, 25);
            this.VendorCodeLabel.TabIndex = 6;
            this.VendorCodeLabel.Text = "VENDOR CODE";
            this.VendorCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 65);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(98, 25);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Description:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProductNameValueLabel
            // 
            this.ProductNameValueLabel.Location = new System.Drawing.Point(114, 9);
            this.ProductNameValueLabel.Name = "ProductNameValueLabel";
            this.ProductNameValueLabel.Size = new System.Drawing.Size(356, 25);
            this.ProductNameValueLabel.TabIndex = 8;
            this.ProductNameValueLabel.Text = "PRODUCT NAME";
            this.ProductNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionValueLabel
            // 
            this.DescriptionValueLabel.Location = new System.Drawing.Point(114, 67);
            this.DescriptionValueLabel.Name = "DescriptionValueLabel";
            this.DescriptionValueLabel.Size = new System.Drawing.Size(354, 247);
            this.DescriptionValueLabel.TabIndex = 9;
            this.DescriptionValueLabel.Text = "DESCRIPTION";
            // 
            // ProductPhotoPictureBox
            // 
            this.ProductPhotoPictureBox.Location = new System.Drawing.Point(12, 93);
            this.ProductPhotoPictureBox.Name = "ProductPhotoPictureBox";
            this.ProductPhotoPictureBox.Size = new System.Drawing.Size(92, 85);
            this.ProductPhotoPictureBox.TabIndex = 10;
            this.ProductPhotoPictureBox.TabStop = false;
            // 
            // AddToCartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.ProductPhotoPictureBox);
            this.Controls.Add(this.DescriptionValueLabel);
            this.Controls.Add(this.ProductNameValueLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.VendorCodeLabel);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.ItemCountNumericUD);
            this.Controls.Add(this.ItemCountLabel);
            this.Controls.Add(this.PriceValueLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.AddToCartButton);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AddToCartMenu";
            this.Text = "Add to Cart";
            ((System.ComponentModel.ISupportInitialize)(this.ItemCountNumericUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label PriceValueLabel;
        private System.Windows.Forms.Label ItemCountLabel;
        private System.Windows.Forms.NumericUpDown ItemCountNumericUD;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label VendorCodeLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label ProductNameValueLabel;
        private System.Windows.Forms.Label DescriptionValueLabel;
        private System.Windows.Forms.PictureBox ProductPhotoPictureBox;
    }
}