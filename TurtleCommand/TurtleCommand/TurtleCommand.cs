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

    public class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class TurtleCommand
    {
        private int XLimit { get; }
        private int YLimit { get; }

        int? _XCoOrdinate;
        public int? XCoOrdinate
        {
            get { return _XCoOrdinate; }
            set
            {
                if (value.HasValue && value.Value >= 0 && value.Value < XLimit)
                {
                    _XCoOrdinate = value.Value;
                }
                else
                {
                    throw new ArgumentException("Invalid X Position");
                }
            }
        }

        int? _YCoOrdinate;
        public int? YCoOrdinate
        {
            get
            {
                return _YCoOrdinate;
            }
            set
            {
                if (value.HasValue && value.Value >= 0 && value.Value < YLimit)
                {
                    _YCoOrdinate = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Y Position");
                }
            }
        }

        public Direction? CurrentDirection { get; set; }
        public TurtleCommand(int x, int y)
        {
            XLimit = x;
            YLimit = y;
        }

        private bool HasBeenPlaced()
        {
            return this.XCoOrdinate.HasValue && this.YCoOrdinate.HasValue && this.CurrentDirection.HasValue;
        }

        public ValidationResult Left()
        {
            if (!HasBeenPlaced())
            {
                return new ValidationResult()
                {
                    IsSuccess = false,
                    Message = "Please enter valid Place command before using Left command"
                };
            }
            //Console.WriteLine("Please enter valid Place command before Left command");
            var newDirection = this.CurrentDirection + 1;
            if ((int)newDirection == 4) this.CurrentDirection = Direction.East;
            else this.CurrentDirection = newDirection;

            return new ValidationResult()
            {
                IsSuccess = true
            };
        }

        public ValidationResult Right()
        {
            if (!HasBeenPlaced())
            {
                return new ValidationResult()
                {
                    IsSuccess = false,
                    Message = "Please enter valid Place command before Right command"
                };
            }
            var newDirection = this.CurrentDirection - 1;
            if ((int)newDirection == -1) this.CurrentDirection = Direction.South;
            else this.CurrentDirection = newDirection;

            return new ValidationResult()
            {
                IsSuccess = true
            };
        }

        public ValidationResult Move()
        {
            if (!HasBeenPlaced())
            {
                return new ValidationResult()
                {
                    IsSuccess = false,
                    Message = "Please enter valid Place command before Move command"
                };
            }
            if (!HasBeenPlaced()) Console.WriteLine("Please enter valid Place command before Move command");
            if (CurrentDirection == Direction.North) this.YCoOrdinate++;
            if (CurrentDirection == Direction.South) this.YCoOrdinate--;
            if (CurrentDirection == Direction.East) this.XCoOrdinate++;
            if (CurrentDirection == Direction.West) this.XCoOrdinate--;

            return new ValidationResult()
            {
                IsSuccess = true
            };

        }

        public Tuple<int?, int?, Direction?, ValidationResult> Report()
        {
            if (!HasBeenPlaced())
            {
                return new Tuple<int?, int?, Direction?, ValidationResult>(null, null, null, new ValidationResult()
                {
                    IsSuccess = false,
                    Message = "Please enter valid Place command before Report command"
                });
            }
            if (!HasBeenPlaced()) Console.WriteLine("Please enter valid Place command before Report command");
            return new Tuple<int?, int?, Direction?, ValidationResult>(XCoOrdinate.Value, YCoOrdinate.Value, this.CurrentDirection.Value, new ValidationResult() { IsSuccess = true });

        }



        public ValidationResult Place(int x, int y, Direction direction)
        {
            try
            {
                this.XCoOrdinate = x;
                this.YCoOrdinate = y;
                this.CurrentDirection = direction;
                return new ValidationResult() { IsSuccess = true };
            }
            catch (ArgumentException ex)
            {
                return new ValidationResult()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
