using DocumentBuilderLibrary.PositionUtil;

namespace DocumentBuilderLibrary
{
    public struct Rectangle
    {
        private Position _firstPosition;
        public Position FirstPosition { get => _firstPosition; set { _firstPosition = value; X1Y2 = new Position(_firstPosition.X, _secondPosition.Y); } }

        private Position _secondPosition;
        public Position SecondPosition { get => _secondPosition; set { _secondPosition = value; X2Y1 = new Position(_secondPosition.X, _firstPosition.Y); } }

        private Position X1Y2 { get; set; }
        private Position X2Y1 { get; set; }

        public int XDistance { get => (int)(SecondPosition - FirstPosition).X; }
        public int YDistance { get => (int)(SecondPosition - FirstPosition).Y; }

        public Rectangle(Position firstPosition, Position secondPosition)
        {
            X1Y2 = new Position(firstPosition.X, secondPosition.Y);  // TODO
            X2Y1 = new Position(secondPosition.X, firstPosition.Y);
            _firstPosition = firstPosition; // TODO
            _secondPosition = secondPosition;
        }

        public bool IsIntersect(Rectangle r2)
        {
            return Rectangle.IsIntersect(this, r2);
        }

        public static bool IsIntersect(Rectangle r1, Rectangle r2)
        {
            var isIntersect = r1.FirstPosition.X < r2.SecondPosition.X && r1.SecondPosition.X > r2.FirstPosition.X &&
                              r1.FirstPosition.Y < r2.SecondPosition.Y && r1.SecondPosition.Y > r2.FirstPosition.Y;

            var isIntersect2 = r2.FirstPosition.X < r1.SecondPosition.X && r2.FirstPosition.Y < r1.SecondPosition.Y &&
                               r2.SecondPosition.X > r1.FirstPosition.X && r2.SecondPosition.Y > r1.FirstPosition.Y;

            var isIntersect3 = r2.X1Y2.X < r1.X2Y1.X && r2.X1Y2.Y < r1.X2Y1.Y &&
                               r2.X2Y1.X > r1.X1Y2.X && r2.X2Y1.Y > r1.X1Y2.Y;

            return isIntersect || isIntersect2 || isIntersect3;
        }
    }
}