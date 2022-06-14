using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public class RectangleEqualityComparer : IEqualityComparer<Rectangle>
    {
        public bool Equals(Rectangle r1, Rectangle r2)
        {
            var isIntersect = r1.FirstPosition.X <= r2.SecondPosition.X - 1 && r1.SecondPosition.X - 1 >= r2.FirstPosition.X ||
                              r1.FirstPosition.Y <= r2.SecondPosition.Y - 1 && r1.SecondPosition.Y - 1 >= r2.FirstPosition.Y;
            if (isIntersect)
                return true;

            return false;
        }

        public int GetHashCode([DisallowNull] Rectangle obj)
        {
            // Применить хеш код будет некорректно(Я пока не придумал как эффективно это делать), так как Equals несет другое значение
            return obj.FirstPosition.X.GetHashCode() + obj.FirstPosition.Y.GetHashCode() +
                   obj.SecondPosition.X.GetHashCode() + obj.SecondPosition.Y.GetHashCode();
        }
    }
}
