using System;

namespace TurtleCommand
{
    class Program
    {
        private static TurtleCommand _turtleCommand;
        public static TurtleCommand Command
        {
            get
            {
                if (_turtleCommand == null)
                {
                    _turtleCommand = new TurtleCommand(5, 5);
                }
                return _turtleCommand;
            }
        }
        static void Main(string[] args)
        {
            bool exit = false;
            bool IsValid = true;

            while (!exit)
            {
                Console.WriteLine("Please enter next Command. Enter Help to know the valid commands");
                var input = Console.ReadLine();
                args = input.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var operation = args[0];
                var IsValidOperation = Enum.TryParse(operation, true, out Operation parsedOperation);


                if (!IsValidOperation)
                {
                    throw new ArgumentException("Invalid entity history type.");
                }
                switch (parsedOperation)
                {
                    case Operation.Place:
                        if (args.Length != 4) IsValid = false;
                        var IsValidXPosition = int.TryParse(args[1], out int xPosition);
                        var IsValidYPosition = int.TryParse(args[2], out int yPosition);
                        var IsValidDirection = Enum.TryParse(args[3], true, out Direction direction);
                        IsValid = IsValidXPosition && IsValidYPosition && IsValidDirection;
                        if (IsValid) Command.Place(xPosition, yPosition, direction);
                        break;
                    case Operation.Left:
                        Command.Left();
                        break;
                    case Operation.Right:
                        Command.Right();
                        break;
                    case Operation.Move:
                        Command.Move();
                        break;
                    case Operation.Report:
                        var positionDetails = Command.Report();
                        Console.WriteLine($"{positionDetails.Item1} {positionDetails.Item2} {positionDetails.Item3}");
                        break;
                    case Operation.Exit:
                        exit = true;
                        break;
                    case Operation.Help:
                        Console.WriteLine(@"
                                         PLACE X,Y,F
                                         MOVE
                                         LEFT
                                         RIGHT
                                         REPORT");
                        break;
                }
                if (!IsValid)
                    Console.WriteLine("Invalid arguments. Please use Help command to get the command details");

            }
        }
    }

    public enum Operation
    {
        Place,
        Move,
        Left,
        Right,
        Report,
        Exit,
        Help
    }
}
