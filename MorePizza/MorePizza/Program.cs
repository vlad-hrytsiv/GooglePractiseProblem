using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizza
{
    class Program
    {
        public int[,] getDynamicTable(int[] pizzaSlices, int numberOfParticipants)
        {
            int n = pizzaSlices.Length;
            int[,] dynamicTable = new int[numberOfParticipants + 1, n + 1];

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= numberOfParticipants; i++)
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
        static void Main(string[] args)
        {
            int[] pizzaSlices = new int[4] { 2, 5, 6, 8 }; 
            int numberOfParticipants = 17;

            Program program = new Program();

            /*for (int i = 1; i <= pizzaSlices.Length; i++)
            {
                for (int j = 1; j <= numberOfParticipants; j++)
                {
                    Console.Write(program.getDynamicTable(pizzaSlices, numberOfParticipants)[j, i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();*/

            Console.Write("Answer: "+program.getDynamicTable(pizzaSlices, numberOfParticipants)[numberOfParticipants, pizzaSlices.Length]+"\n");
        }
    }
}
