using EPPlusLibrary.PositionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public struct Rectangle : IComparable
    {
        public Position FirstPosition { get; set; }
        public Position SecondPosition { get; set; }
        public int XDistance { get => (int)(SecondPosition - FirstPosition).X; }
        public int YDistance { get => (int)(SecondPosition - FirstPosition).Y; }

        public Rectangle(Position firstPosition, Position secondPosition)
        {
            FirstPosition = firstPosition;
            SecondPosition = secondPosition;
        }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            
            if (obj is Rectangle secondRectangle)
            {
                var leftx1 = FirstPosition.X;
                var lefty1 = FirstPosition.Y;
                var leftx2 = SecondPosition.X;
                var lefty2 = SecondPosition.Y;

                var rightx1 = secondRectangle.FirstPosition.X;
                var righty1 = secondRectangle.FirstPosition.Y;
                var rightx2 = secondRectangle.SecondPosition.X;
                var righty2 = secondRectangle.SecondPosition.Y;

                if(leftx1 == rightx1)
                {
                    if(lefty1 == righty1)
                    {
                        if (leftx2 == rightx2)
                        {
                            if (lefty2 == righty2)
                            {

                            }
                        }
                    }
                }


                return x1 > x2 ? x1 : x2;
            }
            else
                throw new ArgumentException("Object is not a Position");
        }
    }
}