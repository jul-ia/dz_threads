using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dz1_threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30);

            int n = 25;

            for (int i = 0; i < n; i++)
                new Thread(new Matrix(i*2 + 7, 30).move).Start();
            
            Console.ReadLine();
        }
    }
}
