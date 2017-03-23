using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinttiAlgoritmit
{


    class Program
    {


            static void Main(string[] args)
        {
            // Stopwatch timer = new Stopwatch();
            // timer.Start();
            // WallFollowerAlgorithm.wallFollower();
            // timer.Stop();
            // Console.WriteLine("Aikaa labyritmin ratkaisemiseen meni: {0} sekuntia",timer.Elapsed.TotalSeconds);
            RandomMouseAlgorithm.randomMouseAlgorithm();
        }
    }
}
