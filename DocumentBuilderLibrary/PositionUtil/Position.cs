namespace DocumentBuilderLibrary.PositionUtil
{
    public struct Position
    {
        public XPosition X { get; set; }
        public YPosition Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(XPosition x, YPosition y)
        {
            X = x;
            Y = y;
        }

        public static Position operator -(Position leftPos, Position rightPos)
            => new Position(leftPos.X - rightPos.X, leftPos.Y - rightPos.Y);

        public static Position operator ++(Position pos)
            => new Position(++pos.X, ++pos.Y);
    }
}
