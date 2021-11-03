using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2D_Map_Project
{
    class Program
    {
        static int[,] TileArray = new int[rows, columns];
        static int rows = 12;
        static int columns = 30;
        static int scale = 1;
        static int i;
        static int j;
        static void Main(string[] args)
        {
            DisplayMap();
            SetScale();
            DisplayMap(scale);
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {
            Console.SetWindowSize(32, 30);
            Console.SetBufferSize(32, 30);
            HorizontalBorder(scale);
            for (int i = 0; i < 12; i++)
            {
                Console.Write("\r\n");
                VerticalBorder();
                //Console.SetCursorPosition(0, Console.CursorTop-1);
                for (int j = 0; j < 30; j++)
                {
                    ColorMap(i, j);
                    Console.Write(map[i,j]);
                }
                VerticalBorder();
            }
            Console.Write("\r\n");
            HorizontalBorder(scale);
        }

        static void DisplayMap(int scale)
        {
            Console.SetWindowSize(((30*scale)+2),(20*scale));
            Console.SetBufferSize(((30*scale)+2), (20*scale));
            HorizontalBorder(scale);
            for (i = 0; i < (rows); i++)
            {
                for (int l = 0; l < scale; l ++)
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

        static void ColorMap(int i, int j)
        {
            if (map[i,j] == '\'')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            if  (map[i,j] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            if (map[i,j] == '*')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            if (map[i,j] == '~')
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
            for (int m = 0; m < ((30 * scale)+2); m++)
            {
                Console.Write('»');
            }
        }
        static void HorizontalBorder()
        {
            for (int m = 0; m < 32; m++)
            {
                Console.Write('+');
            }
        }
    }
}
