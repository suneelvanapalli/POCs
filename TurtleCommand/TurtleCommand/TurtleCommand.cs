using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleCommand
{
    public enum Direction
    {
        East = 0,
        North = 1,
        West = 2,
        South = 3
    }

    public class TurtleCommand
    {
        private int XLimit { get; }
        private int YLimit { get; }

        private const int BaseAngle = 360;

        int _XCoOrdinate;
        private int XCoOrdinate
        {
            get { return _XCoOrdinate; }
            set
            {
                if (value >= 0 && value < XLimit)
                {
                    _XCoOrdinate = value;
                }
                else
                {
                    throw new ArgumentException("Invalid X Position");
                }
            }
        }

        int _YCoOrdinate;
        int YCoOrdinate
        {
            get
            {
                return _YCoOrdinate;
            }
            set
            {
                if (value >= 0 && value < YLimit)
                {
                    _YCoOrdinate = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Y Position");
                }
            }
        }

        public Direction CurrentDirection { get; set; }
        public TurtleCommand(int x, int y)
        {
            XLimit = x;
            YLimit = y;
        }

        public void Left()
        {
            var newDirection = this.CurrentDirection + 1;
            if ((int)newDirection == 4) this.CurrentDirection = Direction.East;
            else this.CurrentDirection = newDirection;

        }

        public void Right()
        {
            var newDirection = this.CurrentDirection - 1;
            if ((int)newDirection == -1) this.CurrentDirection = Direction.South;
            else this.CurrentDirection = newDirection;
        }

        public void Move()
        {
            if (CurrentDirection == Direction.North) this.YCoOrdinate++;
            if (CurrentDirection == Direction.South) this.YCoOrdinate--;
            if (CurrentDirection == Direction.East) this.XCoOrdinate++;
            if (CurrentDirection == Direction.West) this.XCoOrdinate--;
        }

        public Tuple<int, int, Direction> Report()
        {
            return new Tuple<int, int, Direction>(XCoOrdinate, YCoOrdinate, this.CurrentDirection);
        }

        public void Place(int x, int y, Direction direction)
        {
            try
            {
                this.XCoOrdinate = x;
                this.YCoOrdinate = y;
                this.CurrentDirection = direction;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
