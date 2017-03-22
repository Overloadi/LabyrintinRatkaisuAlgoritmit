﻿using System;
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
                                            {0, 0, 1, 0, 0, 0 },
                                            {0, 1, 1, 1, 1, 0 },
                                            {0, 1, 0, 0, 1, 0 },
                                            {0, 1, 1, 1, 1, 0 },
                                            {0, 0, 0, 0, 4, 0 } };
        public static void wallFollower()
        {
            int choice = 0;

            // TAULUKON TULOSTUS
            var rowCount1 = matrix.GetLength(0);
            var colCount1 = matrix.GetLength(1);
            for (int row1 = 0; row1 < rowCount1; row1++)
            {
                for (int col1 = 0; col1 < colCount1; col1++)
                    Console.Write(String.Format("{0}\t", matrix[row1, col1]));
                Console.WriteLine();
            }

            // Jos alkupiste on ylhäällä
            if (currentrowindex == 0)
            {
                currentrowindex++;
                prevrowindex = 0;
                prevcolindex = currentcolindex;
                Console.WriteLine("Liikuttu alas");
            }

            // Jos alkupiste on vasemmalla
            else if (currentcolindex == 0)
            {
                currentcolindex++;
                prevcolindex = 0;
                prevrowindex = currentrowindex;
                Console.WriteLine("Liikuttu oikealle");
            }

            // Jos alkupiste on alhaalla
            else if (currentrowindex == 5)
            {
                currentrowindex--;
                prevrowindex = 5;
                prevcolindex = currentcolindex;
                Console.WriteLine("Liikuttu ylös");
            }

            // Jos alkupiste on oikella
            else if (currentcolindex == 5)
            {
                currentcolindex--;
                prevcolindex = 5;
                prevrowindex = currentrowindex;
                Console.WriteLine("Liikuttu vasemmalle");
            }



            while (!solved)
            {
                // Jos edellinen ruutu oli nykyisen yläpuolella
                if (currentrowindex > prevrowindex)
                {
                    choice = 1;
                }

                // Jos edellinen ruutu oli nykyisen alapuolella
                if (currentrowindex < prevrowindex)
                {
                    choice = 2;
                }
            
                // Jos edellinen ruutu oli nykyisen vasemmalla
                if (currentcolindex > prevcolindex)
                {
                    choice = 3;
                }

                // Jos edellinen ruutu oli nykyisen oikealla
                if (currentcolindex < prevcolindex)
                {
                    choice = 4;
                }

                switch (choice)
                    {
                    // Jos edellinen ruutu oli nykyisen yläpuolella
                    case 1:
                        lookLeft();
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        if (lookUp() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen alapuolella
                    case 2:
                        lookRight();
                        if (lookUp() == true) { break; }
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        
                        break;

                    // Jos edellinen ruutu oli nykyisen vasemmalla
                    case 3:
                        lookDown();
                        if (lookRight() == true) { break; }
                        if (lookUp() == true) { break; }
                        if (lookLeft() == true) { break; }
                        
                        break;

                    // Jos edellinen ruutu oli nykyisen oikealla
                    case 4:
                        lookUp();
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        
                        break;
                    
                    } // Switch case loppu

            
                


                // Jos ei löydy ympäriltä ykkösiä, mennään kakkosia takasipäin. 

                
                
            } // While loppu


            Console.WriteLine("Jee exitti löyty");
            // TAULUKON TULOSTUS
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    Console.Write(String.Format("{0}\t", matrix[row, col]));
                Console.WriteLine();
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
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex--;
                Console.WriteLine("Liikuttu vasemmalle");
                return true;
            }
            return false;
        }

        // Katsotaan alas 
        public static bool lookDown()
        {
             if (matrix[currentrowindex + 1, currentcolindex] == 1 || matrix[currentrowindex + 1, currentcolindex] == 4)
            {
                if (matrix[currentrowindex + 1, currentcolindex] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex++;
                Console.WriteLine("Liikuttu alas");
                return true;
            }
            return false;
        }

        // Katsotaan oikealle
        public static bool lookRight()
        {
            if (matrix[currentrowindex, currentcolindex + 1] == 1 || matrix[currentrowindex, currentcolindex + 1] == 4)
            {
                if (matrix[currentrowindex, currentcolindex + 1] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex++;
                Console.WriteLine("Liikuttu oikealle");
                return true;
            }
            return false;
        }

        // Katsotaan ylös
        public static bool lookUp()
        {
            if (matrix[currentrowindex - 1, currentcolindex] == 1 || matrix[currentrowindex - 1, currentcolindex] == 4)
            {
                if (matrix[currentrowindex - 1, currentcolindex] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex--;
                Console.WriteLine("Liikuttu ylos");
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
