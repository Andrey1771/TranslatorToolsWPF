namespace EPPlusLibrary.PositionUtil
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
    }
}
