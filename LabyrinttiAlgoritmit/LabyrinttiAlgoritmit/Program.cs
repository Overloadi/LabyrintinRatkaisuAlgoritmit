using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[4, 4] { { 1, 0, 0, 0 },
                                            {1, 1, 0, 1},
                                            {0, 1, 0, 0},
                                            {1, 1, 1, 1}
            };
            Maze maze = new Maze(matrix);
        }
    }
}
