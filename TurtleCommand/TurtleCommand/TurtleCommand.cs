using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleCommand
{
    public enum Direction
    {
        East = 0,
        North = 90,
        West = 180,
        South = 270
    }



    public class TurtleCommand
    {
        private int XLimit { get; }
        private int YLimit { get; }

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
            this.CurrentDirection = this.CurrentDirection += 90;
        }

        public void Right()
        {
            this.CurrentDirection = this.CurrentDirection += 90;
        }

        public void Move()
        {
            if (CurrentDirection == Direction.North) XCoOrdinate += 1;
            if (CurrentDirection == Direction.South) XCoOrdinate -= 1;
            if (CurrentDirection == Direction.East) YCoOrdinate += 1;
            if (CurrentDirection == Direction.West) YCoOrdinate -= 1;
        }

        public Tuple<int, int, string> Report()
        {
            return new Tuple<int, int, string>(XCoOrdinate, YCoOrdinate, this.CurrentDirection.ToString());
        }

        public void Place(int x, int y, Direction direction)
        {
            this.XCoOrdinate = x;
            this.YCoOrdinate = y;
        }
    }
}
