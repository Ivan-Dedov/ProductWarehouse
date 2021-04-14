using System.Collections.Generic;

namespace ProductWarehouse
{
    public interface IContainer
    {
        List<IStorable> Items { get; set; }
        string SortingCode { get; set; }

        IStorable this[int index] { get; set; }
        IStorable this[string name] { get; set; }

        void Add(IStorable item);
        void Add(IStorable item, int index);
        void Remove(IStorable item);
        void RemoveAt(int index);
    }
}