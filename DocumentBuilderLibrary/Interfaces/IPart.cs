using DocumentBuilderLibrary.Interfaces.Strategies;

namespace DocumentBuilderLibrary.Interfaces
{
    public interface IPart
    {
        Table<string> Data { get; }

        void AddData(Table<string> dataTable);
        void MergePart(IPart part, IAddStrategy addStrategy);
        void RemovePart(IPart part);
    }
}
