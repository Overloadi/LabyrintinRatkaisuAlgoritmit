using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class RecursiveAlgorithm
    {
        public static int[,] maze;
        public static int startX;
        public static int startY; // Starting X and Y values of maze
        public static int endX;
        public static int endY;     // Ending X and Y values of maze
        public static int height;
        public static int width;
        public static bool[,] wasHere;
        public static bool[,] correctPath; // The solution to the maze

        public RecursiveAlgorithm(int[,]newmaze, int newstartx, int newstarty,int newendx,int newendy)
        {
            maze = newmaze;
            height = maze.GetLength(0);
            width = maze.GetLength(1);
            wasHere = new bool[height, width];
            correctPath = new bool[height, width]; // The solution to the maze
            startX = newstartx;
            startY = newstarty;
            endX = newendx;
            endY = newendy;
            solveMaze();
        }
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
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool b = recursiveSolve(startX, startY);
            timer.Stop();
            Console.WriteLine(b);
            Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia", timer.Elapsed.TotalSeconds);
            // Tulostus
            var rowCount = maze.GetLength(0);
            var colCount = maze.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    if (correctPath[row, col] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0} ", 1));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(String.Format("{0} ", 0));
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
            if (maze[x,y] == 0 || wasHere[x,y]) return false;
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
