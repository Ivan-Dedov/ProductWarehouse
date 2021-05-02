using System;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Descsribes a form where the user can set the settings of a
    /// randomly created warehouse.
    /// </summary>
    public partial class WarehouseCreator : Form
    {
        public int NumberOfSections { get; private set; }
        public int NumberOfProducts { get; private set; }

        /// <summary>
        /// Creates a new instance of this form.
        /// </summary>
        public WarehouseCreator()
        {
            InitializeComponent();

            NumberOfSectionsNumericUD.Maximum = Constants.MaxSectionCount;
            NumberOfProductsNumericUD.Maximum = Constants.MaxProductCount; 
        }

        /// <summary>
        /// Sets the properties of this form and returns an OK DialogResult value.
        /// Closes the form.
        /// </summary>
        private void CreateWarehouseButton_Click(object sender, EventArgs e)
        {
            NumberOfSections = (int)NumberOfSectionsNumericUD.Value < 1 ? 1 : (int)NumberOfSectionsNumericUD.Value;
            NumberOfProducts = (int)NumberOfProductsNumericUD.Value < 0 ? 0 : (int)NumberOfProductsNumericUD.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}