using DocumentBuilderLibrary;
using DocumentBuilderLibrary.Interfaces;
using DocumentBuilderLibrary.Interfaces.Strategies;

namespace EPPlusLibrary
{
    public class EPPLusPart : IPart
    {
        public Table<string> Data { get; }

        public void AddData(Table<string> dataTable)
        {
            var ok = true;
            Data.Add(dataTable, out ok);
        }

        public void MergePart(IPart part, IAddStrategy addStrategy)
        {
            var ok = true;
            Data.Add(part.Data, out ok);
        }

        public void RemovePart(IPart part)
        {
            Data.Delete(part.Data);
        }
    }
}
