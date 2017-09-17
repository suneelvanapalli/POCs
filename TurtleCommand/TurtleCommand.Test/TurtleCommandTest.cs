using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleCommand.Test
{
    [TestClass]
    public class TurtleCommandTest
    {
        [TestMethod]
        public void TestCase1()
        {
            var turtleCommand = new TurtleCommand(5, 5);
            turtleCommand.Place(0, 0, Direction.North);
            turtleCommand.Move();
            var report = turtleCommand.Report();

            Assert.AreEqual(report.Item1, 0);
            Assert.AreEqual(report.Item2, 1);
            Assert.AreEqual(report.Item3, Direction.North);
        }

        [TestMethod]
        public void TestCase2()
        {
            var turtleCommand = new TurtleCommand(5, 5);
            turtleCommand.Place(0, 0, Direction.North);
            turtleCommand.Left();
            var report = turtleCommand.Report();

            Assert.AreEqual(report.Item1, 0);
            Assert.AreEqual(report.Item2, 0);
            Assert.AreEqual(report.Item3, Direction.West);
        }

        [TestMethod]
        public void TestCase3()
        {
            
            var turtleCommand = new TurtleCommand(5, 5);
                        
            turtleCommand.Place(1, 2, Direction.East);
            turtleCommand.Move();
            turtleCommand.Move();
            turtleCommand.Left();
            turtleCommand.Move();

            var report = turtleCommand.Report();
            Assert.AreEqual(report.Item1, 3);
            Assert.AreEqual(report.Item2, 3);
            Assert.AreEqual(report.Item3, Direction.North);
        }

        [TestMethod]
        public void TurtleIgnoringOtherCommandsBeforePlacedOnTable()
        {
            var turtleCommand = new TurtleCommand(5, 5);
            turtleCommand.Left();
            Assert.Equals(turtleCommand.CurrentDirection, null);
            Assert.Equals(turtleCommand.XCoOrdinate, null);
            Assert.Equals(turtleCommand.YCoOrdinate, null);
        }
    }
}
