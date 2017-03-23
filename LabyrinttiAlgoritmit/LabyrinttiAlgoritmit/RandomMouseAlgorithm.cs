using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    class RandomMouseAlgorithm
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

        public static void randomMouseAlgorithm()
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

            // ALAS = 1
            // YLÖS = 2
            // OIKEA = 3
            // VASEN = 4
            // silmukka pyärii
            while (!solved)
            {

                // Jos edellinen ruutu oli nykyisen yläpuolella, jatketaan alas
                if (currentrowindex > prevrowindex)
                {
                    choice = 1;
                    
                    if (lookDown() == true) {
                        continue;

                    }
                    else { 

                        choice = generateRandom(choice);
                        switch(choice)
                        {
                            case 1:
                                lookDown();
                                break;
                            case 2:
                                lookUp();
                                break;
                            case 3:
                                lookRight();
                                break;
                            case 4:
                                lookLeft();
                                break;
                        }
                        continue;
                    }
                }

                // Jos edellinen ruutu oli nykyisen alapuolella, jatketaan ylös
                if (currentrowindex < prevrowindex)
                {
                    choice = 2;

                    if (lookUp() == false)
                    {
                        choice = generateRandom(choice);
                        switch (choice)
                        {
                            case 1:
                                lookDown();
                                break;
                            case 2:
                                lookUp();
                                break;
                            case 3:
                                lookRight();
                                break;
                            case 4:
                                lookLeft();
                                break;
                        }
                        continue;
                    }
                    else { lookUp(); }
                }

                // Jos edellinen ruutu oli nykyisen vasemmalla, jatketaan oikealle
                if (currentcolindex > prevcolindex)
                {
                    choice = 3;
                    if (lookRight() == false)
                    {
                        choice = generateRandom(choice);
                        switch (choice)
                        {
                            case 1:
                                lookDown();
                                break;
                            case 2:
                                lookUp();
                                break;
                            case 3:
                                lookRight();
                                break;
                            case 4:
                                lookLeft();
                                break;
                        }
                        continue;
                    }
                    else { lookRight(); }
                }

                // Jos edellinen ruutu oli nykyisen oikealla, jatketaan vasemmalle
                if (currentcolindex < prevcolindex)
                {
                    choice = 4;
                    if (lookLeft() == false)
                    {
                        choice = generateRandom(choice);
                        switch (choice)
                        {
                            case 1:
                                lookDown();
                                break;
                            case 2:
                                lookUp();
                                break;
                            case 3:
                                lookRight();
                                break;
                            case 4:
                                lookLeft();
                                break;
                        }
                        continue;
                    }
                    else { lookLeft(); }
                }

            }
            Console.WriteLine("JEEEEEEEEE EXITTI LOYTYI PAIKASTA RIVI: " + currentrowindex + " SARAKE: " + currentcolindex);
            // Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia", timer.Elapsed.TotalSeconds);
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
                if (matrix[currentrowindex, currentcolindex - 1] == 3) { return false; }
                if (matrix[currentrowindex, currentcolindex - 1] == 4)
                {
                    solved = true;
                }
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
                if (matrix[currentrowindex + 1, currentcolindex] == 3) { return false; }
                if (matrix[currentrowindex + 1, currentcolindex] == 4)
                {
                    solved = true;
                }
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
                if (matrix[currentrowindex, currentcolindex + 1] == 3) { return false; }
                if (matrix[currentrowindex, currentcolindex + 1] == 4)
                {
                    solved = true;
                }
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
                if (matrix[currentrowindex - 1, currentcolindex] == 3) { return false; }
                if (matrix[currentrowindex - 1, currentcolindex] == 4)
                {
                    solved = true;
                }
                prevrowindex = currentrowindex;
                currentrowindex--;
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
                Console.WriteLine("Liikuttu ylos");
                return true;
            }
            return false;
        }
        // ALAS = 1
        // YLÖS = 2
        // OIKEA = 3
        // VASEN = 4
        public static int generateRandom(int prev)
        {
            List<int> luvut = new List<int>();
            // jos alhaalle pääsee, random lukuihin lisätään 1
            if (matrix[currentrowindex + 1, currentcolindex] == 1) { luvut.Add(1); }
            // jos ylös pääsee, random lukuihin lisätään 2
            if (matrix[currentrowindex - 1, currentcolindex] == 1) { luvut.Add(2); }
            // jos oikealle pääsee , random lukuihin lisätään 3
            if (matrix[currentrowindex, currentcolindex + 1] == 1) { luvut.Add(3); }
            // jos vasemmalle pääsee, random lukuihin lisätään 4
            if (matrix[currentrowindex, currentcolindex - 1] == 1) { luvut.Add(4); }
            // jos pääsee vain takasinpäin, mennään sinne
            if (luvut.Count == 1) { return luvut.ElementAt(1); }
            Random rand = new Random();
            int random = rand.Next(1, 4);
            if (random == prev)
            {
                while (random == prev)
                {
                    random = rand.Next(1, 4);
                }
            }
            return random;
        }

    }
}
