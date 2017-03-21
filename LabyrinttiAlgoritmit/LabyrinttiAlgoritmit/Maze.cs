using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class Maze
    {
        public List<Box> boxes;
        public int rowCount;
        public int columnCount;
        public Box startBox;
        public Box endBox;


        public Maze(int[,] matrix)
        {
            bool passable;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[col, row] == 1)
                    {
                        passable = true;
                    }
                    else
                    {
                        passable = false;
                    }
                    Box box = new Box(passable, row, col);
                    boxes.Add(box);
                }
            }
        }
    }
}
