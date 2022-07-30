using System.Collections.Generic;
using DocumentBuilderLibrary.Interfaces.Strategies;

namespace DocumentBuilderLibrary.Interfaces
{
    public interface IDataConverter<T>
    {
        IPart DataToPart(ICollection<T> data);
        ICollection<T> PartToData();
    }
}
