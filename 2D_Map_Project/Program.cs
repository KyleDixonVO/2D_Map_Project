using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2D_Map_Project
{
    class Program
    {   //public int Length { get; }
        static int rows;
        static int columns;
        static int dimension;
        static int scale = 1;
        static int i;
        static int j;
        static void Main(string[] args)
        {
            rows = map.GetUpperBound(dimension) + 1;
            columns = map.GetUpperBound(dimension + 1) + 1;
            DisplayMap();
            ShowLegend();
            SetScale();
            DisplayMap(scale);
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            Console.SetWindowSize((columns +2) , (rows * 3));
            Console.SetBufferSize((columns + 2), (rows * 3));
            HorizontalBorder(scale);
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\r\n");
                VerticalBorder();
                //Console.SetCursorPosition(0, Console.CursorTop-1);
                for (int j = 0; j < columns; j++)
                {
                    ColorMap(i, j);
                    Console.Write(map[i, j]);
                }
                VerticalBorder();
            }
            Console.Write("\r\n");
            HorizontalBorder(scale);
        }

        static void DisplayMap(int scale)
        {
            Console.SetWindowSize(((columns * scale) + 2), ((rows * scale)+3));
            Console.SetBufferSize(((columns * scale) + 2), ((rows * scale)+3));
            HorizontalBorder(scale);
            for (i = 0; i < (rows); i++)
            {
                for (int l = 0; l < scale; l++)
                {
                    VerticalBorder();
                    for (j = 0; j < (columns); j++)
                    {
                        for (int k = 0; k < scale; k++)
                        {
                            ColorMap(i, j);
                            Console.Write(map[i, j]);
                        }
                    }
                    VerticalBorder();
                }
            }
            HorizontalBorder(scale);
            Console.ResetColor();
        }

        static void SetScale()
        {
            Console.Write("\r\n");
            Console.WriteLine("Set map scale, input must be an intger greater than zero");
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

        static char[,] map = new char[,]
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
        //{'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''}, //extra row for testing
        };

        static void ColorMap(int i, int j)
        {
            if (map[i, j] == '\'')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            if (map[i, j] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            if (map[i, j] == '*')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            if (map[i, j] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
            }
          
        }

        static void VerticalBorder()
        {
            Console.ResetColor();
            Console.Write('¦');
        }

        static void HorizontalBorder(int scale)
        {
            for (int m = 0; m < ((columns * scale) + 2); m++)
            {
                Console.Write('»');
            }
        }

        static void ShowArrayInfo(Array array)
        {
            Console.WriteLine(" Length of array:        {0,3}", array.Length);
            Console.WriteLine(" Number of dimensions: {0,3}", array.Length);

            if (array.Rank >1)
            {
                for ( dimension = 1; dimension <= array.Rank; dimension++)
                {
                    Console.WriteLine(" Dimension {0}: {1,3}", dimension, array.GetUpperBound(dimension - 1) + 1);
                }
            }
        }

        static void ShowLegend()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("\r\n \' = Grass");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("\r\n ^ = Mountains");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("\r\n * = Trees");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("\r\n ~ = Water");
            Console.ResetColor();
            Console.Write("\r\n");
        }
        
        
        
        
    }
}
