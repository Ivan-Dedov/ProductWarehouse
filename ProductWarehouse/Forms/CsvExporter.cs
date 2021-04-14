using System;
using System.IO;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Describes a form that is used to make the CSV report on the items that are missing in stock.
    /// </summary>
    public partial class CsvExporter : Form
    {
        #region Fields
        /// <summary>
        /// The warehouse to use when getting items.
        /// </summary>
        private readonly Warehouse warehouse;
        /// <summary>
        /// The threshold value for the item quantity, below which the item count is
        /// considered as being not enough.
        /// </summary>
        private int threshold;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates the form.
        /// </summary>
        /// <param name="warehouse"></param>
        public CsvExporter(Warehouse warehouse)
        {
            this.warehouse = warehouse;

            InitializeComponent();
            QuantityNumericUD.Maximum = int.MaxValue;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Makes the CSV file.
        /// </summary>
        private void ExportCsvButton_Click(object sender, EventArgs e)
        {
            threshold = (int)QuantityNumericUD.Value < 0 ? 0 : (int)QuantityNumericUD.Value;
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
                    sw.Write(GetCsv(warehouse, threshold));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Messages.UnexpectedErrorCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Makes a string representing a CSV file with the required items whose count is
        /// below the threshold.
        /// </summary>
        /// <param name="warehouse">The warehouse to look through.</param>
        /// <param name="threshold">The threshold value for the item count.</param>
        /// <returns>A string containing the CSV file.</returns>
        private string GetCsv(Warehouse warehouse, int threshold)
        {
            string res = "Path,Vendor code,Item name,Left in Stock" + Environment.NewLine;

            foreach(var section in warehouse.Sections)
            {
                GetRequiredItems(ref res, section, section.Name, threshold);
            }

            return res;
        }
        /// <summary>
        /// Retrieves the items in a given section whose quantity is below a given threshold,
        /// and puts them into the CSV file.
        /// </summary>
        /// <param name="res">The resulting CSV string.</param>
        /// <param name="section">The section to look up.</param>
        /// <param name="pathToSection">The path to the current section.</param>
        /// <param name="threshold">The threshold value for the item count.</param>
        private void GetRequiredItems(ref string res, Section section, string pathToSection, int threshold)
        {
            foreach(var item in section.Items)
            {
                if (item is Product p)
                {
                    if (p.LeftInStock < threshold)
                    {
                        res += $"\"{pathToSection}\",\"{p.VendorCode}\",\"{p.Name}\",{p.LeftInStock}" +
                            Environment.NewLine;
                    }
                }
                else if (item is Section s)
                {
                    GetRequiredItems(ref res, s, pathToSection + " / " + s.Name, threshold);
                }
            }
        }
        #endregion
    }
}