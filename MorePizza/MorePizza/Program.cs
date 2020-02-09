using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizza
{
    class Program
    {
        /* Функція для отримання даних з файлу */
        static int[] GetInfo(ref int a, ref int b)
        {
            string path = @"C:\Users\Vlad Hrytsiv\Downloads\b_small.in";
            string line;
            int[] firstLineNums, secondLineNums;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            
            line = file.ReadLine(); // Читання першого рядка файлу


            /* Перетворення першого рядка в массив, а далі в змінні */
            firstLineNums = Array.ConvertAll(line.Split(' '), int.Parse);

            int maxSlices = firstLineNums[0];
            int pizzaTypes = firstLineNums[1];

            a = maxSlices;
            b = pizzaTypes;
            
            line = file.ReadLine(); // Перетворення другого рядка в массив

            secondLineNums = Array.ConvertAll(line.Split(' '), int.Parse);
            return secondLineNums;
        } 
        public int[,] getDynamicTable(int[] pizzaSlices, int maxSlices)
        {
            int[,] dynamicTable = new int[maxSlices + 1, pizzaSlices.Length + 1];

            for (int j = 1; j <= pizzaSlices.Length; j++)
            {
                for (int i = 1; i <= maxSlices; i++)
                {
                    if (pizzaSlices[j - 1] <= i)
                    {
                        dynamicTable[i, j] = Math.Max(dynamicTable[i, j - 1], dynamicTable[i - pizzaSlices[j - 1], j - 1] + pizzaSlices[j - 1]);

                    }
                    else
                    {
                        dynamicTable[i, j] = dynamicTable[i, j - 1];
                    }
                }
            }
            return dynamicTable;
        }

        static void DisplayTable(int[,] user_Table, int[] width, int length)
        {
            for (int i = 1; i <= width.Length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    Console.Write(user_Table[j, i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int maxSlices = 0, pizzaTypes = 0;
            int[] pizzaSlices = GetInfo(ref maxSlices, ref pizzaTypes);

            Program program = new Program();

            int[,] readyTable = program.getDynamicTable(pizzaSlices, maxSlices);

            // DisplayTable(readyTable, pizzaSlices, maxSlices);

            Console.Write("Answer: " + readyTable[maxSlices, pizzaSlices.Length] + "\n");
        }
    }
}