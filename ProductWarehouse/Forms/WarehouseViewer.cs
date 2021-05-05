using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents the main window for the Warehouse.
    /// </summary>
    public partial class WarehouseViewer : Form
    {
        #region Fields
        /// <summary>
        /// The warehouse to be worked with.
        /// </summary>
        private Warehouse warehouse = new Warehouse()
        {
            Sections = new List<Section>()
        };
        /// <summary>
        /// The adapter for the warehouse.
        /// </summary>
        private WarehouseAdapter warehouseAdapter;

        /// <summary>
        /// The directory to the file in which to save the warehouse.
        /// </summary>
        private string saveFileName = null;
        /// <summary>
        /// Detects whether the user has made a change since the last save.
        /// </summary>
        private bool hasUnsavedChanges = false;

        /// <summary>
        /// Determines whether the DataGridView will show all nested children (true)
        /// products, or just the direct children products (false).
        /// </summary>
        private bool showAllChildren = false;
        /// <summary>
        /// Determines whether the only the direct children items in a selected Section
        /// will be sorted (false), or all Sections that are children of the selected one
        /// will be sorted too (true).
        /// </summary>
        private bool sortAllChildren = false;

        private bool inSalesmanView = true;
        private Client client;
        private Order order;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        public WarehouseViewer(Client client)
        {
            this.client = client;
            inSalesmanView = client is Salesman;
            if (!inSalesmanView)
            {
                order = new Order(client as Customer, new List<OrderItem>());
            }

            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;
            MaximumSize = SystemInformation.PrimaryMonitorSize;

            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            SetupCatalogueTreeView();

            DirectChildrenToolStripMenuItem.Checked = true;
            AllChildrenToolStripMenuItem.Checked = false;

            SortDirectChildrenToolStripMenuItem.Checked = true;
            SortAllChildrenToolStripMenuItem.Checked = false;

            ChangeButtonsVisibility(inSalesmanView);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Changes the visibility of certain buttons on the tool strip based on
        /// the view mode.
        /// </summary>
        /// <param name="isSalesman">Boolean value: true, if the user is a Salesman; false, otherwise.</param>
        private void ChangeButtonsVisibility(bool isSalesman)
        {
            if (!isSalesman)
            {
                NewToolStripMenuItem.Visible = false;
                OpenToolStripMenuItem.Text = "Select a Warehouse";
                ToolStripSeparator1_2.Visible = false;
                GetRandomWhToolStripMenuItem.Visible = false;
                SaveToolStripMenuItem.Visible = false;
                SaveAsToolStripMenuItem.Visible = false;
                ToolStripSeparator1_3.Visible = false;
                GetCSVReportToolStripMenuItem.Visible = false;
                PaymentReportToolStripMenuItem.Visible = false;
                ItemReportToolStripMenuItem.Visible = false;

                EditToolStripMenuItem.Visible = false;

                ToolStripSeparator3_1.Visible = false;
                SortAllChildrenToolStripMenuItem.Visible = false;
                SortDirectChildrenToolStripMenuItem.Visible = false;

                ClientsToolStripMenuItem.Visible = false;
                AllOrdersStripMenuItem.Visible = false;
            }
            else
            {
                OrdersToolStripMenuItem.Visible = false;
                CartToolStripMenuItem.Visible = false;
            }
        }

        #region Setup
        /// <summary>
        /// Sets up the catalogue TreeView. (Use only once!)
        /// </summary>
        private void SetupCatalogueTreeView()
        {
            // Set up images for section and product icons.
            ImageList icons = new ImageList();
            icons.Images.Add(Image.FromFile(Constants.FolderIconDirectory));
            icons.Images.Add(Image.FromFile(Constants.BagIconDirectory));
            CatalogueTreeView.ImageList = icons;

            // Adding a ContextMenu to the TreeView.
            CatalogueTreeView.ContextMenuStrip = GetContextMenuStrip();
        }
        /// <summary>
        /// Supplies the context menu strip for the TreeView.
        /// </summary>
        /// <returns>The context menu strip which to apply to the TreeView.</returns>
        private ContextMenuStrip GetContextMenuStrip()
        {
            ContextMenuStrip cms = new ContextMenuStrip();

            if (inSalesmanView)
            {
                ToolStripMenuItem addItem = new ToolStripMenuItem()
                {
                    Name = "AddItemContextMenuItem",
                    Text = "Add Item",
                };
                addItem.Click += AddItem_Click;
                cms.Items.Add(addItem);

                ToolStripMenuItem editItem = new ToolStripMenuItem()
                {
                    Name = "EditItemContextMenuItem",
                    Text = "Edit Item",
                };
                editItem.Click += EditItemToolStripMenuItem_Click;
                cms.Items.Add(editItem);

                ToolStripMenuItem deleteItem = new ToolStripMenuItem()
                {
                    Name = "DeleteItemContextMenuItem",
                    Text = "Delete Item",
                };
                deleteItem.Click += DeleteItem_Click; ;
                cms.Items.Add(deleteItem);

                ToolStripSeparator separator = new ToolStripSeparator()
                {
                    Name = "ContextToolStripSeparator_1",
                };
                cms.Items.Add(separator);

                ToolStripMenuItem sortItems = new ToolStripMenuItem()
                {
                    Name = "SortItemsContextMenuItem",
                    Text = "Sort Items",
                };
                sortItems.Click += SortItemsToolStripMenuItem_Click;
                cms.Items.Add(sortItems);

                ToolStripSeparator separator2 = new ToolStripSeparator()
                {
                    Name = "ContextToolStripSeparator_2",
                };
                cms.Items.Add(separator2);

                ToolStripMenuItem itemReport = new ToolStripMenuItem()
                {
                    Name = "GetItemReportContextMenuItem",
                    Text = "Get Report",
                };
                itemReport.Click += ItemReportToolStripMenuItem_Click;
                cms.Items.Add(itemReport);
            }
            else
            {
                ToolStripMenuItem addItem = new ToolStripMenuItem()
                {
                    Name = "AddToCartContextMenuItem",
                    Text = "Add to Cart",
                };
                addItem.Click += AddToCart_Click;
                cms.Items.Add(addItem);
            }

            return cms;
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = CatalogueTreeView.SelectedNode;
            if (selectedNode is null || !(warehouseAdapter.Find(selectedNode) is Product))
            {
                return;
            }

            Product product = warehouseAdapter.Find(selectedNode) as Product;
            AddToCartMenu form = new AddToCartMenu(order, product);
            form.ShowDialog();
        }

        /// <summary>
        /// Loads all data from the warehouse to the catalogue TreeView.
        /// </summary>
        /// <param name="warehouse">The warehouse to load.</param>
        private void LoadWarehouseToTreeView(Warehouse warehouse)
        {
            if (warehouse == null || warehouse.Sections == null)
            {
                return;
            }

            warehouseAdapter = new WarehouseAdapter(warehouse, CatalogueTreeView);
            CatalogueTreeView.Visible = true;
            SectionGridView.Visible = true;

            UpdateTreeView(warehouse);
        }
        /// <summary>
        /// Adds everything inside the required section to the selected node in the TreeView.
        /// </summary>
        /// <param name="node">The node to add items into.</param>
        /// <param name="section">The section to look through.</param>
        private void AddSectionToTreeView(TreeNode node, Section section)
        {
            foreach (var item in section.Items)
            {
                // If the current item is a Section, look through its contents.
                if (item is Section s)
                {
                    TreeNode innerNode = new TreeNode(s.Name,
                        Constants.FolderIconIndex, Constants.FolderIconIndex);
                    innerNode.Name = innerNode.Text;
                    node.Nodes.Add(innerNode);

                    AddSectionToTreeView(innerNode, s);
                }
                // If the current item is a Product, add the node and stop.
                else if (item is Product p)
                {
                    TreeNode productNode = new TreeNode(p.Name,
                        Constants.BagIconIndex, Constants.BagIconIndex);
                    productNode.Name = productNode.Text;
                    node.Nodes.Add(productNode);
                }
            }
        }
        /// <summary>
        /// Updates the TreeView to match the contents of the provided warehouse.
        /// </summary>
        /// <param name="warehouse">The warehouse to put into the TreeView.</param>
        /// <param name="node">The node to be updated (defaults to null - update the
        /// entire tree).</param>
        private void UpdateTreeView(Warehouse warehouse, TreeNode node = null)
        {
            CatalogueTreeView.BeginUpdate();
            if (node is null)
            {
                CatalogueTreeView.Nodes.Clear();
                foreach (var section in warehouse.Sections)
                {
                    // Add a new node.
                    TreeNode newNode = new TreeNode(section.Name,
                        Constants.FolderIconIndex, Constants.FolderIconIndex);
                    newNode.Name = newNode.Text;
                    CatalogueTreeView.Nodes.Add(newNode);

                    // Add everything inside the section to this node.
                    AddSectionToTreeView(newNode, section);
                }
            }
            else
            {
                node.Nodes.Clear();
                Section selectedSection = warehouseAdapter.Find(node) as Section;
                if (selectedSection != null)
                {
                    AddSectionToTreeView(node, selectedSection);
                }
            }
            CatalogueTreeView.EndUpdate();
        }
        #endregion

        #region Opening File
        /// <summary>
        /// Handles opening a warehouse file.
        /// </summary>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileName != null)
            {
                switch (MessageBox.Show(Messages.ConfirmSaveText, Messages.ConfirmSaveCaption,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        SaveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                    default:
                        return;
                }
            }
            CreateOpenFileDialog();
        }
        /// <summary>
        /// Creates an OpenFileDialog for opening a warehouse JSON file.
        /// </summary>
        private void CreateOpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Filter = Constants.FilterString,
                Title = "Select a Warehouse",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    warehouse = WarehouseSerializer.Deserialize(openFileDialog.FileName);
                    saveFileName = openFileDialog.FileName;

                    LoadWarehouseToTreeView(warehouse);
                }
                catch (InvalidDataException ex)
                {
                    MessageBox.Show(ex.Message, Messages.FileOpenErrorTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Editing Items
        /// <summary>
        /// Adds a new section to the warehouse (not nested).
        /// </summary>
        private void AddSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warehouseAdapter != null)
            {
                AddItem(null);
            }
        }

        /// <summary>
        /// Adds a new item (if a Node is selected, adds as a child of it; if not, adds
        /// as a new, not nested section).
        /// </summary>
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (warehouseAdapter != null)
            {
                AddItem(CatalogueTreeView.SelectedNode);
            }
        }
        /// <summary>
        /// Creates an OpenFileDialog and adds an item to the selected section.
        /// </summary>
        private void AddItemToSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItem_Click(sender, e);
        }
        /// <summary>
        /// Opens a new Form and after it closes, if it is possible adds the resulting
        /// item as a child of the provided parent node (if any).
        /// </summary>
        /// <param name="parentNode">The parent node of the added item.</param>
        private void AddItem(TreeNode parentNode)
        {
            if (warehouseAdapter.Find(parentNode) is Product)
            {
                MessageBox.Show(Messages.CouldNotAddItemToProductText, Messages.ForbiddenActionCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ItemEditor form = new ItemEditor(parentNode, warehouse);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.IsSection)
                {
                    Section section = new Section(form.SectionName, form.SortingCode);
                    section.Parent = warehouseAdapter.Find(parentNode) as Section;
                    warehouseAdapter.Add(section);
                }
                else
                {
                    Product product = new Product(warehouseAdapter.Find(parentNode) as Section,
                        form.ProductName, form.VendorCode, form.Price, form.LeftInStock,
                        form.Description, form.Photo);
                    warehouseAdapter.Add(product);
                }
                hasUnsavedChanges = true;
            }

            CatalogueTreeView_AfterSelect(new object(), new TreeViewEventArgs(parentNode));
        }

        /// <summary>
        /// Opens a menu for editing the item that corresponds to the selected node.
        /// </summary>
        private void EditItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = CatalogueTreeView.SelectedNode;
            if (selectedNode is null)
            {
                return;
            }

            TreeNode parentNode = selectedNode.Parent;
            IStorable selectedItem = null;
            if (warehouseAdapter.Find(selectedNode) is Section s)
            {
                selectedItem = s;
            }
            else if (warehouseAdapter.Find(selectedNode) is Product p)
            {
                selectedItem = p;
            }

            ItemEditor form = new ItemEditor(parentNode, warehouse, selectedItem);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.IsSection)
                {
                    (selectedItem as Section).Name = form.Name;
                    (selectedItem as Section).SortingCode = form.SortingCode;
                }
                else
                {
                    (selectedItem as Product).Name = form.Name;
                    (selectedItem as Product).VendorCode = form.VendorCode;
                    (selectedItem as Product).Price = form.Price;
                    (selectedItem as Product).LeftInStock = form.LeftInStock;
                    (selectedItem as Product).Description = form.Description;
                    (selectedItem as Product).Photo = form.Photo;
                }
                hasUnsavedChanges = true;
            }

            CatalogueTreeView_AfterSelect(sender, new TreeViewEventArgs(selectedNode));
        }

        /// <summary>
        /// Removes the selected item from the warehouse.
        /// </summary>
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = CatalogueTreeView.SelectedNode;
            if (selectedNode != null)
            {
                if (warehouseAdapter.Find(selectedNode) is Section s)
                {
                    if (s.Items is null || s.Items.Count == 0)
                    {
                        warehouseAdapter.Remove(selectedNode);
                        hasUnsavedChanges = true;
                    }
                    else
                    {
                        MessageBox.Show(Messages.CouldNotDeleteItemText,
                            Messages.ForbiddenActionCaption, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else if (warehouseAdapter.Find(selectedNode) is Product p)
                {
                    warehouseAdapter.Remove(selectedNode);
                    hasUnsavedChanges = true;
                }
            }
        }
        /// <summary>
        /// Deletes a selected item.
        /// </summary>
        private void DeleteSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem_Click(sender, e);
        }

        /// <summary>
        /// Sorts the main sections (that are directly inside the warehouse).
        /// </summary>
        private void SortMainSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            warehouse.Sections.Sort((x, y) => x.CompareTo(y));
            if (sortAllChildren)
            {
                foreach (var section in warehouse.Sections)
                {
                    section.Sort(true);
                }
            }

            CatalogueTreeView.BeginUpdate();
            CatalogueTreeView.Nodes.Clear();
            foreach (var section in warehouse.Sections)
            {
                // Add a new node.
                TreeNode newNode = new TreeNode(section.Name,
                    Constants.FolderIconIndex, Constants.FolderIconIndex);
                newNode.Name = newNode.Text;
                CatalogueTreeView.Nodes.Add(newNode);

                // Add everything inside the section to this node.
                AddSectionToTreeView(newNode, section);
            }
            CatalogueTreeView.EndUpdate();
        }
        /// <summary>
        /// Sorts the items inside the selected section (that corresponds to the selected
        /// TreeNode).
        /// </summary>
        private void SortItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = CatalogueTreeView.SelectedNode;
            if (selectedNode is null)
            {
                return;
            }

            IStorable selectedItem = warehouseAdapter.Find(selectedNode);
            if (selectedItem is Product)
            {
                return;
            }

                (selectedItem as Section).Sort(sortAllChildren);
            UpdateTreeView(warehouse, selectedNode);
        }
        #endregion

        #region Saving Data
        /// <summary>
        /// Saves the warehouse data when the user clicks the "Save" button in the
        /// toolstip menu.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileName == null)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    WarehouseSerializer.Serialize(warehouse, saveFileName);
                    hasUnsavedChanges = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Allows the user to choose the file in which to save the warehouse.
        /// </summary>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warehouse is null || warehouseAdapter is null)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Filter = Constants.FilterString,
                Title = "Save your Warehouse",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WarehouseSerializer.Serialize(warehouse, saveFileDialog.FileName);
                    hasUnsavedChanges = false;
                    saveFileName = saveFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Exiting Application
        /// <summary>
        /// Closes the form.
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Saves the warehouse data when the form is closed.
        /// </summary>
        private void WarehouseViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (warehouse != null && warehouseAdapter != null && hasUnsavedChanges)
            {
                switch (MessageBox.Show(Messages.ConfirmSaveText, Messages.ConfirmSaveCaption,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        SaveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }
        #endregion

        #region Other Button Click Handlers
        /// <summary>
        /// Enables searching for all nested children when updating the DataGridView.
        /// </summary>
        private void AllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAllChildren = true;

            AllChildrenToolStripMenuItem.Checked = true;
            DirectChildrenToolStripMenuItem.Checked = false;

            CatalogueTreeView_AfterSelect(sender, new TreeViewEventArgs(CatalogueTreeView.SelectedNode));
        }
        /// <summary>
        /// Enables searching for direct children only when updating the DataGridView.
        /// </summary>
        private void DirectChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAllChildren = false;

            AllChildrenToolStripMenuItem.Checked = false;
            DirectChildrenToolStripMenuItem.Checked = true;

            CatalogueTreeView_AfterSelect(sender, new TreeViewEventArgs(CatalogueTreeView.SelectedNode));
        }

        /// <summary>
        /// Enables sorting all children of the selected node.
        /// </summary>
        private void SortAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortAllChildren = true;

            SortAllChildrenToolStripMenuItem.Checked = true;
            SortDirectChildrenToolStripMenuItem.Checked = false;
        }
        /// <summary>
        /// Enables sorting only the direct children of the selected node.
        /// </summary>
        private void SortDirectChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortAllChildren = false;

            SortAllChildrenToolStripMenuItem.Checked = false;
            SortDirectChildrenToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// Expands all TreeNodes in the TreeView.
        /// </summary>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogueTreeView.ExpandAll();
        }
        /// <summary>
        /// Collapses all TreeNodes in the TreeView.
        /// </summary>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogueTreeView.CollapseAll();
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Creates a new warehouse.
        /// </summary>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileName != null)
            {
                switch (MessageBox.Show(Messages.ConfirmSaveText, Messages.ConfirmSaveCaption,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        SaveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                    case DialogResult.Cancel:
                    default:
                        break;
                }
            }

            warehouse = new Warehouse()
            {
                Sections = new List<Section>()
            };
            warehouseAdapter = new WarehouseAdapter(warehouse, CatalogueTreeView);
            saveFileName = null;

            LoadWarehouseToTreeView(warehouse);
        }

        /// <summary>
        /// Compiles a CSV report on items that are missing in the warehouse.
        /// </summary>
        private void GetCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warehouse is null || warehouseAdapter is null)
            {
                return;
            }

            CsvExporter form = new CsvExporter(warehouse);
            if (form.ShowDialog() == DialogResult.OK)
            {
                return;
            }
        }

        /// <summary>
        /// Generates a random warehouse.
        /// </summary>
        private void GetRandomWhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warehouse != null && warehouseAdapter != null && hasUnsavedChanges)
            {
                switch (MessageBox.Show(Messages.ConfirmSaveBeforeCreatingNewText, Messages.ConfirmSaveCaption,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        SaveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                    default:
                        return;
                }
            }

            WarehouseCreator form = new WarehouseCreator();
            if (form.ShowDialog() == DialogResult.OK)
            {
                warehouse = CreateRandomWarehouse(form.NumberOfSections, form.NumberOfProducts);
                WarehouseSerializer.AddMissingParents(warehouse);
                LoadWarehouseToTreeView(warehouse);
                hasUnsavedChanges = true;
            }
        }

        /// <summary>
        /// Generates a random warehouse with the specified number of items.
        /// </summary>
        /// <param name="sectionCount">The number of sections in the warehouse. (Must be at least 1.)</param>
        /// <param name="productCount">The number of products in the warehouse.</param>
        /// <returns>A random warehouse with the specified number of items.</returns>
        private Warehouse CreateRandomWarehouse(int sectionCount, int productCount)
        {
            if (sectionCount < 1 || productCount < 0)
            {
                throw new ArgumentException("Incorrect number of sections or products.");
            }

            Random r = new Random();

            // Create Sections.
            List<Section> sections = new List<Section>();
            for (int i = 1; i <= sectionCount; i++)
            {
                sections.Add(new Section(
                    $"Section{i}",
                    $"s{i * r.Next(1, 100)}"
                ));
            }

            // Creating Products.
            List<Product> products = new List<Product>();
            for (int i = 1; i <= productCount; i++)
            {
                products.Add(new Product(
                    null,
                    $"Product{i}",
                    $"p{i * r.Next(1, 100)}",
                    r.NextDouble() * r.Next(1, 1000),
                    (int)(r.Next(0, 100000) * r.NextDouble())
                ));
            }

            return AssembleWarehouse(sections, products);
        }
        /// <summary>
        /// Assembles a valid warehouse with the provided items.
        /// </summary>
        /// <param name="sections">The sections that will be used in the warehouse.</param>
        /// <param name="products">The products that will be used in the warehouse.</param>
        /// <returns>A randomly assembled warehouse.</returns>
        private Warehouse AssembleWarehouse(List<Section> sections, List<Product> products)
        {
            Warehouse warehouse = new Warehouse()
            {
                Sections = new List<Section>()
            };

            // First-layer sections.
            Random r = new Random();
            int numberOfMainSections = r.Next(1, sections.Count + 1);
            while (numberOfMainSections > 0)
            {
                int index = r.Next(0, sections.Count);
                warehouse.Sections.Add(sections[index]);
                sections.RemoveAt(index);
                numberOfMainSections--;
            }
            // Deeper sections.
            while (sections.Count > 0)
            {
                Section s = ChooseRandomSection(warehouse.Sections, null);
                s.Items.Add(sections[0]);
                sections.RemoveAt(0);
            }

            // Adding Products to sections.
            while (products.Count > 0)
            {
                Section s = ChooseRandomSection(warehouse.Sections, null);
                products[0].Parent = s;
                s.Items.Add(products[0]);
                products.RemoveAt(0);
            }

            return warehouse;
        }
        /// <summary>
        /// Selects a random Section from the provided list.
        /// </summary>
        /// <param name="sections">The list of sections to choose from.</param>
        /// <param name="parentSection">The parent section of the ones in the list (can be null).</param>
        /// <returns>A random Section from the list.</returns>
        private Section ChooseRandomSection(List<Section> sections, Section parentSection)
        {
            if (sections.Count == 0 && parentSection != null)
            {
                return parentSection;
            }

            Random r = new Random();
            int index = r.Next(0, sections.Count);

            bool goDeeper = r.NextDouble() < 0.5;
            if (goDeeper)
            {
                List<Section> newSections = new List<Section>();
                foreach (var item in sections[index].Items)
                {
                    if (item is Section s)
                    {
                        newSections.Add(s);
                    }
                }
                return ChooseRandomSection(newSections, sections[index]);
            }
            else
            {
                return sections[index];
            }
        }

        /// <summary>
        /// Searches for the children of the provided node that are of type Product
        /// and adds them to the List. Can be recursive to search for all nested nodes.
        /// </summary>
        /// <param name="products">The list to add the found children to.</param>
        /// <param name="node">The node to look through.</param>
        /// <param name="recursive">true, if the search should go as deep as possible;
        /// false, if only the direct children of the provided node should be searched (default).</param>
        private void FindChildren(List<Product> products, TreeNode node, bool recursive = false)
        {
            if (node is null)
            {
                return;
            }

            foreach (TreeNode child in node.Nodes)
            {
                if (warehouseAdapter.Find(child) is Product p)
                {
                    products.Add(p);
                }
                else if (warehouseAdapter.Find(child) is Section s)
                {
                    if (recursive)
                    {
                        FindChildren(products, warehouseAdapter.Find(s), recursive);
                    }
                }
            }
        }

        /// <summary>
        /// Shows the Products inside the selected Section when the selected Section is changed. 
        /// </summary>
        private void CatalogueTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (warehouse is null || warehouseAdapter is null)
            {
                return;
            }
            TreeNode node = CatalogueTreeView.SelectedNode;
            Section selectedSection = warehouseAdapter.Find(node) as Section;
            if (node is null)
            {
                return;
            }

            List<Product> productsInSection = new List<Product>();
            // If the item is a direct child, it will be higher in the list.
            Comparison<Product> sortingFilter = (x, y) =>
            {
                if (selectedSection.Items.Contains(x) && !selectedSection.Items.Contains(y))
                {
                    return -1;
                }
                if (!selectedSection.Items.Contains(x) && selectedSection.Items.Contains(y))
                {
                    return 1;
                }
                return 0;
            };

            if (selectedSection != null)
            {
                FindChildren(productsInSection, node, showAllChildren);
                productsInSection.Sort(sortingFilter);
            }

            SectionGridView.DataSource = productsInSection;
            for (int i = 0; i < SectionGridView.Rows.Count; i++)
            {
                if (!selectedSection.Items.Contains(productsInSection[i]))
                {
                    SectionGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
        #endregion

        #endregion

        private void OrdersToolStripMenu_Click(object sender, EventArgs e)
        {
            OrdersViewer form = new OrdersViewer(false, client as Customer);
            form.ShowDialog();
            AuthorisationForm.SerializeCustomers();
        }

        private void CartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm(client as Customer, order);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                order = new Order(client as Customer, new List<OrderItem>());
            }
            AuthorisationForm.SerializeCustomers();
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersViewer form = new CustomersViewer();
            form.ShowDialog();
        }

        private void AllOrdersStripMenuItem_Click(object sender, EventArgs e)
        {
            AllOrdersViewer form = new AllOrdersViewer();
            form.ShowDialog();
            AuthorisationForm.SerializeCustomers();
        }

        private void PaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentReport form = new PaymentReport();
            if (form.ShowDialog() == DialogResult.OK)
            {
                return;
            }
        }

        private void ItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CatalogueTreeView.SelectedNode is null)
            {
                return;
            }

            try
            {
                Product product;
                if (warehouseAdapter.Find(CatalogueTreeView.SelectedNode) is Product p)
                {
                    product = p;
                }
                else
                {
                    throw new Exception("This item is not a product.");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Save your CSV report",
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                        sw.Write(GetItemReportCsv(product));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GetItemReportCsv(Product p)
        {
            p.Parent = null;
            List<Order> orders = new List<Order>();
            foreach(var customer in ClientDatabase.Customers.Values)
            {
                foreach(var order in customer.Orders)
                {
                    order.Customer = customer;
                    if (order.Products.Exists(x => x.Item.Name == p.Name && order.Status.HasFlag(OrderStatus.Shipped)))
                    {
                        orders.Add(order);
                    }
                }
            }

            string res = "Customer Name,E-mail,Address,Phone Number,Order Date" + Environment.NewLine;

            foreach (var order in orders)
            {
                res += $"\"{order.Customer.FullName.Replace("\"", "\"\"")}\"," +
                       $"\"{order.Customer.Email.Replace("\"", "\"\"")}\"," +
                       $"\"{order.Customer.Address.Replace("\"", "\"\"")}\"," +
                       $"\"{order.Customer.PhoneNumber}\"," +
                       $"\"{order.Date}\"" + Environment.NewLine;
            }

            return res;
        }
    }
}