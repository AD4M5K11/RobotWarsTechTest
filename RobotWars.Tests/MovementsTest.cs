using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Build;

namespace RobotWars.Tests
{
    [TestClass]
    public class MovementsTest
    {
        [TestMethod]
        public void MoveRobotToPosition()
        {
            Commands command = new Commands();
            Arena arena;
            bool result = command.IsValidArenaCommand("5 5", out arena);
            Assert.IsTrue(result);
            bool secondResult = command.IsValidArenaCommand("3 3 E", out arena);
            Assert.IsTrue(secondResult);
            Robot robot;
            result = command.IsValidCreateRobotCommand("1 2 N", out robot);
            Assert.IsTrue(result);
            var moves = command.RobotMoves("LMLMLMLMM");
            Assert.IsTrue(moves.Count > 0);
            var moreMoves = command.RobotMoves("LMLMLMLMM");
            Assert.IsTrue(moreMoves.Count > 0);



            RobotMoves provider = new RobotMoves();
            provider.MoveRobotToPosition(arena, robot, moves);

            Assert.AreEqual<int>(1, robot.PositionX);

            Assert.AreEqual<int>(3, robot.PositionY);

            Assert.AreEqual<RobotDirection>(RobotDirection.North, robot.Direction);
        }
    }
}
