using RobotWars.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Build
{
    public class Commands
    {
        const char ROTATE_LEFT = 'L';
        const char ROTATE_RIGHT = 'R';
        const char MOVE_FORWARD = 'M';
              
        const string NORTH = "N";
        const string SOUTH = "S";
        const string EAST = "E";
        const string WEST = "W";

        public bool IsValidArenaCommand(string commands, out Arena arena)
        {
            var command = commands.Split(' ');

            arena = new Arena();
            int coordinate;
            if (int.TryParse(command[0], out coordinate))
                arena.Width = coordinate;
            else
                return false;

            if (int.TryParse(command[1], out coordinate))
                arena.Height = coordinate;
            else
                return false;

            return true;
        }

        public bool IsValidCreateRobotCommand(string commands, out Robot robot)
        {
            var command = commands.Split(' ');
            
            robot = new Robot();

            int coordinate;
            if (int.TryParse(command[0], out coordinate)) // out call used as 
                robot.PositionX = coordinate;
            else
                return false;

            if (int.TryParse(command[1], out coordinate))
                robot.PositionY = coordinate;
            else
                return false;

            RobotDirection direction;
            if (!TryGetRobotDirection(command[2], out direction))
                return false;

            robot.Direction = direction;
            return true;
        }

        public List<Move> RobotMoves(string commands)
        {
            List<Move> moves = new List<Move>();
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ROTATE_LEFT:
                        moves.Add(Move.RotateLeft);
                        break;
                    case ROTATE_RIGHT:
                        moves.Add(Move.RotateRight);
                        break;
                    case MOVE_FORWARD:
                        moves.Add(Move.MoveForward);
                        break;
                    default:
                        break;
                }
            }
            return moves;
        }

        private bool TryGetRobotDirection(string command, out RobotDirection position)
        {
            switch (command.ToUpper())
            {
                case NORTH:
                    position = RobotDirection.North;
                    return true;
                case SOUTH:
                    position = RobotDirection.South;
                    return true;
                case WEST:
                    position = RobotDirection.West;
                    return true;
                case EAST:
                    position = RobotDirection.East;
                    return true;
                default:
                    position = RobotDirection.North;
                    return false;
            }
        }

    }
}
