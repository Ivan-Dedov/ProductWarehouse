namespace ProductWarehouse
{
    public interface IStorable
    {
        string Name { get; set; }
        IContainer Parent { get; set; }
    }
}