using System;
using ToyRobotEDucker;

namespace RobotSim
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board();
                Game game = new Game(board);

                string val;
                Console.Write("Enter Command: ");
                val = Console.ReadLine();

                while (val.ToLower() != $"quit")
                {
                    if (val.Length != 0)
                    {
                        if (val.Length > 4 && val.ToLower().Substring(0, 5) == $"place")
                        {
                            //Console.WriteLine("Place command...");
                            string response = game.Place(val);
                            //Console.WriteLine(response);
                            val = Console.ReadLine();
                        }
                        else if (val.ToLower() == $"move")
                        {
                            //Console.WriteLine("moved");
                            string response = game.Move();
                            val = Console.ReadLine();
                        }
                        else if (val.ToLower() == $"left")
                        {
                            string response = game.Left();
                            //Console.WriteLine(response);
                            val = Console.ReadLine();
                        }
                        else if (val.ToLower() == $"right")
                        {
                            string response = game.Right();
                            //Console.WriteLine(response);
                            val = Console.ReadLine();
                        }
                        else if (val.ToLower() == $"report")
                        {
                            string response = game.Report();
                            Console.WriteLine(response);
                            val = Console.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
