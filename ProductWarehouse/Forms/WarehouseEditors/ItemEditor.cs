using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes a form in which the user can create their item.
    /// </summary>
    public partial class ItemEditor : Form
    {
        #region Fields
        /// <summary>
        /// The node that the user wants to add the current item to.
        /// </summary>
        private readonly TreeNode parent;
        /// <summary>
        /// The warehouse in which to add an item to.
        /// </summary>
        private readonly Warehouse warehouse;

        /// <summary>
        /// The name to be ignored when determining whether to add a warning
        /// to the user (default is a whitespace name, since it is not possible to have one).
        /// </summary>
        private readonly string ignoreName = " ";

        /// <summary>
        /// Contains all warnings the user has received during the process of creating
        /// an item. If it is not None, the item will not be created.
        /// </summary>
        private ItemWarning warning = ItemWarning.None;
        #endregion

        #region Properties
        /// <summary>
        /// Contains a boolean value that indicates whether the user has selected
        /// Section as the item type: true, if so; false, otherwise.
        /// </summary>
        public bool IsSection { get; private set; } = true;
        public string SectionName { get; private set; }
        public string SortingCode { get; private set; }
        public new string ProductName { get; private set; }
        public string VendorCode { get; private set; }
        public double Price { get; private set; }
        public int LeftInStock { get; private set; }
        public string Description { get; private set; }
        public Image Photo { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an instance of this from in order to add a new item.
        /// </summary>
        /// <param name="parent">The parent node of an item that is to be added.</param>
        /// <param name="warehouse">The warehouse in which to add the item.</param>
        public ItemEditor(TreeNode parent, Warehouse warehouse)
        {
            this.parent = parent;
            this.warehouse = warehouse;

            InitializeComponent();

            LeftInStockNumericUD.Maximum = int.MaxValue;

            SectionItemTypeRadioButton.Checked = true;
            ProductItemTypeRadioButton.Checked = false;

            WarningTextLabel.Text = string.Empty;
            InfoTextLabel.Text = string.Empty;

            ItemNameTextBox_TextChanged(new object(), new EventArgs());
            PriceTextBox_TextChanged(new object(), new EventArgs());
            SortingVendorCodeTextBox_TextChanged(new object(), new EventArgs());

            if (parent is null)
            {
                ParentNameLabel.Text = "This item does not have a parent.";
                ParentNameLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                ParentNameLabel.Text = parent.Name;
                ParentNameLabel.ForeColor = Color.Gray;
            }
        }
        /// <summary>
        /// Creates an instance of this from in order to edit the selected item.
        /// </summary>
        /// <param name="parent">The parent node of an item that is to be added.</param>
        /// <param name="warehouse">The warehouse in which to add the item.</param>
        /// <param name="obj">The item to be edited.</param>
        public ItemEditor(TreeNode parent, Warehouse warehouse, IStorable obj)
        {
            this.parent = parent;
            this.warehouse = warehouse;
            ignoreName = obj.Name;

            InitializeComponent();

            LeftInStockNumericUD.Maximum = int.MaxValue;

            GetItemInfo(obj);
            
            WarningTextLabel.Text = string.Empty;
            InfoTextLabel.Text = string.Empty;
            OKButton.Text = "Apply Changes";
            
            ItemNameTextBox_TextChanged(new object(), new EventArgs());
            PriceTextBox_TextChanged(new object(), new EventArgs());
            SortingVendorCodeTextBox_TextChanged(new object(), new EventArgs());

            if (parent is null)
            {
                ParentNameLabel.Text = "This item does not have a parent.";
                ParentNameLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                ParentNameLabel.Text = parent.Name;
                ParentNameLabel.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Methods

        #region Button Click Managers
        /// <summary>
        /// Makes the required controls visible when Section RadioButton is checked.
        /// </summary>
        private void SectionItemTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsSection = true;

            VendorCodeLabel.Visible = false;
            PriceLabel.Visible = false;
            PriceTextBox.Visible = false;
            LeftInStockLabel.Visible = false;
            LeftInStockNumericUD.Visible = false;
            DescriptionLabel.Visible = false;
            DescriptionTextBox.Visible = false;
            PhotoLabel.Visible = false;
            AddPhotoButton.Visible = false;
            ImageDirectoryLabel.Visible = false;
            DeletePhotoButton.Visible = false;

            SortingCodeLabel.Visible = true;

            SortingVendorCodeTextBox_TextChanged(sender, e);
            PriceTextBox_TextChanged(sender, e);
            if (parent is null)
            {
                warning &= ~ItemWarning.ProductOutOfSection;
            }
            UpdateWarningMessages();
        }
        /// <summary>
        /// Makes the required controls visible when Product RadioButton is checked.
        /// </summary>
        private void ProductItemTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsSection = false;

            VendorCodeLabel.Visible = true;
            PriceLabel.Visible = true;
            PriceTextBox.Visible = true;
            LeftInStockLabel.Visible = true;
            LeftInStockNumericUD.Visible = true;
            DescriptionLabel.Visible = true;
            DescriptionTextBox.Visible = true;
            PhotoLabel.Visible = true;
            AddPhotoButton.Visible = true;
            ImageDirectoryLabel.Visible = true;
            if (Photo != null)
            {
                DeletePhotoButton.Visible = true;
            }

            SortingCodeLabel.Visible = false;

            SortingVendorCodeTextBox_TextChanged(sender, e);
            PriceTextBox_TextChanged(sender, e);
            if (parent is null)
            {
                warning |= ItemWarning.ProductOutOfSection;
            }
            UpdateWarningMessages();
        }

        /// <summary>
        /// Creates an OpenFileDialog and adds the selected image to the corresponding property.
        /// </summary>
        private void AddPhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Filter = "All Image files|*.png;*.bmp;*.jpeg;*jpg|" +
                         "PNG files (*.png)|*.png|BMP files (*.bmp)|*.bmp|" +
                         "JPEG files (*.jpeg)|*.jpeg|JPG files (*.jpg)|*.jpg",
                Title = "Load an Image",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Photo = new Bitmap(openFileDialog.FileName);
                ImageDirectoryLabel.Text = Path.GetFileName(openFileDialog.FileName);
                DeletePhotoButton.Visible = true;
            }
        }
        /// <summary>
        /// Clears the property containing the selected image.
        /// </summary>
        private void DeletePhotoButton_Click(object sender, EventArgs e)
        {
            Photo = null;
            DeletePhotoButton.Visible = false;
            ImageDirectoryLabel.Text = "No image selected.";
        }

        /// <summary>
        /// Creates a requested item if possible.
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (warning == ItemWarning.None)
            {
                if (IsSection)
                {
                    SectionName = ItemNameTextBox.Text;
                    SortingCode = SortingVendorCodeTextBox.Text;
                }
                else
                {
                    ProductName = ItemNameTextBox.Text;
                    VendorCode = SortingVendorCodeTextBox.Text;
                    Price = double.Parse(PriceTextBox.Text);
                    LeftInStock = (int)LeftInStockNumericUD.Value < 0 ? 0 : (int)LeftInStockNumericUD.Value;
                    Description = DescriptionTextBox.Text;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Messages.FixErrorsText, Messages.FixErrorsCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Incorrect Data Handlers
        /// <summary>
        /// Checks if the same name is present in the parent node. If so, displays a warning.
        /// </summary>
        private void ItemNameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool throwError;
            string text = ItemNameTextBox.Text;
            if (parent is null)
            {
                throwError = warehouse.Sections.Exists(x => x.Name == text && x.Name != ignoreName)
                            || string.IsNullOrWhiteSpace(text);
            }
            else
            {
                throwError = parent.Nodes.ContainsKey(text) && text != ignoreName
                             || string.IsNullOrWhiteSpace(text);
            }

            if (throwError)
            {
                warning |= ItemWarning.NameRepeated;
            }
            else
            {
                warning &= ~ItemWarning.NameRepeated;
            }
            UpdateWarningMessages();
        }
        /// <summary>
        /// Checks if the price is a double value. If not, displays a warning.
        /// </summary>
        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(PriceTextBox.Text, out double itemPrice) && itemPrice >= 0 || IsSection)
            {
                Price = itemPrice;
                warning &= ~ItemWarning.InvalidPrice;
            }
            else
            {
                warning |= ItemWarning.InvalidPrice;
            }
            UpdateWarningMessages();
        }
        /// <summary>
        /// Checks if the sorting or vendor code is empty. If so, displays a warning.
        /// </summary>
        private void SortingVendorCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsSection && string.IsNullOrWhiteSpace(SortingVendorCodeTextBox.Text))
            {
                warning |= ItemWarning.InvalidVendorCode;
            }
            else
            {
                warning &= ~ItemWarning.InvalidVendorCode;
            }
            UpdateWarningMessages();
        }

        /// <summary>
        /// Updates the text in the Warning label.
        /// </summary>
        private void UpdateWarningMessages()
        {
            WarningTextLabel.Text = string.Empty;
            if (warning == ItemWarning.None)
            {
                return;
            }
            if (warning.HasFlag(ItemWarning.NameRepeated))
            {
                WarningTextLabel.Text += "This name already exists inside the parent Section " +
                    "or is empty." + Environment.NewLine;
            }
            if (warning.HasFlag(ItemWarning.InvalidVendorCode))
            {
                WarningTextLabel.Text += $"Cannot have an empty Vendor code." +
                    Environment.NewLine;
            }
            if (warning.HasFlag(ItemWarning.InvalidPrice))
            {
                WarningTextLabel.Text += "Price must be a non-negative real value." +
                    Environment.NewLine;
            }
            if (warning.HasFlag(ItemWarning.ProductOutOfSection))
            {
                WarningTextLabel.Text += "Product must be a child of a Section." +
                    Environment.NewLine;
            }
        }
        #endregion

        #region Hover Handlers
        private void OnSectionItemTypeHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "Check this button if you want to create your item with " +
                "the type of Section." + Environment.NewLine +
                "It can hold Products and other Sections within itself.";
        }
        private void OnProductItemTypeHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "Check this button if you want to create your item with " +
                "the type of Product." + Environment.NewLine + "It represents an item with " +
                "properties such as a price, the number of them left in stock, etc.";
        }
        private void OnParentNameHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "The name of the Section that will contain the item.";
        }
        private void OnItemNameHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = $"The name of this {(IsSection ? "Section" : "Product")}." +
                Environment.NewLine + "Must not match any existing names inside the parent Section.";
        }
        private void OnSortingVendorCodeHover(object sender, EventArgs e)
        {
            if (IsSection)
            {
                InfoTextLabel.Text = "The code that will be used for this Section when sorting Sections " +
                "inside the parent Section." + Environment.NewLine + "Optional.";
            }
            else
            {
                InfoTextLabel.Text = "The vendor code of the Product.";
            }
        }
        private void OnPriceHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "The price of the Product." + Environment.NewLine +
                "Must be a non-negative real number.";
        }
        private void OnLeftInStockHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "The number of items of this type of Product left in stock. " +
                Environment.NewLine + "Must be a non-negative integer.";
        }
        private void OnDescriptionHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "The description of the Product." + Environment.NewLine + "Optional.";
        }
        private void OnPhotoHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = "The photo of the Product." + Environment.NewLine + "Optional.";
        }
        private void OnConfirmButtonHover(object sender, EventArgs e)
        {
            InfoTextLabel.Text = $"Create your {(IsSection ? "Section" : "Product")}.";
        }

        /// <summary>
        /// Clears the information from the Info label.
        /// </summary>
        private void ClearInformation(object sender, EventArgs e)
        {
            InfoTextLabel.Text = string.Empty;
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// Retrieves information from the provided item (used when in Edit mode).
        /// </summary>
        /// <param name="item">The item to read information from.</param>
        private void GetItemInfo(IStorable item)
        {
            if (item is Section s)
            {
                SectionItemTypeRadioButton.Checked = true;
                ProductItemTypeRadioButton.Checked = false;

                SectionItemTypeRadioButton.Enabled = false;
                ProductItemTypeRadioButton.Enabled = false;

                IsSection = true;
                Name = s.Name;
                ItemNameTextBox.Text = s.Name;
                SortingCode = s.SortingCode;
                SortingVendorCodeTextBox.Text = s.SortingCode;
            }
            else if (item is Product p)
            {
                SectionItemTypeRadioButton.Checked = false;
                ProductItemTypeRadioButton.Checked = true;

                SectionItemTypeRadioButton.Enabled = false;
                ProductItemTypeRadioButton.Enabled = false;

                IsSection = false;
                Name = p.Name;
                ItemNameTextBox.Text = p.Name;
                VendorCode = p.VendorCode;
                SortingVendorCodeTextBox.Text = p.VendorCode;
                Price = p.Price;
                PriceTextBox.Text = p.Price.ToString();
                LeftInStock = p.LeftInStock;
                LeftInStockNumericUD.Value = p.LeftInStock;
                Description = p.Description;
                DescriptionTextBox.Text = p.Description;
                Photo = p.Photo;
                if (p.Photo != null)
                {
                    ImageDirectoryLabel.Text = "Image selected.";
                    DeletePhotoButton.Visible = true;
                }
                else
                {
                    ImageDirectoryLabel.Text = "";
                    DeletePhotoButton.Visible = false;
                }
            }
        }
        #endregion

        #endregion
    }
}