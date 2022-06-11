namespace EPPlusLibrary.PositionUtil
{
    public struct XPosition
    {
        int X { get; set; }

        public XPosition(int x)
        {
            X = x;
        }

        public static bool operator >(XPosition leftXPos, XPosition rightXPos)
            => leftXPos.X > rightXPos.X;
        
        public static bool operator <(XPosition leftXPos, XPosition rightXPos)
            => leftXPos.X < rightXPos.X;

        public static bool operator ==(XPosition leftXPos, XPosition rightXPos)
            => leftXPos.X == rightXPos.X;

        public static bool operator !=(XPosition leftXPos, XPosition rightXPos)
            => leftXPos.X != rightXPos.X;

        public static implicit operator XPosition(int x)
            => new XPosition { X = x };
        
        public static explicit operator int(XPosition xPosition)
            => xPosition.X;

        public static XPosition operator -(XPosition leftPos, XPosition rightPos)
            => new XPosition(leftPos.X - rightPos.X);

        public static XPosition operator ++(XPosition pos)
            => new XPosition(++pos.X);

        //public static XPosition operator =(int right)
        //=> new XPosition(right);
    }
}
