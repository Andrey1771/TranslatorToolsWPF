﻿using System;

namespace DocumentBuilderLibrary.PositionUtil
{
    public struct YPosition : IComparable<YPosition>
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

        public static bool operator >=(YPosition leftYPos, YPosition rightYPos)
           => leftYPos.Y >= rightYPos.Y;

        public static bool operator <=(YPosition leftYPos, YPosition rightYPos)
            => leftYPos.Y <= rightYPos.Y;

        public static bool operator ==(YPosition leftYPos, YPosition rightYPos)
            => leftYPos.Y == rightYPos.Y;

        public static bool operator !=(YPosition leftYPos, YPosition rightYPos)
            => leftYPos.Y != rightYPos.Y;

        public static implicit operator YPosition(int y)
            => new YPosition { Y = y };

        public static explicit operator int(YPosition yPosition)
            => yPosition.Y;

        public static YPosition operator -(YPosition leftPos, YPosition rightPos)
            => new YPosition(leftPos.Y - rightPos.Y);

        public static YPosition operator ++(YPosition pos)
            => new YPosition(++pos.Y);

        public int CompareTo(YPosition rightYPos)
        {
            return Y.CompareTo(rightYPos.Y);
        }
    }
}
