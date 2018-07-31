using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace thread3_myMatrix
{
    class Matrix
    {
        Random rand;
        const char sign = '*';
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

        public void move()
        {
            int length;
            int count;

            while (true)
            {
                count = rand.Next(2, 6);
                length = 0;
                Thread.Sleep(rand.Next(100, 5000));
                for (int i = 0; i < max; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = i-length;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int j = i; j > i-length; j--)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine("*");
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
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        for (int j = 0; j < length-3; j++)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine(sign);
                        }
                      
                        if (length >= 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.CursorLeft = col;
                            Console.WriteLine(sign);
                        }

                        if (length >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.CursorLeft = col;
                            Console.WriteLine(sign);
                        }
                        if (length >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.CursorLeft = col;
                            Console.WriteLine(sign);
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
