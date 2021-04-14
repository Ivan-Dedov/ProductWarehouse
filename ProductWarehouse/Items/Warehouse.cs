using System;
using System.Collections.Generic;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a warehouse that can contain items - sections and products.
    /// </summary>
    [Serializable]
    public class Warehouse : IWarehouse
    {
        /// <summary>
        /// The sections inside the warehouse.
        /// </summary>
        public List<Section> Sections { get; set; }

        /// <summary>
        /// Searches for the section inside the warehouse by its name.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <returns>The section with a required name if it is present;
        /// throws a KeyNotFoundException otherwise.</returns>
        public Section this[string name]
        {
            get
            {
                foreach(var item in Sections)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                throw new KeyNotFoundException("A Section with such name does not exist.");
            }
            set
            {
                int foundIndex = -1;
                for(int i = 0; i < Sections.Count; i++)
                {
                    if (Sections[i].Name == name)
                    {
                        foundIndex = i;
                        break;
                    }
                }
                if (foundIndex == -1)
                {
                    throw new KeyNotFoundException("A Section with such name does not exist.");
                }
                else
                {
                    Sections[foundIndex] = value;
                }
            }
        }
    }
}