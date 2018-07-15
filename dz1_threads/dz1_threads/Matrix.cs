﻿using System;
using System.Threading;

namespace dz1_threads
{
    class Matrix
    {
        Random rand;
        const string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int col;
        int max;
        static readonly object locker = new object();

        public Matrix(int c, int n)
        {
            rand = new Random((int)DateTime.Now.Ticks);
            col = c;
            max = n-4;
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
                count = rand.Next(2, 5);
                length = 0;
                Thread.Sleep(rand.Next(10, 2000));
                for(int i = 0; i < max; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = i-length;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for(int j = 0; j <= i; j++)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine(".");
                        }

                        if (length < count)
                            length++;
                        else if (length == count)
                            count = 0;

                        if (max - i < length)
                            length--;

                        Console.CursorLeft = i - length + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < length-2; j++)
                        {
                            Console.CursorLeft = col;
                            Console.WriteLine(GetChar());
                        }

                        if(length >= 2)
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

                        Thread.Sleep(15);
                    }
                }
            }
        }
    }
}
