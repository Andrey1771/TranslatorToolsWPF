using EPPlusLibrary.PositionUtil;
using System;
using System.Collections.Generic;

namespace EPPlusLibrary
{
    public struct Rectangle : IComparable<Rectangle>, IComparable, IComparer<Rectangle>, IComparer<object>
    {
        public int Compare(Rectangle leftRectangle, Rectangle rightRectangle)
        {
            var leftx1 = leftRectangle.FirstPosition.X;
            var lefty1 = leftRectangle.FirstPosition.Y;
            var leftx2 = leftRectangle.SecondPosition.X;
            var lefty2 = leftRectangle.SecondPosition.Y;

            var rightx1 = rightRectangle.FirstPosition.X;
            var righty1 = rightRectangle.FirstPosition.Y;
            var rightx2 = rightRectangle.SecondPosition.X;
            var righty2 = rightRectangle.SecondPosition.Y;

            var leftExpression = (leftx1, lefty1, leftx2, lefty2);
            var rightExpression = (rightx1, righty1, rightx2, righty2);

            return leftExpression.CompareTo(rightExpression);
        }
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

                var leftExpression = (leftx1, lefty1, leftx2, lefty2);
                var rightExpression = (rightx1, righty1, rightx2, righty2);

                return leftExpression.CompareTo(rightExpression);
            }
            else
                throw new ArgumentException("Object is not a Position");
        }

        public int CompareTo(Rectangle rightRectangle)
        {
                var leftx1 = FirstPosition.X;
                var lefty1 = FirstPosition.Y;
                var leftx2 = SecondPosition.X;
                var lefty2 = SecondPosition.Y;

                var rightx1 = rightRectangle.FirstPosition.X;
                var righty1 = rightRectangle.FirstPosition.Y;
                var rightx2 = rightRectangle.SecondPosition.X;
                var righty2 = rightRectangle.SecondPosition.Y;

                var leftExpression = (leftx1, lefty1, leftx2, lefty2);
                var rightExpression = (rightx1, righty1, rightx2, righty2);

                return leftExpression.CompareTo(rightExpression);
        }

        public int Compare(object x, object y)
        {
            var leftRectangle = (Rectangle)x;
            var rightRectangle = (Rectangle)y;

            var leftx1 = leftRectangle.FirstPosition.X;
            var lefty1 = leftRectangle.FirstPosition.Y;
            var leftx2 = leftRectangle.SecondPosition.X;
            var lefty2 = leftRectangle.SecondPosition.Y;

            var rightx1 = rightRectangle.FirstPosition.X;
            var righty1 = rightRectangle.FirstPosition.Y;
            var rightx2 = rightRectangle.SecondPosition.X;
            var righty2 = rightRectangle.SecondPosition.Y;

            var leftExpression = (leftx1, lefty1, leftx2, lefty2);
            var rightExpression = (rightx1, righty1, rightx2, righty2);

            return leftExpression.CompareTo(rightExpression);
        }
    }
}