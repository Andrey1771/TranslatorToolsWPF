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
        //public static XPosition operator =(int right)
        //=> new XPosition(right);
    }
}
