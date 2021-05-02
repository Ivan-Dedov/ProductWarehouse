
namespace ProductWarehouse
{
    partial class WarehouseCreator
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
            this.NumberOfSectionsLabel = new System.Windows.Forms.Label();
            this.NumberOfProductsLabel = new System.Windows.Forms.Label();
            this.NumberOfSectionsNumericUD = new System.Windows.Forms.NumericUpDown();
            this.NumberOfProductsNumericUD = new System.Windows.Forms.NumericUpDown();
            this.CreateWarehouseButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfSectionsNumericUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfProductsNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberOfSectionsLabel
            // 
            this.NumberOfSectionsLabel.Location = new System.Drawing.Point(12, 33);
            this.NumberOfSectionsLabel.Name = "NumberOfSectionsLabel";
            this.NumberOfSectionsLabel.Size = new System.Drawing.Size(155, 25);
            this.NumberOfSectionsLabel.TabIndex = 0;
            this.NumberOfSectionsLabel.Text = "Number of Sections:";
            this.NumberOfSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumberOfProductsLabel
            // 
            this.NumberOfProductsLabel.Location = new System.Drawing.Point(12, 71);
            this.NumberOfProductsLabel.Name = "NumberOfProductsLabel";
            this.NumberOfProductsLabel.Size = new System.Drawing.Size(155, 25);
            this.NumberOfProductsLabel.TabIndex = 1;
            this.NumberOfProductsLabel.Text = "Number of Products:";
            this.NumberOfProductsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumberOfSectionsNumericUD
            // 
            this.NumberOfSectionsNumericUD.Location = new System.Drawing.Point(173, 33);
            this.NumberOfSectionsNumericUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfSectionsNumericUD.Name = "NumberOfSectionsNumericUD";
            this.NumberOfSectionsNumericUD.Size = new System.Drawing.Size(297, 27);
            this.NumberOfSectionsNumericUD.TabIndex = 2;
            this.NumberOfSectionsNumericUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumberOfProductsNumericUD
            // 
            this.NumberOfProductsNumericUD.Location = new System.Drawing.Point(173, 71);
            this.NumberOfProductsNumericUD.Name = "NumberOfProductsNumericUD";
            this.NumberOfProductsNumericUD.Size = new System.Drawing.Size(297, 27);
            this.NumberOfProductsNumericUD.TabIndex = 3;
            // 
            // CreateWarehouseButton
            // 
            this.CreateWarehouseButton.Location = new System.Drawing.Point(149, 205);
            this.CreateWarehouseButton.Name = "CreateWarehouseButton";
            this.CreateWarehouseButton.Size = new System.Drawing.Size(183, 36);
            this.CreateWarehouseButton.TabIndex = 4;
            this.CreateWarehouseButton.Text = "Create Warehouse";
            this.CreateWarehouseButton.UseVisualStyleBackColor = true;
            this.CreateWarehouseButton.Click += new System.EventHandler(this.CreateWarehouseButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InfoLabel.Location = new System.Drawing.Point(12, 122);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(458, 68);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "When you click the button below, a random Warehouse will be created and loaded in" +
    "to the project. Specify the number of sections and products it will have.";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WarehouseCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CreateWarehouseButton);
            this.Controls.Add(this.NumberOfProductsNumericUD);
            this.Controls.Add(this.NumberOfSectionsNumericUD);
            this.Controls.Add(this.NumberOfProductsLabel);
            this.Controls.Add(this.NumberOfSectionsLabel);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "WarehouseCreator";
            this.Text = "Create a Preset Warehouse";
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfSectionsNumericUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfProductsNumericUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NumberOfSectionsLabel;
        private System.Windows.Forms.Label NumberOfProductsLabel;
        private System.Windows.Forms.NumericUpDown NumberOfSectionsNumericUD;
        private System.Windows.Forms.NumericUpDown NumberOfProductsNumericUD;
        private System.Windows.Forms.Button CreateWarehouseButton;
        private System.Windows.Forms.Label InfoLabel;
    }
}