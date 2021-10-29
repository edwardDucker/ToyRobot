using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEDucker
{
    public static class Services
    {
        /// <summary>
        /// Cleans up direction in case of north to west movements generating a direction out of bounds
        /// </summary>
        /// <param name="dir">Robot's direction in degrees</param>
        /// <returns>Direction in the 0-360 range</returns>
        public static int SetDirection(int dir)
        {
            if (dir < 0)
            {
                dir += 360;
            }
            if (dir >= 360)
            {
                dir -= 360;
            }

            return dir;
        }

        /// <summary>
        /// Calculates the new position of a robot after a move
        /// </summary>
        /// <param name="robot">The robot's pre-move position</param>
        /// <returns>Robot in the new position</returns>
        public static Robot MoveCalculator(Robot robot)
        {
            //calculate the move (1 space)
            switch (robot.Direction)
            {
                case (int)DirectionEnum.NORTH:
                    {
                        robot.YPos += 1;
                        break;
                    }
                case (int)DirectionEnum.SOUTH:
                    {
                        robot.YPos -= 1;
                        break;
                    }
                case (int)DirectionEnum.EAST:
                    {
                        robot.XPos += 1;
                        break;
                    }
                case (int)DirectionEnum.WEST:
                    {
                        robot.XPos -= 1;
                        break;
                    }

                default:

                    break;
                    // do nothing
                    // TODO: perhaps report error based on invalid direction.
            }

            return robot;
        }
    }
}
