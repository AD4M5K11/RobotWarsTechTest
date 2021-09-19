using RobotWars.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Build
{
    public class RobotMoves
    {
        public void MoveRobotToPosition(Arena arena, Robot robot, List<Move> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case Move.RotateLeft:
                    case Move.RotateRight:
                        Rotate(robot, move);
                        break;
                    case Move.MoveForward:
                        StartMoving(robot, arena);
                        break;
                    default:
                        break;
                }
            }
        }

        private void StartMoving(Robot robot, Arena arena)
        {
            switch (robot.Direction)
            {
                case RobotDirection.North:
                    if (robot.PositionY < arena.Height)
                        robot.PositionY++;
                    break;
                case RobotDirection.East:
                    if (robot.PositionX < arena.Width)
                        robot.PositionX++;
                    break;
                case RobotDirection.South:
                    if (robot.PositionY > 0)
                        robot.PositionY--;
                    break;
                case RobotDirection.West:
                    if (robot.PositionX > 0)
                        robot.PositionX--;
                    break;
            }
        }

        public void Rotate(Robot robot, Move move)
        {
            if (move == Move.RotateRight)
            {
                robot.Direction = robot.Direction == RobotDirection.West ? RobotDirection.North : (RobotDirection)(((int)robot.Direction) << 1);
            }
            else
            {
                robot.Direction = robot.Direction == RobotDirection.North ? RobotDirection.West : (RobotDirection)(((int)robot.Direction) >> 1);
            }
        }
    }
}
