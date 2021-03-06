﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            var A1 = new Angle(30,45,61);
            var A2 = new Angle(45,30,30);
            var A3 = A1 + A2;
            var A4 = A1 - A2;
            Console.WriteLine($"A1 = {A1}");
            Console.WriteLine($"A2 = {A2}");
            Console.WriteLine($"A1 == A2?  {A1 == A2}");
            Console.WriteLine($"A1 != A2?  {A1 != A2}");
            Console.WriteLine($"A3 = A1 + A2 = {A3}");
            Console.WriteLine($"A4 = A1 - A2 = {A4}");
            Console.WriteLine($"A1 * 5 = {A1 * 5}");
            Console.WriteLine($"A2 / 3 = {A2 / 3}");
            Console.WriteLine($"A2 / A1= {A2 / A1}");

            Console.WriteLine(A1[0]);
            Console.WriteLine(A1[1]);
            Console.WriteLine(A1[2]);

            foreach (int value in A1)
            {
                Console.Write(value + " ");
            }

            Angle[] Arr = { A1, A2, A3, A4 };

            // Default sort by degrees
            Array.Sort(Arr);

            Console.WriteLine("\nSorted by degrees: ");
            foreach (Angle A in Arr)
            {
                Console.WriteLine(A);
            }

            // Sort by minutes
            Array.Sort(Arr, new AngleMinutesComparator());

            Console.WriteLine("\nSorted by minutes: ");
            foreach (Angle A in Arr)
            {
                Console.WriteLine(A);
            }

            // Sort by seconds
            Array.Sort(Arr, new AngleSecondsComparator());

            Console.WriteLine("\nSorted by seconds: ");
            foreach (Angle A in Arr)
            {
                Console.WriteLine(A);
            }
        }
    }

    
}
