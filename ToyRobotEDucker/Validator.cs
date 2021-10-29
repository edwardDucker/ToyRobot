using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEDucker
{
    internal class Validator
    {
        /// <summary>
        /// Checks that the position given is within bounds of the board
        /// </summary>
        /// <param name="XPos">Position on the X axis</param>
        /// <param name="YPos">Position on the Y axis</param>
        /// <param name="XSize">Size of the game board on the X axis</param>
        /// <param name="YSize">Size of the game board on the Y axis</param>
        /// <returns>Boolean to confirm valid position</returns>
        internal bool ValidatePosition(int XPos, int YPos, int XSize, int YSize)
        {
            bool valid = ((XPos > -1 && XPos <= XSize) && (YPos > -1 && YPos <= YSize));

            return valid;

        }
        /// <summary>
        /// Checks that the position given is within bounds of the board
        /// </summary>
        /// <param name="calculatedMovedRobot">Position of the robot after the move</param>
        /// <param name="board">Current game board</param>
        /// <returns>Boolean to confirm valid position</returns>
        internal bool ValidateMovedPosition(Robot calculatedMovedRobot, Board board)
        {
            bool valid = ValidatePosition(calculatedMovedRobot.XPos, calculatedMovedRobot.YPos, board.XSize, board.YSize);

            return valid;
        }
    }
}
