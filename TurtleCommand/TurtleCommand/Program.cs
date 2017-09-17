﻿using System;

namespace TurtleCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            bool IsValid = true;
            var turtleCommand = new TurtleCommand(5, 5);

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
                ValidationResult validationResult = null;
                switch (parsedOperation)
                {
                    case Operation.Place:
                        if (args.Length != 4)
                        {
                            validationResult = new ValidationResult() { IsSuccess = false, Message = "Invalid arguments. Please use Help command to get the command details" };
                            break;
                        }   
                        var IsValidXPosition = int.TryParse(args[1], out int xPosition);
                        var IsValidYPosition = int.TryParse(args[2], out int yPosition);
                        var IsValidDirection = Enum.TryParse(args[3], true, out Direction direction);
                        IsValid = IsValidXPosition && IsValidYPosition && IsValidDirection;
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

                if (validationResult != null && validationResult.IsSuccess == false)
                {
                    Console.WriteLine(validationResult.Message);
                }
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
