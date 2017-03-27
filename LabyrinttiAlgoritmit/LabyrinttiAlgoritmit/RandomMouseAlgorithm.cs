using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{
    /// <summary>
    /// Algoritmi, jolla valitaan satunnaisesti suunta, mihinkä labyrintissä kuljetaan, kun risteys tulee vastaan. 
    /// Algoritmi jatkaa liikkumista arvottuun suuntaan, kunnes tulee risteys vastaan, jolloin arvotaan taas suunta uudestaan.
    /// </summary>
    class RandomMouseAlgorithm
    {
        public static bool solved;
        public static int startcolindex;
        public static int startrowindex;
        public static int currentcolindex;
        public static int currentrowindex;
        public static int prevcolindex;
        public static int prevrowindex;
        public static int[,] matrix;

        public RandomMouseAlgorithm(int[,] uusmatrix,int uusstartrow,int uusstartcol)
        {
            matrix = uusmatrix;
            startrowindex = uusstartrow;
            startcolindex = uusstartcol;
            currentcolindex = startcolindex;
            currentrowindex = startrowindex;
            prevcolindex = 0;
            prevrowindex = 0;
            solved = false;
            randomMouseAlgorithm2();
        }
        public static void randomMouseAlgorithm2()
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
                    choice = 2;
                    

                    // tsekataan risteys
                    if (matrix[currentrowindex,currentcolindex - 1] == 1 || matrix[currentrowindex,currentcolindex + 1] == 1)
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
                    choice = 1;
                    // tsekataan risteys
                    if (matrix[currentrowindex,currentcolindex - 1] == 1 || matrix[currentrowindex,currentcolindex + 1] == 1)
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

                    if (matrix[currentrowindex - 1,currentcolindex] == 0)
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
                    else
                    {
                        lookUp();
                        continue;
                    }
                }

                // Jos edellinen ruutu oli nykyisen vasemmalla, jatketaan oikealle
                if (currentcolindex > prevcolindex)
                {
                    choice = 4;
                    // tsekataan risteys
                    if (matrix[currentrowindex - 1,currentcolindex] == 1 || matrix[currentrowindex + 1,currentcolindex] == 1)
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
                    choice = 3;
                    // tsekataan risteys
                    if (matrix[currentrowindex - 1,currentcolindex] == 1 || matrix[currentrowindex + 1,currentcolindex] == 1)
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
            timer.Stop();
            Console.WriteLine("JEEEEEEEEE EXITTI LOYTYI PAIKASTA RIVI: " + currentrowindex + " SARAKE: " + currentcolindex);
            Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia", timer.Elapsed.TotalSeconds);
            // Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia", timer.Elapsed.TotalSeconds);
            // TAULUKON TULOSTUS
            /* var rowCount = matrix.GetLength(0);
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
            */
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
                    return false;
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
                    return false;
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
                    return false;
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
                    return false;
                }
                prevrowindex = currentrowindex;
                currentrowindex--;
                if (prevcolindex != currentcolindex) { prevcolindex = currentcolindex; }
                Console.WriteLine("Liikuttu ylos");
                return true;
            }
            return false;
        }


        /// <summary>
        /// Arvotaan luku, joka kertoo, mihinkä suuntaan seuraavaksi liikutaan.
        /// </summary>
        /// <param name="prev">Suunta, mistä risteykseen on tultu</param>
        /// <returns>
        /// Palautetaan suunta, mihinpäin mennään.
        /// Suunnat:
        /// ALAS = 1
        /// YLÖS = 2
        /// OIKEA = 3
        /// VASEN = 4
        /// </returns>
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

            if (luvut.Count == 1) { return luvut.ElementAt(0); }
            if (luvut.Contains(prev))
            {
                luvut.Remove(prev);
            }
            if (luvut.Count == 1) { return luvut.ElementAt(0); }
            Random rand = new Random();
            int random = rand.Next(1, 4);
            if (random == prev || luvut.Contains(random) == false)
            {
                while (random == prev || luvut.Contains(random) == false)
                {
                    random = rand.Next(1, 5);
                }
            }
            return random;
        }

    }
}
