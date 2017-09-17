using System;
using System.IO;

namespace TurtleCommand
{
    class Program
    {
        static TurtleCommand turtleCommand = new TurtleCommand(5, 5);

        static void Main(string[] args)
        {
            bool exit = false;
            string input = string.Empty;

            while (!exit)
            {
                //Console.WriteLine("Please enter next Command. Enter Help to know the valid commands");
                input = Console.ReadLine();
                args = input.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var operation = args[0];

                var IsValidOperation = Enum.TryParse(operation, true, out Operation parsedOperation);
                if (!IsValidOperation)
                {
                    Console.WriteLine("Invalid operation.");
                }
                if (parsedOperation == Operation.Exit) exit = true;
                else if (parsedOperation == Operation.File)
                {
                    FileStream fileStream = new FileStream(args[1], FileMode.Open);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            args = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            IsValidOperation = Enum.TryParse(args[0], true, out parsedOperation);
                            if (!IsValidOperation)
                            {
                                Console.WriteLine("Invalid operation.");
                            }

                            ProcessCommand(parsedOperation, args.Length > 1 ? args[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries) : new string[] { });
                        }
                    }
                }
                else ProcessCommand(parsedOperation, args.Length > 1 ? args[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries) : new string[] { });

            }
        }



        private static void ProcessCommand(Operation operation, params string[] args)
        {
            Console.WriteLine($"Executed command {operation.ToString()}");
            ValidationResult validationResult = null;
            switch (operation)
            {
                case Operation.Place:
                    if (args.Length != 3)
                    {
                        validationResult = new ValidationResult() { IsSuccess = false, Message = "Invalid arguments. Please use Help command to get the command details" };
                        break;
                    }
                    var IsValidXPosition = int.TryParse(args[0], out int xPosition);
                    var IsValidYPosition = int.TryParse(args[1], out int yPosition);
                    var IsValidDirection = Enum.TryParse(args[2], true, out Direction direction);
                    var IsValid = IsValidXPosition && IsValidYPosition && IsValidDirection;
                    if (IsValid)
                    {
                        validationResult = turtleCommand.Place(xPosition, yPosition, direction);
                    }
                    break;
                case Operation.Left:
                    validationResult = turtleCommand.Left();
                    break;
                case Operation.Right:
                    validationResult = turtleCommand.Right();
                    break;
                case Operation.Move:
                    validationResult = turtleCommand.Move();
                    break;
                case Operation.Report:
                    var positionDetails = turtleCommand.Report();
                    if (positionDetails.Item4.IsSuccess)
                        Console.WriteLine($"{positionDetails.Item1} {positionDetails.Item2} {positionDetails.Item3}");
                    else validationResult = positionDetails.Item4;
                    break;
                case Operation.File:

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

            if (validationResult != null && validationResult.IsSuccess == false)
            {
                Console.WriteLine(validationResult.Message);
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
        Help,
        File
    }
}
