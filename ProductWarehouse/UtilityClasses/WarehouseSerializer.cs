using Newtonsoft.Json;
using System;
using System.IO;

namespace ProductWarehouse
{
    /// <summary>
    /// Contains the methods necessary to correctly serialize and deserialize the warehouse.
    /// </summary>
    public static class WarehouseSerializer
    {
        #region Serializing and Deserializing
        /// <summary>
        /// Serializes a warehouse in a JSON format.
        /// </summary>
        /// <param name="wh">The warehouse to be serialized.</param>
        /// <param name="fileName">The name of the file in which to
        /// write the serialized data.</param>
        public static void Serialize(Warehouse warehouse, string fileName)
        {
            // Annulling parents in order to avoid recursion.
            AnnulParents(warehouse);
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            };

            using StreamWriter sw = new StreamWriter(fileName);
            string serializedWarehouse = JsonConvert.SerializeObject(warehouse,
                Formatting.Indented, settings);
            sw.Write(serializedWarehouse);
        }
        /// <summary>
        /// Deserialized a warehouse from the JSON file.
        /// </summary>
        /// <param name="fileName">The name of the file to deserialize.</param>
        /// <returns>A deserialized warehouse.</returns>
        public static Warehouse Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("The save file does not exist.");
            }

            string jsonWarehouse;
            using (StreamReader sr = new StreamReader(fileName))
            {
                jsonWarehouse = sr.ReadToEnd();
            }

            Warehouse warehouse;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                };
                warehouse = JsonConvert.DeserializeObject<Warehouse>(jsonWarehouse, settings);

                // Deducing parents back in order to ensure that the app runs correctly.
                AddMissingParents(warehouse);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(Messages.UnexpectedErrorCaption +
                    Environment.NewLine + ex.Message);
            }
            return warehouse;
        }
        #endregion

        #region Parent Managing
        /// <summary>
        /// Removes all parents from all the items within a specified warehouse.
        /// </summary>
        /// <param name="warehouse">The warehouse to clear parents from.</param>
        public static void AnnulParents(Warehouse warehouse)
        {
            foreach (Section section in warehouse.Sections)
            {
                AnnulParentsInSection(section);
            }
        }
        /// <summary>
        /// Recursively removes all parents from the specified section.
        /// </summary>
        /// <param name="section">The section to remove all parents from.</param>
        public static void AnnulParentsInSection(Section section)
        {
            foreach (var item in section.Items)
            {
                if (item is Section s)
                {
                    s.Parent = null;
                    AnnulParentsInSection(s);
                }
                else if (item is Product p)
                {
                    p.Parent = null;
                }
            }
        }
        /// <summary>
        /// Deduces the parents of all the items inside the warehouse.
        /// </summary>
        /// <param name="warehouse">The warehouse to fill the parents in.</param>
        public static void AddMissingParents(Warehouse warehouse)
        {
            foreach (Section section in warehouse.Sections)
            {
                AddMissingParentsInSection(section);
            }
        }
        /// <summary>
        /// Recursively deduces the parents of all the items inside the specified section.
        /// </summary>
        /// <param name="section">The section to fill parents into.</param>
        public static void AddMissingParentsInSection(Section section)
        {
            foreach (var item in section.Items)
            {
                if (item is Section s)
                {
                    s.Parent = section;
                    AddMissingParentsInSection(s);
                }
                else if (item is Product p)
                {
                    p.Parent = section;
                }
            }
        }
        #endregion
    }
}