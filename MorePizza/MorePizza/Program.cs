﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizza
{
    class Program
    {
        public int[,] getDynamicTable(int[] pizzaSlices, int[] pizzaValues, int numberOfParticipants)
        {
            int n = pizzaSlices.Length;
            int[,] dynamicTable = new int[numberOfParticipants + 1, n + 1];

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= numberOfParticipants; i++)
                {
                    if (pizzaSlices[j - 1] <= i)
                    {
                        dynamicTable[i, j] = Math.Max(dynamicTable[i, j - 1], dynamicTable[i - pizzaSlices[j - 1], j - 1] + pizzaValues[j - 1]);
                    }
                    else
                    {
                        dynamicTable[i, j] = dynamicTable[i, j - 1];
                    }
                }
            }
            return dynamicTable;
        }
        static void Main(string[] args)
        {
            int[] pizzaSlices = new int[50] { 7, 12, 12, 13, 14, 28, 29, 29, 30, 32, 32, 34, 41, 45, 46, 56, 61, 61, 62, 63, 65, 68, 76, 77, 77, 92, 93, 94, 97, 103, 113, 114, 114, 120, 135, 145, 145, 149, 156, 157, 160, 169, 172, 179, 184, 185, 189, 194, 195, 195 }; // Профіт від використання
            int[] pizzaValues = new int[50] { 7, 12, 12, 13, 14, 28, 29, 29, 30, 32, 32, 34, 41, 45, 46, 56, 61, 61, 62, 63, 65, 68, 76, 77, 77, 92, 93, 94, 97, 103, 113, 114, 114, 120, 135, 145, 145, 149, 156, 157, 160, 169, 172, 179, 184, 185, 189, 194, 195, 195 }; // Скільки важать
            int numberOfParticipants = 4500;

            Program program = new Program();

            /*for (int i = 1; i <= pizzaSlices.Length; i++)
            {
                for (int j = 1; j <= numberOfParticipants; j++)
                {
                    Console.Write(program.getDynamicTable(pizzaSlices, pizzaValues, numberOfParticipants)[j, i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();*/

            Console.Write("Answer: "+program.getDynamicTable(pizzaSlices, pizzaValues, numberOfParticipants)[numberOfParticipants, pizzaSlices.Length]+"\n");
        }
    }
}