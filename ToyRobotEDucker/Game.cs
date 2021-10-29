using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ToyRobotEDucker
{
    public class Game
    {
        bool placed = false;
        readonly Board board;
        Robot robot;


        public Game(Board board)
        {
            this.board = board;
        }

        /// <summary>
        /// A valid command will place the robot on the board. This is used to begin the game.
        /// </summary>
        /// <param name="val">Command String</param>
        /// <returns></returns>
        public string Place(string val)
        {
            Regex initRegex = new Regex("PLACE [0-9]+,[0-9]+,NORTH|SOUTH|EAST|WEST", RegexOptions.IgnoreCase);

            Regex moveRegex = new Regex("PLACE [0-9]+,[0-9]+", RegexOptions.IgnoreCase);
            var match = initRegex.IsMatch(val);

            if (match)
            {
                //initializing place
                // get the co-ords
                int XPos = Convert.ToInt32(val.Substring(6, 1));
                int YPos = Convert.ToInt32(val.Substring(8, 1));
                string DirectionText = val.Substring(10);
                int Direction = (int)Enum.Parse(typeof(DirectionEnum), DirectionText.ToUpper());


                // validate
                Validator validator = new Validator();
                bool isValidMove = validator.ValidatePosition(XPos, YPos, board.XSize, board.YSize);



                if (isValidMove)
                {
                    Direction = Services.SetDirection(Direction);
                    if (!placed)
                    {
                        this.robot = new Robot(XPos, YPos, Direction);
                    }
                    else
                    {
                        robot.XPos = XPos;
                        robot.YPos = YPos;
                        robot.Direction = Direction;
                    }

                    placed = true;

                }

            }
            else if (moveRegex.IsMatch(val))
            {
                // move somewhere on the board
                // get the co-ords
                int XPos = Convert.ToInt32(val.Substring(6, 1));
                int YPos = Convert.ToInt32(val.Substring(8, 1));
                // calulate new position

                // validate
                Validator validator = new Validator();
                bool isValidMove = validator.ValidatePosition(XPos, YPos, board.XSize, board.YSize);

                // copy to robot if valid
                if (isValidMove)
                {

                    if (placed)
                    {
                        robot.XPos = XPos;
                        robot.YPos = YPos;
                    }
                }
            }


            // handle both sets of place commands

            return "Matched";
        }

        /// <summary>
        /// Moves the robot forward one space in it's current direction
        /// </summary>
        /// <returns></returns>
        public string Move()
        {
            if (placed)
            {
                Validator validator = new Validator();
                Robot robotClone = new Robot(robot.XPos, robot.YPos, robot.Direction);
                var calculatedMovedRobot = Services.MoveCalculator(robotClone);
                bool vaildMove = validator.ValidateMovedPosition(calculatedMovedRobot, board);

                if (vaildMove)
                {
                    robot = calculatedMovedRobot;
                    return "moved";
                }
            }
            return "Did Nothing";
        }

        /// <summary>
        /// Turns the robot to the left
        /// </summary>
        /// <returns></returns>
        public string Left()
        {
            if (placed)
            {
                robot.Left();
                robot.Direction = Services.SetDirection(robot.Direction);
                return "Moved";
            }
            else
            { return "Did Nothing"; }
        }

        /// <summary>
        /// Turns the robot to the right
        /// </summary>
        /// <returns></returns>
        public string Right()
        {
            if (placed)
            {
                robot.Right();
                robot.Direction = Services.SetDirection(robot.Direction);
                return "Moved";
            }
            else
            { return "Did Nothing"; }
        }

        /// <summary>
        /// Announces the X and Y positions, and direction of the robot
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (placed)
            {
                return $"{robot.XPos},{robot.YPos},{(DirectionEnum)robot.Direction}";
            }
            else
            {
                return "No Position to Report";
            }
        }
    }
}
