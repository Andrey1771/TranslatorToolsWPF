namespace DocumentBuilderLibrary
{
    public interface IPart
    {
        Table<string> Data { get; set; }

        void MergePart(IPart part);
        void RemovePart(IPart part);
    }
}
