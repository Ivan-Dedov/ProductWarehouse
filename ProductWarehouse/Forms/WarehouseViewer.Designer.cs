
using System;

namespace ProductWarehouse
{
    partial class WarehouseViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseViewer));
            this.MainToolbarMenu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetRandomWhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1_1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1_2 = new System.Windows.Forms.ToolStripSeparator();
            this.GetCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1_3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2_1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddItemToSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2_2 = new System.Windows.Forms.ToolStripSeparator();
            this.SortItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortMainSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3_1 = new System.Windows.Forms.ToolStripSeparator();
            this.SortDirectChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortAllChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CatalogueTreeView = new System.Windows.Forms.TreeView();
            this.SectionGridView = new System.Windows.Forms.DataGridView();
            this.CartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolbarMenu.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainToolbarMenu
            // 
            this.MainToolbarMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainToolbarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.OrdersToolStripMenuItem,
            this.CartToolStripMenuItem});
            this.MainToolbarMenu.Location = new System.Drawing.Point(0, 0);
            this.MainToolbarMenu.Name = "MainToolbarMenu";
            this.MainToolbarMenu.Size = new System.Drawing.Size(1212, 28);
            this.MainToolbarMenu.TabIndex = 0;
            this.MainToolbarMenu.Text = "toolbar";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.GetRandomWhToolStripMenuItem,
            this.ToolStripSeparator1_1,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ToolStripSeparator1_2,
            this.GetCSVToolStripMenuItem,
            this.ToolStripSeparator1_3,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripMenuItem.Image")));
            this.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.NewToolStripMenuItem.Text = "&New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.OpenToolStripMenuItem.Text = "&Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // GetRandomWhToolStripMenuItem
            // 
            this.GetRandomWhToolStripMenuItem.Name = "GetRandomWhToolStripMenuItem";
            this.GetRandomWhToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.GetRandomWhToolStripMenuItem.Text = "Create Random Warehouse";
            this.GetRandomWhToolStripMenuItem.Click += new System.EventHandler(this.GetRandomWhToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1_1
            // 
            this.ToolStripSeparator1_1.Name = "ToolStripSeparator1_1";
            this.ToolStripSeparator1_1.Size = new System.Drawing.Size(269, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.SaveAsToolStripMenuItem.Text = "Save &As";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1_2
            // 
            this.ToolStripSeparator1_2.Name = "ToolStripSeparator1_2";
            this.ToolStripSeparator1_2.Size = new System.Drawing.Size(269, 6);
            // 
            // GetCSVToolStripMenuItem
            // 
            this.GetCSVToolStripMenuItem.Name = "GetCSVToolStripMenuItem";
            this.GetCSVToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.GetCSVToolStripMenuItem.Text = "Get CSV Report";
            this.GetCSVToolStripMenuItem.Click += new System.EventHandler(this.GetCSVToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1_3
            // 
            this.ToolStripSeparator1_3.Name = "ToolStripSeparator1_3";
            this.ToolStripSeparator1_3.Size = new System.Drawing.Size(269, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSectionToolStripMenuItem,
            this.ToolStripSeparator2_1,
            this.AddItemToSectionToolStripMenuItem,
            this.EditItemToolStripMenuItem,
            this.DeleteSelectedItemToolStripMenuItem,
            this.ToolStripSeparator2_2,
            this.SortItemsToolStripMenuItem,
            this.SortMainSectionsToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // AddSectionToolStripMenuItem
            // 
            this.AddSectionToolStripMenuItem.Name = "AddSectionToolStripMenuItem";
            this.AddSectionToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.AddSectionToolStripMenuItem.Text = "Add Section";
            this.AddSectionToolStripMenuItem.Click += new System.EventHandler(this.AddSectionToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2_1
            // 
            this.ToolStripSeparator2_1.Name = "ToolStripSeparator2_1";
            this.ToolStripSeparator2_1.Size = new System.Drawing.Size(228, 6);
            // 
            // AddItemToSectionToolStripMenuItem
            // 
            this.AddItemToSectionToolStripMenuItem.Name = "AddItemToSectionToolStripMenuItem";
            this.AddItemToSectionToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.AddItemToSectionToolStripMenuItem.Text = "Add Item to Section";
            this.AddItemToSectionToolStripMenuItem.Click += new System.EventHandler(this.AddItemToSectionToolStripMenuItem_Click);
            // 
            // EditItemToolStripMenuItem
            // 
            this.EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem";
            this.EditItemToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.EditItemToolStripMenuItem.Text = "Edit Item";
            this.EditItemToolStripMenuItem.Click += new System.EventHandler(this.EditItemToolStripMenuItem_Click);
            // 
            // DeleteSelectedItemToolStripMenuItem
            // 
            this.DeleteSelectedItemToolStripMenuItem.Name = "DeleteSelectedItemToolStripMenuItem";
            this.DeleteSelectedItemToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.DeleteSelectedItemToolStripMenuItem.Text = "Delete Selected Item";
            this.DeleteSelectedItemToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectedItemToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2_2
            // 
            this.ToolStripSeparator2_2.Name = "ToolStripSeparator2_2";
            this.ToolStripSeparator2_2.Size = new System.Drawing.Size(228, 6);
            // 
            // SortItemsToolStripMenuItem
            // 
            this.SortItemsToolStripMenuItem.Name = "SortItemsToolStripMenuItem";
            this.SortItemsToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.SortItemsToolStripMenuItem.Text = "Sort Items in Section";
            this.SortItemsToolStripMenuItem.Click += new System.EventHandler(this.SortItemsToolStripMenuItem_Click);
            // 
            // SortMainSectionsToolStripMenuItem
            // 
            this.SortMainSectionsToolStripMenuItem.Name = "SortMainSectionsToolStripMenuItem";
            this.SortMainSectionsToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.SortMainSectionsToolStripMenuItem.Text = "Sort All Sections";
            this.SortMainSectionsToolStripMenuItem.Click += new System.EventHandler(this.SortMainSectionsToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DirectChildrenToolStripMenuItem,
            this.AllChildrenToolStripMenuItem,
            this.ToolStripSeparator3_1,
            this.SortDirectChildrenToolStripMenuItem,
            this.SortAllChildrenToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.SettingsToolStripMenuItem.Text = "&Settings";
            // 
            // DirectChildrenToolStripMenuItem
            // 
            this.DirectChildrenToolStripMenuItem.Name = "DirectChildrenToolStripMenuItem";
            this.DirectChildrenToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.DirectChildrenToolStripMenuItem.Text = "Show Direct Children Products Only";
            this.DirectChildrenToolStripMenuItem.Click += new System.EventHandler(this.DirectChildrenToolStripMenuItem_Click);
            // 
            // AllChildrenToolStripMenuItem
            // 
            this.AllChildrenToolStripMenuItem.Name = "AllChildrenToolStripMenuItem";
            this.AllChildrenToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.AllChildrenToolStripMenuItem.Text = "Show All Children Products";
            this.AllChildrenToolStripMenuItem.Click += new System.EventHandler(this.AllChildrenToolStripMenuItem_Click);
            // 
            // ToolStripSeparator3_1
            // 
            this.ToolStripSeparator3_1.Name = "ToolStripSeparator3_1";
            this.ToolStripSeparator3_1.Size = new System.Drawing.Size(323, 6);
            // 
            // SortDirectChildrenToolStripMenuItem
            // 
            this.SortDirectChildrenToolStripMenuItem.Name = "SortDirectChildrenToolStripMenuItem";
            this.SortDirectChildrenToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.SortDirectChildrenToolStripMenuItem.Text = "Sort Direct Children";
            this.SortDirectChildrenToolStripMenuItem.Click += new System.EventHandler(this.SortDirectChildrenToolStripMenuItem_Click);
            // 
            // SortAllChildrenToolStripMenuItem
            // 
            this.SortAllChildrenToolStripMenuItem.Name = "SortAllChildrenToolStripMenuItem";
            this.SortAllChildrenToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.SortAllChildrenToolStripMenuItem.Text = "Sort All Nested Children";
            this.SortAllChildrenToolStripMenuItem.Click += new System.EventHandler(this.SortAllChildrenToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExpandAllToolStripMenuItem,
            this.CollapseAllToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.ViewToolStripMenuItem.Text = "&View";
            // 
            // ExpandAllToolStripMenuItem
            // 
            this.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem";
            this.ExpandAllToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.ExpandAllToolStripMenuItem.Text = "Expand All";
            this.ExpandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // CollapseAllToolStripMenuItem
            // 
            this.CollapseAllToolStripMenuItem.Name = "CollapseAllToolStripMenuItem";
            this.CollapseAllToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.CollapseAllToolStripMenuItem.Text = "Collapse All";
            this.CollapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.OrdersToolStripMenuItem.Text = "Orders";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenu_Click);
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.MainTableLayoutPanel.Controls.Add(this.CatalogueTreeView, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.SectionGridView, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1212, 469);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // CatalogueTreeView
            // 
            this.CatalogueTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CatalogueTreeView.Location = new System.Drawing.Point(3, 3);
            this.CatalogueTreeView.Name = "CatalogueTreeView";
            this.CatalogueTreeView.Size = new System.Drawing.Size(297, 463);
            this.CatalogueTreeView.TabIndex = 0;
            this.CatalogueTreeView.Visible = false;
            this.CatalogueTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CatalogueTreeView_AfterSelect);
            // 
            // SectionGridView
            // 
            this.SectionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SectionGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SectionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SectionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionGridView.Location = new System.Drawing.Point(306, 3);
            this.SectionGridView.Name = "SectionGridView";
            this.SectionGridView.ReadOnly = true;
            this.SectionGridView.RowHeadersWidth = 51;
            this.SectionGridView.RowTemplate.Height = 29;
            this.SectionGridView.Size = new System.Drawing.Size(903, 463);
            this.SectionGridView.TabIndex = 1;
            this.SectionGridView.Visible = false;
            // 
            // CartToolStripMenuItem
            // 
            this.CartToolStripMenuItem.Name = "CartToolStripMenuItem";
            this.CartToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.CartToolStripMenuItem.Text = "Cart";
            this.CartToolStripMenuItem.Click += new System.EventHandler(this.CartToolStripMenuItem_Click);
            // 
            // WarehouseViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 497);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.MainToolbarMenu);
            this.Name = "WarehouseViewer";
            this.Text = "Warehouse Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WarehouseViewer_FormClosing);
            this.MainToolbarMenu.ResumeLayout(false);
            this.MainToolbarMenu.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainToolbarMenu;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TreeView CatalogueTreeView;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1_1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSectionToolStripMenuItem;
        private System.Windows.Forms.DataGridView SectionGridView;
        private System.Windows.Forms.ToolStripMenuItem AddItemToSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSelectedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DirectChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetRandomWhToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1_2;
        private System.Windows.Forms.ToolStripMenuItem GetCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1_3;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2_1;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2_2;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3_1;
        private System.Windows.Forms.ToolStripMenuItem SortDirectChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortAllChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortMainSectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CartToolStripMenuItem;
    }
}

