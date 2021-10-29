using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEDucker
{
    public class Board
    {
        public int XSize { get; set; }
        public int YSize { get; set; }

        /// <summary>
        /// Default Constuctor for the default board size
        /// </summary>
        public Board()
        {
            this.XSize = 5;
            this.YSize = 5;
        }
    }
}
