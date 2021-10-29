using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEDucker
{
    public class Robot
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Direction { get; set; }

        public Robot(int xPos, int yPos, int direction)
        {
            XPos = xPos;
            YPos = yPos;
            Direction = direction;
        }

        /// <summary>
        /// Decrements Direction by 90
        /// </summary>
        public void Left()
        {
            this.Direction -= 90;
        }

        /// <summary>
        /// Increments direction by 90
        /// </summary>
        public void Right()
        {
            this.Direction += 90;
        }
        /// <summary>
        /// Announces the current position and direction of the robot
        /// </summary>
        /// <returns>Concatenated string with the current coordinates and direction of the robot</returns>
        public string Report()
        {
            var robotReport = $"{XPos},{YPos},{Direction}";

            return robotReport;
        }
    }

}
