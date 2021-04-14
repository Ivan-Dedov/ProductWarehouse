using System.Collections.Generic;

namespace ProductWarehouse
{
    public interface IWarehouse
    {
        List<Section> Sections { get; set; }

        Section this[string name] { get; set; }
    }
}