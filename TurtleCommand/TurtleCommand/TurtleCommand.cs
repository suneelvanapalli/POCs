using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleCommand
{
    public enum Direction
    {
        East = 360,
        North = 90,
        West = 180,
        South = 270
    }

    public class TurtleCommand
    {
        private int XLimit { get; }
        private int YLimit { get; }

        private const int BaseAngle = 360;

        int XCoOrdinate { get; set; }
        int YCoOrdinate { get; set; }

        public Direction CurrentDirection { get; set; }
        public TurtleCommand(int x, int y)
        {
            XLimit = x;
            YLimit = y;
        }

        public void Left()
        {
            this.CurrentDirection = (BaseAngle - this.CurrentDirection) + 90;
        }

        public void Right()
        {
            this.CurrentDirection = (BaseAngle - this.CurrentDirection) - 90;
        }

        public void Move()
        {
            if (CurrentDirection == Direction.North) XCoOrdinate = (XLimit - XCoOrdinate++);
            if (CurrentDirection == Direction.South) XCoOrdinate = (XLimit - XCoOrdinate--);
            if (CurrentDirection == Direction.East) YCoOrdinate = (YLimit - YCoOrdinate++);
            if (CurrentDirection == Direction.West) YCoOrdinate = (YLimit - YCoOrdinate--);
        }

        public Tuple<int, int, Direction> Report()
        {
            return new Tuple<int, int, Direction>(XCoOrdinate, YCoOrdinate, this.CurrentDirection);
        }

        public void Place(int x, int y, Direction direction)
        {
            this.XCoOrdinate = x;
            this.YCoOrdinate = y;
            this.CurrentDirection = direction;
        }
    }
}
