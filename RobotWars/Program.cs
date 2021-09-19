using RobotWars.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands command = new Commands();

            Console.WriteLine("Enter coordinates of the Arena");
            string arenaCommands = Console.ReadLine();
            Arena arena = null;
            if(!command.IsValidArenaCommand(arenaCommands, out arena))
            {
                Console.WriteLine("Invalid command");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.WriteLine("Enter position for robot");
                string commands = Console.ReadLine();
                Robot robot = null;

                if(!command.IsValidCreateRobotCommand(commands, out robot))
                {
                    Console.WriteLine("Invalid command");
                    Console.ReadKey();
                    return;
                }
                if (robot.PositionX > arena.Width || robot.PositionY > arena.Height)
                {
                    Console.WriteLine("Invalid coordinates");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Enter robot moves");
                commands = Console.ReadLine();
                var moves = command.RobotMoves(commands);

                var movesProvider = new RobotMoves();
                movesProvider.MoveRobotToPosition(arena, robot, moves);

                Console.WriteLine("{0} {1} {2}", robot.PositionX, robot.PositionY, robot.Direction);
            }
        }
    }
}
