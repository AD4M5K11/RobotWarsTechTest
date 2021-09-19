using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Tests
{
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void IsValidArenaCommandTest()
        {
            Commands command = new Commands();
            Arena arena;
            bool result = command.IsValidArenaCommand("5 5", out arena);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidCreateRobotCommandTest()
        {
            Commands command = new Commands();
            Robot robot;
            bool result = command.IsValidCreateRobotCommand("1 2 N", out robot);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckRobotMoves()
        {
            Commands command = new Commands();
            var result = command.RobotMoves("LMLMLMLMM");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void IsValidCreateRobotCommandEastTest()
        {
            Commands command = new Commands();
            Robot robot;
            bool result = command.IsValidCreateRobotCommand("3 3 E", out robot);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckRobotMovesDifferentPattern()
        {
            Commands command = new Commands();
            var result = command.RobotMoves("MMRMMRMRRM");
            Assert.IsTrue(result.Count > 0);
        }
    }
}
