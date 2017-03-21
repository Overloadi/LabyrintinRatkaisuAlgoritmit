using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{


    class Program
    {
        public static bool solved = false;
        public static int startcolindex = 2;
        public static int startrowindex = 0;
        public static int currentcolindex = startcolindex;
        public static int currentrowindex = startrowindex;
        public static int prevcolindex = 0;
        public static int prevrowindex = 0;
        public static int[,] matrix = new int[6, 6] { 
                                            {0, 0, 3, 0, 0, 0 },
                                            {0, 0, 1, 1, 0, 0 },
                                            {0, 0, 1, 0, 1, 4 },
                                            {0, 0, 1, 0, 1, 0 },
                                            {0, 0, 1, 1, 1, 0 },
                                            {0, 0, 0, 0, 0, 0 } };
        public static void wallFollower()
        {
            int choice = 0;
            if (currentrowindex == 0)
            {
                currentrowindex++;
                prevrowindex = 0;
                prevcolindex = currentcolindex;
            }
            else if (currentcolindex == 0)
            {
                currentcolindex++;
                prevcolindex = 0;
                prevrowindex = currentrowindex;
            }
            else if (currentrowindex == 5)
            {
                currentrowindex--;
                prevrowindex = 5;
                prevcolindex = currentcolindex;
            }
            else if (currentcolindex == 5)
            {
                currentcolindex--;
                prevcolindex = 5;
                prevrowindex = currentrowindex;
            }
            while (!solved)
            {
                if (currentrowindex > prevrowindex)
                {
                    choice = 1;
                }
                if (currentrowindex < prevrowindex)
                {
                    choice = 2;
                }
                switch (choice)
                    {
                    case 1:
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        lookUp();
                        break;
                    case 2:

                        break;
                    
                    }
                
                // Katsotaan vasemmalle
                lookLeft();


                // Katsotaan alas
                lookDown();

                // Katsotaan oikealle
                lookRight();


                // Katsotaan ylös
                lookUp();


                // Jos ei löydy ympäriltä ykkösiä, mennään kakkosia takasipäin. 

                //}
                Console.WriteLine("Silmukka lapi");
            }

        }

        // Katsotaan vasemmalle
        public static bool lookLeft()
        {
            if (matrix[currentrowindex, currentcolindex - 1] == 1 || matrix[currentrowindex, currentcolindex - 1] == 4)
            {
                if (matrix[currentrowindex, currentcolindex - 1] == 4)
                {
                    solved = true;
                    Console.WriteLine("JEEEEEEEEEEE ULOSPAASY LOYTYI");
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex--;
                return true;
            }
            return false;
        }

        public static bool lookDown()
        {
             if (matrix[currentrowindex + 1, currentcolindex] == 1 || matrix[currentrowindex + 1, currentcolindex] == 4)
            {
                if (matrix[currentrowindex + 1, currentcolindex] == 4)
                {
                    solved = true;
                    Console.WriteLine("JEEEEEEEEEEE ULOSPAASY LOYTYI");
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex++;
                return true;
            }
            return false;
        }

        public static bool lookRight()
        {
            if (matrix[currentrowindex, currentcolindex + 1] == 1 || matrix[currentrowindex, currentcolindex + 1] == 4)
            {
                if (matrix[currentrowindex, currentcolindex + 1] == 4)
                {
                    solved = true;
                    Console.WriteLine("JEEEEEEEEEEE ULOSPAASY LOYTYI");
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex++;
                return true;
            }
            return false;
        }

        public static bool lookUp()
        {
            if (matrix[currentrowindex - 1, currentcolindex] == 1 || matrix[currentrowindex - 1, currentcolindex] == 4)
            {
                if (matrix[currentrowindex - 1, currentcolindex] == 4)
                {
                    solved = true;
                    Console.WriteLine("JEEEEEEEEEEE ULOSPAASY LOYTYI");
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex--;
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            wallFollower();
            // Maze maze = new Maze(matrix);

        }
    }
}
