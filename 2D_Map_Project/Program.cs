using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Map_Project
{
    class Program
    {
        static int[,] TileArray = new int[rows, columns];
        static int rows = 12;
        static int columns = 30;
        static int scale = 2;
        static string repeatLine;
        static void Main(string[] args)
        {
            DisplayMap();
            SetScale();
            DisplayMap(scale);
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            Console.SetWindowSize(30, 30);
            Console.SetBufferSize(30, 30);
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(map[i,j]);
                    
                }
            }
        }

        static void DisplayMap(int scale)
        {
            Console.SetWindowSize((30*scale),(15*scale));
            Console.SetBufferSize((30*scale), (15*scale));
            for (int i = 0; i < (12); i++)
            {
                for (int j = 0; j < (30); j++)
                {
                    for (int k = 0; k < scale; k++)
                    {
                        Console.Write(map[i, j]);
                    }    
                }
                repeatLine = Console.ReadLine();
                Console.WriteLine(repeatLine);

            }
        }

        static void SetScale()
        {
            Console.WriteLine("Set map scale");
            Console.WriteLine("Input must be");
            Console.WriteLine("A intger greater");
            Console.WriteLine("Than Zero.");
            string input = Console.ReadLine();
            bool isInteger = int.TryParse(input, out int inputResult);
            if (isInteger == true && inputResult > 0)
            {
               scale = inputResult;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                SetScale();
            }

        }

        static char[,] map = new char[12, 30]
        {
            {'^','^','^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'^','^','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\''},
        {'^','^','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\''},
        {'^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\''},
        {'\'','\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        };
    }
}
