using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class RecursiveAlgorithm
    {
        public static int[,] maze = new int[10, 10] {
                                            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                                            {0, 1, 0, 1, 0, 0, 0, 1, 1, 0 },
                                            {0, 1, 0, 1, 1, 1, 1, 1, 0, 0 },
                                            {0, 1, 0, 1, 0, 1, 0, 1, 0, 0 },
                                            {0, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                                            {0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                                            {0, 1, 1, 1, 0, 1, 0, 1, 1, 0 },
                                            {0, 1, 0, 1, 0, 1, 0, 0, 1, 0 },
                                            {0, 1, 0, 1, 0, 1, 1, 1, 1, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },};// The maze
        public static bool[,] wasHere = new bool[10, 10];
        public static bool[,] correctPath = new bool[10,10]; // The solution to the maze
        public static int startX = 0;
        public static int startY = 3; // Starting X and Y values of maze
        public static int endX = 4;
        public static int endY = 9;     // Ending X and Y values of maze
        public static int height = 10;
        public static int width = 10;

        public static void solveMaze()
        {
            // Create Maze (1 = path, 2 = wall)
            for (int row = 0; row < maze.GetLength(1); row++)
                // Sets boolean Arrays to default values
                for (int col = 0; col < maze.GetLength(0); col++)
                {
                    wasHere[row,col] = false;
                    correctPath[row,col] = false;
                }
            bool b = recursiveSolve(startX, startY);
            Console.WriteLine(b);
            // Tulostus
            var rowCount = maze.GetLength(0);
            var colCount = maze.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    if (wasHere[row, col] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0} ", maze[row, col]));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(String.Format("{0} ", maze[row, col]));
                    }

                Console.WriteLine();
            }
            // Will leave you with a boolean array (correctPath) 
            // with the path indicated by true values.
            // If b is false, there is no solution to the maze
        }
        public static bool recursiveSolve(int x, int y)
        {
            if (x == endX && y == endY) return true; // If you reached the end
            if (maze[x,y] == 2 || wasHere[x,y]) return false;
            // If you are on a wall or already were here
            wasHere[x,y] = true;
            if (x != 0) // Checks if not on left edge
                if (recursiveSolve(x - 1, y))
                { // Recalls method one to the left
                    correctPath[x,y] = true; // Sets that path value to true;
                    return true;
                }
            if (x != width - 1) // Checks if not on right edge
                if (recursiveSolve(x + 1, y))
                { // Recalls method one to the right
                    correctPath[x,y] = true;
                    return true;
                }
            if (y != 0)  // Checks if not on top edge
                if (recursiveSolve(x, y - 1))
                { // Recalls method one up
                    correctPath[x,y] = true;
                    return true;
                }
            if (y != height - 1) // Checks if not on bottom edge
                if (recursiveSolve(x, y + 1))
                { // Recalls method one down
                    correctPath[x,y] = true;
                    return true;
                }
            return false;
        }
    }
}
