using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dz2_threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);

            int n = 20;
            Matrix m;
            for (int i = 0; i < n; i++)
            {
                m = new Matrix(i * 3+5, 30);
                new Thread(m.move).Start();
            }
            Console.ReadLine();
        }
    }
}
