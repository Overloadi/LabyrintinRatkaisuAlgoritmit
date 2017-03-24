using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    /// <summary>
    /// Algoritmi, jolla seurataan aina labyrintin oikeaa seinää, jos mahdollista.
    /// Kuljettu reitti merkataan matriisiin kakkosella, jotta algoritmi pääsee pois umpikujasta.
    /// </summary>
    class WallFollowerAlgorithm
    {
        public static bool solved = false;
        public static int startcolindex = 3;
        public static int startrowindex = 0;
        public static int currentcolindex = startcolindex;
        public static int currentrowindex = startrowindex;
        public static int prevcolindex = 0;
        public static int prevrowindex = 0;
        public static int[,] matrix = new int[10, 10] {
                                            {0, 0, 0, 3, 0, 0, 0, 0, 0, 0 },
                                            {0, 1, 0, 1, 0, 0, 0, 1, 1, 0 },
                                            {0, 1, 0, 1, 1, 1, 1, 1, 0, 0 },
                                            {0, 1, 0, 1, 0, 1, 0, 1, 0, 0 },
                                            {0, 1, 1, 1, 1, 1, 0, 1, 1, 4 },
                                            {0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
                                            {0, 1, 1, 1, 0, 1, 0, 1, 1, 0 },
                                            {0, 1, 0, 1, 0, 1, 0, 0, 1, 0 },
                                            {0, 1, 0, 1, 0, 1, 1, 1, 1, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },};
        public static void wallFollower()
        {
            int choice = 0;

            // TAULUKON TULOSTUS
            var rowCount1 = matrix.GetLength(0);
            var colCount1 = matrix.GetLength(1);
            for (int row1 = 0; row1 < rowCount1; row1++)
            {
                for (int col1 = 0; col1 < colCount1; col1++)
                    if (matrix[row1, col1] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0} ", matrix[row1, col1]));
                    }
                    else if (matrix[row1, col1] == 3 || matrix[row1, col1] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(String.Format("{0} ", matrix[row1, col1]));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(String.Format("{0} ", matrix[row1, col1]));
                    }

                Console.WriteLine();

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Stopwatch timer = new Stopwatch();
            timer.Start();
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
            else if (currentrowindex == 9)
            {
                currentrowindex--;
                prevrowindex = 9;
                prevcolindex = currentcolindex;
                Console.WriteLine("Liikuttu ylös");
            }

            // Jos alkupiste on oikella
            else if (currentcolindex == 9)
            {
                currentcolindex--;
                prevcolindex = 9;
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

                // Jos edellinen ruutu oli nykyisen yläpuolella ja ympärillä vain 0 tai 2
                if (currentrowindex > prevrowindex && (matrix[currentrowindex, currentcolindex - 1] == 0 || matrix[currentrowindex, currentcolindex - 1] == 2) && (matrix[currentrowindex + 1, currentcolindex] == 0 || matrix[currentrowindex + 1, currentcolindex] == 2) && (matrix[currentrowindex, currentcolindex + 1] == 0 || matrix[currentrowindex, currentcolindex + 1] == 2) && (matrix[currentrowindex - 1, currentcolindex] == 0 || matrix[currentrowindex - 1, currentcolindex] == 2))
                {
                    choice = 5;
                }

                // Jos edellinen ruutu oli nykyisen alapuolella ja ympärillä vain 0 tai 2
                if (currentrowindex < prevrowindex && (matrix[currentrowindex, currentcolindex - 1] == 0 || matrix[currentrowindex, currentcolindex - 1] == 2) && (matrix[currentrowindex + 1, currentcolindex] == 0 || matrix[currentrowindex + 1, currentcolindex] == 2) && (matrix[currentrowindex, currentcolindex + 1] == 0 || matrix[currentrowindex, currentcolindex + 1] == 2) && (matrix[currentrowindex - 1, currentcolindex] == 0 || matrix[currentrowindex - 1, currentcolindex] == 2))
                {
                    choice = 6;
                }

                // Jos edellinen ruutu oli nykyisen vasemmalla ja ympärillä vain 0 tai 2
                if (currentcolindex > prevcolindex && (matrix[currentrowindex, currentcolindex - 1] == 0 || matrix[currentrowindex, currentcolindex - 1] == 2) && (matrix[currentrowindex + 1, currentcolindex] == 0 || matrix[currentrowindex + 1, currentcolindex] == 2) && (matrix[currentrowindex, currentcolindex + 1] == 0 || matrix[currentrowindex, currentcolindex + 1] == 2) && (matrix[currentrowindex - 1, currentcolindex] == 0 || matrix[currentrowindex - 1, currentcolindex] == 2))
                {
                    choice = 7;
                }

                // Jos edellinen ruutu oli nykyisen oikealla ja ympärillä vain 0 tai 2
                if (currentcolindex < prevcolindex && (matrix[currentrowindex, currentcolindex - 1] == 0 || matrix[currentrowindex, currentcolindex - 1] == 2) && (matrix[currentrowindex + 1, currentcolindex] == 0 || matrix[currentrowindex + 1, currentcolindex] == 2) && (matrix[currentrowindex, currentcolindex + 1] == 0 || matrix[currentrowindex, currentcolindex + 1] == 2) && (matrix[currentrowindex - 1, currentcolindex] == 0 || matrix[currentrowindex - 1, currentcolindex] == 2))
                {
                    choice = 8;
                }

                switch (choice)
                {
                    // Jos edellinen ruutu oli nykyisen yläpuolella
                    case 1:
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        if (lookUp() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen alapuolella
                    case 2:
                        if (lookRight() == true) { break; }
                        if (lookUp() == true) { break; }
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen vasemmalla
                    case 3:
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        if (lookUp() == true) { break; }
                        if (lookLeft() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen oikealla
                    case 4:
                        if (lookUp() == true) { break; }
                        if (lookLeft() == true) { break; }
                        if (lookDown() == true) { break; }
                        if (lookRight() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen yläpuolella ja ympärillä vain 0 tai 2
                    case 5:
                        if (lookLeft4() == true) { break; }
                        if (lookDown4() == true) { break; }
                        if (lookRight4() == true) { break; }
                        if (lookUp4() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen alapuolella ja ympärillä vain 0 tai 2
                    case 6:
                        if (lookRight4() == true) { break; }
                        if (lookUp4() == true) { break; }
                        if (lookLeft4() == true) { break; }
                        if (lookDown4() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen vasemmalla ja ympärillä vain 0 tai 2
                    case 7:
                        if (lookDown4() == true) { break; }
                        if (lookRight4() == true) { break; }
                        if (lookUp4() == true) { break; }
                        if (lookLeft4() == true) { break; }
                        break;

                    // Jos edellinen ruutu oli nykyisen oikealla ja ympärillä vain 0 tai 2
                    case 8:
                        if (lookUp4() == true) { break; }
                        if (lookLeft4() == true) { break; }
                        if (lookDown4() == true) { break; }
                        if (lookRight4() == true) { break; }
                        break;

                } // Switch case loppu

            } // While loppu

            timer.Stop();
            Console.WriteLine("JEEEEEEEEE EXITTI LOYTYI PAIKASTA RIVI: " + currentrowindex + " SARAKE: " + currentcolindex);
            Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia", timer.Elapsed.TotalSeconds);
            // TAULUKON TULOSTUS
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    if (matrix[row, col] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0} ", matrix[row, col]));
                    }
                    else if (matrix[row, col] == 3 || matrix[row, col] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(String.Format("{0} ", matrix[row, col]));
                    }
                    else if (matrix[row, col] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0} ", matrix[row, col]));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(String.Format("{0} ", matrix[row, col]));
                    }

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
                if (prevrowindex != currentrowindex) { prevrowindex = currentrowindex; }
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
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
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
                if (prevrowindex != currentrowindex) { prevrowindex = currentrowindex; }
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
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
                Console.WriteLine("Liikuttu ylos");
                return true;
            }
            return false;
        }



        // Jos umpikuja yllättää siirrytään lukemaan kakkosia
        // Katsotaan vasemmalle
        public static bool lookLeft4()
        {
            if (matrix[currentrowindex, currentcolindex - 1] == 2)
            {
                if (matrix[currentrowindex, currentcolindex - 1] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex--;
                if (prevrowindex != currentrowindex) { prevrowindex = currentrowindex; }
                Console.WriteLine("Liikuttu vasemmalle");
                return true;
            }
            return false;
        }

        // Katsotaan alas
        public static bool lookDown4()
        {
            if (matrix[currentrowindex + 1, currentcolindex] == 2)
            {
                if (matrix[currentrowindex + 1, currentcolindex] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex++;
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
                Console.WriteLine("Liikuttu alas");
                return true;
            }
            return false;
        }

        // Katsotaan oikealle
        public static bool lookRight4()
        {
            if (matrix[currentrowindex, currentcolindex + 1] == 2)
            {
                if (matrix[currentrowindex, currentcolindex + 1] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevcolindex = currentcolindex;
                currentcolindex++;
                if (prevrowindex != currentrowindex) { prevrowindex = currentrowindex; }
                Console.WriteLine("Liikuttu oikealle");
                return true;
            }
            return false;
        }

        // Katsotaan ylös
        public static bool lookUp4()
        {
            if (matrix[currentrowindex - 1, currentcolindex] == 2)
            {
                if (matrix[currentrowindex - 1, currentcolindex] == 4)
                {
                    solved = true;
                }
                matrix[currentrowindex, currentcolindex] = 2;
                prevrowindex = currentrowindex;
                currentrowindex--;
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
                Console.WriteLine("Liikuttu ylos");
                return true;
            }
            return false;
        }
    }
}
