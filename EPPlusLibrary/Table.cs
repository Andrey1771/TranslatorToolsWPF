using EPPlusLibrary.PositionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public class Table
    {
        Dictionary<Position, object> valuesMap;
        public object this[int x, int y]
        {
            get { return DataRecordsMap[date.Date]; }
        }
        //public IEnumerable<IEnumerable>
    }
}
