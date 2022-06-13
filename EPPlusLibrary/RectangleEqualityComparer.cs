using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public class RectangleEqualityComparer : IEqualityComparer<Rectangle>, IComparer<Rectangle>, IComparer<object>
    {
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

        public bool Equals(Rectangle r1, Rectangle r2)
        {
            var isIntersect = r1.FirstPosition.X < r2.SecondPosition.X - 1 && r1.SecondPosition.X - 1 > r2.FirstPosition.X ||
                              r1.FirstPosition.Y < r2.SecondPosition.Y - 1 && r1.SecondPosition.Y - 1 > r2.FirstPosition.Y;
            if (isIntersect)
                return true;

            return false;
        }

        public int GetHashCode([DisallowNull] Rectangle obj)
        {
            // Применить хеш код будет некорректно(Я пока не придумал как эффективно это делать), так как Equals несет другое значение
            return obj.FirstPosition.X.GetHashCode();
        }
    }
}
