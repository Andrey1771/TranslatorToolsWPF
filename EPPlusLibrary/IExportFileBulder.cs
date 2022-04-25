using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPPlusLibrary.PositionUtil;

namespace EPPlusLibrary
{
    public interface IExportFileBulder
    {
        void AddPartToPos(IPart part, Position pos);
        void AddPartRight(IPart part, YPosition y);
        void AddPartLeft(IPart part, YPosition y);
        void AddPartDown(IPart part, XPosition x);
        void AddPartUp(IPart part, XPosition x);
    }
}
