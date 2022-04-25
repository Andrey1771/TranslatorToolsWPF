using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary.PositionUtil
{
    public struct XPosition
    {
        public int X { get; set; }

        public XPosition(int x)
        {
            X = x;
        }

        public static XPosition operator =(int right)
        => new XPosition(right);
    }
}
