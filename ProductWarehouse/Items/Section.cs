using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a section which can hold other sections or items inside of it.
    /// </summary>
    [Serializable]
    public class Section : IContainer, IStorable, IComparable
    {
        #region Fields
        private List<IStorable> items;
        #endregion

        #region Properties
        public List<IStorable> Items
        {
            get => items;
            set => items = value;
        }
        public string Name { get; set; }
        public string SortingCode { get; set; }
        public IContainer Parent { get; set; }
        #endregion

        #region Constructors
        private Section()
        {
            Items = new List<IStorable>();
        }
        public Section(string name)
            : this()
        {
            Name = name;
        }
        public Section(string name, string sortingCode)
            : this(name)
        {
            SortingCode = sortingCode;
        }
        public Section(string name, IEnumerable<IStorable> items)
            : this(name)
        {
            Items = items.ToList();
        }
        public Section(string name, IEnumerable<IStorable> items, string sortingCode)
            : this(name, sortingCode)
        {
            Items = items.ToList();
        }
        #endregion

        #region Indexers
        public IStorable this[int index]
        {
            get
            {
                if (index < 0 || index >= items.Count)
                {
                    throw new IndexOutOfRangeException("Index was out of bounds of the List.");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= items.Count)
                {
                    throw new IndexOutOfRangeException("Index was out of bounds of the List.");
                }
                items[index] = value;
            }
        }
        public IStorable this[string name]
        {
            get
            {
                foreach (var item in items)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                throw new KeyNotFoundException("A Storable with such name does not exist.");
            }
            set
            {
                IStorable foundItem = null;
                foreach (var item in items)
                {
                    if (item.Name == name)
                    {
                        foundItem = item;
                        break;
                    }
                }
                if (foundItem == null)
                {
                    throw new KeyNotFoundException("A Storable with such name does not exist.");
                }
                else
                {
                    foundItem = value;
                }
            }
        }

        #endregion

        #region Methods
        public void Add(IStorable item)
        {
            items.Add(item);
        }
        public void Add(IStorable item, int index)
        {
            items.Add(null);
            for (int i = index + 1; i < items.Count; i++)
            {
                items[i] = items[i - 1];
            }
            items[index] = item;
        }

        public bool Contains(IStorable storable)
        {
            return items.Contains(storable);
        }
        public bool ContainsAnywhere(IStorable storable)
        {
            return LookUp(this, storable);
        }
        public static bool LookUp(Section section, IStorable storable)
        {
            foreach (var item in section.Items)
            {
                if (item is Section s)
                {
                    if (LookUp(s, storable))
                    {
                        return true;
                    }
                }
                else if (item is Product p)
                {
                    if (p == storable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Remove(IStorable item)
        {
            items.Remove(item);
        }
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public int CompareTo(object? other)
        {
            if (other is Section s)
            {
                int res = SortingCode.CompareTo(s.SortingCode);
                if (res == 0)
                {
                    return Name.CompareTo(s.Name);
                }
                else
                {
                    return res;
                }
            }
            return 1;
        }

        public void Sort(bool recursive = false)
        {
            List<IStorable> sortedList = new List<IStorable>();
            foreach (var item in items)
            {
                if (item is Section)
                {
                    sortedList.Add(item);
                }
            }
            sortedList.Sort();

            foreach (var item in items)
            {
                if (!(item is Section))
                {
                    sortedList.Add(item);
                }
            }
            items = sortedList;

            if (recursive)
            {
                foreach(var item in items)
                {
                    if (item is Section s)
                    {
                        s.Sort(recursive);
                    }
                }
            }
        }
        #endregion
    }
}