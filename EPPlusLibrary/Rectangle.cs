using EPPlusLibrary.PositionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public struct Rectangle
    {
        public Position FirstPosition { get; set; }
        public Position SecondPosition { get; set; }

        public Rectangle(Position firstPosition, Position secondPosition)
        {
            FirstPosition = firstPosition;
            SecondPosition = secondPosition;
        }
    }
}
