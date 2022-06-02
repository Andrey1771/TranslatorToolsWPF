namespace EPPlusLibrary.PositionUtil
{
    public struct YPosition
    {
        int Y { get; set; }

        public YPosition(int y)
        {
            Y = y;
        }

        public static bool operator >(YPosition leftYPos, YPosition rightYPos)
            => leftYPos.Y > rightYPos.Y;

        public static bool operator <(YPosition leftYPos, YPosition rightYPos)
            => leftYPos.Y < rightYPos.Y;
    }
}
