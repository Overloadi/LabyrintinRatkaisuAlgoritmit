using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class Box
    {
        bool passable;
        int rowCoordinate;
        int columnCoordinate;

        public Box(bool passable, int rowCoord, int columnCoord)
        {
            this.passable = passable;
            this.rowCoordinate = rowCoord;
            this.columnCoordinate = columnCoord;

        }
    }
}
