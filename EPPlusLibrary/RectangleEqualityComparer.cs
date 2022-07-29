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
            var isIntersect = r1.IsIntersect(r2);
            return isIntersect;
        }

        public int GetHashCode([DisallowNull] Rectangle obj)
        {
            // TODO Так как назначение Equals по сути ответ на пересечение, то GetHashCode некорректен
            return 0;
        }
    }
}
