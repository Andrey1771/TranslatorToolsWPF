using DocumentBuilderLibrary;

namespace EPPlusLibrary
{
    internal class EPPLusPart : IPart
    {
        public Table<string> Data { get; set; }

        public void MergePart(IPart part)
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
