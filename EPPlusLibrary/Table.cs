using EPPlusLibrary.PositionUtil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPPlusLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Table<T>
    {
        Dictionary<Rectangle, T> valuesMap = new(new RectangleEqualityComparer());

        const int _minX = 0;
        const int _minY = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T this[int x, int y]
        {
            get { return valuesMap[new Rectangle(new Position(x, y), new Position(x, y))]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPosition"></param>
        /// <param name="obj"></param>
        /// <param name="ok"></param>
        /// <returns></returns>
        public Table<T> Add(Position inPosition, T obj, out bool ok)
        {
            return Add(inPosition, inPosition, obj, out ok);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inFirstPosition"></param>
        /// <param name="inSecondPosition"></param>
        /// <param name="obj"></param>
        /// <param name="ok"></param>
        /// <returns></returns>
        public Table<T> Add(Position inFirstPosition, Position inSecondPosition, T obj, out bool ok)
        {
            ok = true;

            // Включаем точки
            inSecondPosition++;

            if (CheckForFree(inFirstPosition, inSecondPosition))
                valuesMap.Add(new Rectangle(inFirstPosition, inSecondPosition), obj);
            else
                ok = false;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPosition"></param>
        /// <returns></returns>
        public Table<T> Delete(Position inPosition)
        {
            return Delete(inPosition, inPosition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inFirstPosition"></param>
        /// <param name="inSecondPosition"></param>
        /// <returns></returns>
        public Table<T> Delete(Position inFirstPosition, Position inSecondPosition)
        {
            valuesMap.Remove(new Rectangle(inFirstPosition, inSecondPosition));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultObj"></param>
        /// <returns></returns>
        public List<List<T>> ToListTable(T defaultObj = default)
        {
            var rectangleKeys = valuesMap.Keys;
            var maxX = rectangleKeys.Max((key) =>
            {
                var x1 = key.FirstPosition.X;
                var x2 = key.SecondPosition.X;
                return x1 > x2 ? x1 : x2;
            });
            var maxY = rectangleKeys.Max((key) =>
            {
                var y1 = key.FirstPosition.Y;
                var y2 = key.SecondPosition.Y;
                return y1 > y2 ? y1 : y2;
            });

            var minPos = new Position(_minX, _minY);
            var maxPos = new Position(maxX, maxY);

            var difPositions = maxPos - minPos;

            var xLength = Math.Abs((int)difPositions.X);
            var yLength = Math.Abs((int)difPositions.Y);

            var row = new List<T>(Enumerable.Repeat(defaultObj, xLength));
            var tableAsList = new List<List<T>>(Enumerable.Repeat(row, yLength));
            
            foreach(var rectangle in rectangleKeys)
            {
                CalculateCells(rectangle, tableAsList);
            }

            return tableAsList;
        }

        private void CalculateCells(Rectangle rectangle, List<List<T>> tableAsList)
        {
            var firstX = Math.Min((int)rectangle.FirstPosition.X, (int)rectangle.SecondPosition.X);
            var firstY = Math.Min((int)rectangle.FirstPosition.Y, (int)rectangle.SecondPosition.Y);

            var secondX = Math.Max((int)rectangle.FirstPosition.X, (int)rectangle.SecondPosition.X);
            var secondY = Math.Max((int)rectangle.FirstPosition.Y, (int)rectangle.SecondPosition.Y);


            for (var ix = firstX; ix < secondX; ++ix)
            {
                for (var jy = firstY; jy < secondY; ++jy)
                {
                    tableAsList[ix][jy] = valuesMap[rectangle];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPosition"></param>
        /// <returns></returns>
        private bool CheckForFree(Position inPosition)
        {
            return CheckForFree(inPosition, inPosition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inFirstPosition"></param>
        /// <param name="inSecondPosition"></param>
        /// <returns></returns>
        private bool CheckForFree(Position inFirstPosition, Position inSecondPosition)
        {
            return !valuesMap.ContainsKey(new Rectangle(inFirstPosition, inSecondPosition));
        }

        //public IEnumerable<IEnumerable>
    }
}
