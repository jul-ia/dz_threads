using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dz2_threads
{
    class Matrix
    {
        Random rand;
        const string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int col;
        int max;
        static readonly object locker = new object();
        bool f;

        public Matrix(int c, int n)
        {
            rand = new Random((int)DateTime.Now.Ticks);
            col = c;
            max = n;
            f = true;
        }

        private char GetChar()
        {
            return s.ToCharArray()[rand.Next(0, s.Length)];
        }

        public void move()
        {
            int length;
            int count;

            while (true)
            {
                count = rand.Next(3, 6);
                length = 0;
                Thread.Sleep(rand.Next(10, 1500));
                for (int i = 0; i < max; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = i - length;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int j = i; j > i - length; j--)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine(".");
                        }

                        if (length < count)
                            length++;
                        else if (length == count)
                            count = 0;

                        if (length > max - 1 - i)
                            length--;

                        if (f && i > count + 5 && i < max - 5)
                        {
                            new Thread(new Matrix(col, 30).move).Start();
                            f = false;
                        }
                        Console.CursorLeft = i - length + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < length - 2; j++)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine(GetChar());
                        }

                        if (length >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = col;
                            Console.WriteLine(GetChar());
                        }
                        if (length >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = col;
                            Console.WriteLine(GetChar());
                        }
                        Thread.Sleep(5);
                    }
                }
            }
        }
    }
}
