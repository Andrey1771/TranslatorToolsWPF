using System.Collections.Generic;
using System.Linq;
using DocumentBuilderLibrary;
using DocumentBuilderLibrary.Interfaces;
using DocumentBuilderLibrary.Interfaces.Strategies;

namespace EPPlusLibrary
{
    public class EpplusDataConvertor<T> : IDataConverter<T>
    {
        public IPart DataToPart(ICollection<T> data)
        {
            var newPart = new EPPLusPart();
            var dataTable = new Table<string>();

            data.Select(element =>
            {
                var ok = true;
                return dataTable.AddToEndHorizontally(element.ToString(), out ok);
            });

            newPart.AddData(dataTable);
            return new EPPLusPart();
        }

        public ICollection<T> PartToData()
        {
            throw new System.NotImplementedException();
        }

        //public Task Export(Table table, string filePath);
        //public void Import(string filePath);

    }
}
