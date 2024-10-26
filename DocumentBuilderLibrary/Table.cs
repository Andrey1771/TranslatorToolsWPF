﻿using System;
using System.Collections.Generic;
using System.Linq;
using DocumentBuilderLibrary.PositionUtil;

namespace DocumentBuilderLibrary
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

        public Table<T> AddToEndHorizontally(T obj, out bool ok)
        {
            // TODO Дублирование
            var rectangleKeys = valuesMap.Keys;

            var maxX = rectangleKeys.Max((key) =>
            {
                var x1 = key.FirstPosition.X;
                var x2 = key.SecondPosition.X;
                return x1 > x2 ? x1 : x2;
            });

            return Add(new Position(++maxX, new YPosition(0)), obj, out ok);
        }

        public Table<T> Add(Table<T> table, out bool ok)
        { // TODO Добавить тесты
            table.valuesMap.Select(keyValue =>
            {
                var ok = false;
                return Add(keyValue.Key.FirstPosition, keyValue.Key.SecondPosition, keyValue.Value, out ok);
            });

            ok = true; // TODO Ok не работает везде как надо, удалить или изменить в будущем
            return this;
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

            var minPosition = new Position(0, 0);

            if (inFirstPosition.X < minPosition.X || inFirstPosition.Y < minPosition.Y)
            {
                ok = false;
                return this;
            }

            minPosition++;

            if (inSecondPosition.X < minPosition.X || inSecondPosition.Y < minPosition.Y)
            {
                ok = false;
                return this;
            }

            if (CheckForFree(inFirstPosition, inSecondPosition))
                valuesMap.Add(new Rectangle(inFirstPosition, inSecondPosition), obj);
            else
                ok = false;

            return this;
        }

        public Table<T> Delete(Table<T> table)
        { // TODO Добавить тесты
            table.valuesMap.Select(keyValue =>
            {
                return Delete(keyValue.Key.FirstPosition, keyValue.Key.SecondPosition);
            });
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

        public List<KeyValuePair<Rectangle,T>> ToList()
        {
            return valuesMap.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultObj"></param>
        /// <returns></returns>
        public List<List<T>> ToListTable(T defaultObj = default)
        {
            var rectangleKeys = valuesMap.Keys;

            if (rectangleKeys.Count == 0)
                return new();

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

            var row = new List<T>(Enumerable.Range((int)minPos.X, xLength).Select(i => defaultObj));// Можно Repeat Разницы нет особо
            var tableAsList = new List<List<T>>(Enumerable.Range((int)minPos.Y, yLength).Select(i => new List<T>(row)));

            foreach (var rectangle in rectangleKeys)
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
                    tableAsList[jy][ix] = valuesMap[rectangle];
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
    }
}
