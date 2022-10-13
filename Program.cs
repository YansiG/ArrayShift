using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM
{
    internal class Program
    {
        static public void Show(int[,]mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    Console.Write(mass[i, j]+" ");
                }
                Console.WriteLine();
            }
            
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int row = rand.Next(5)+2;
            int col = rand.Next(6)+2;
            if (row == col) { col++; }
            int[,] matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("Изначальная матрица:");
            Show(matrix);
            Console.WriteLine("Сдвинуть матрицу: Вправо\tВниз");
            string side = Console.ReadLine();
            Console.WriteLine("На сколько элементов сдвинуть матрицу:");
            int.TryParse(Console.ReadLine(), out int n);
            

            switch (side)
            {
                case "Вправо":
                    if (n>col)
                    {
                        n = n % col;
                        //Console.WriteLine(n%col);
                    }
                    int[,] aslide = new int[row, n];
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = col - n, ji = 0; j < col; j++, ji++)
                        {
                            aslide[i, ji] = matrix[i, j];
                        }
                    }
                    //Show(aslide);
                    int[,] bslide = new int[row, col - n];
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col - n; j++)
                        {
                            bslide[i, j] = matrix[i, j];
                        }
                    }
                    //Show(bslide);
                    Array.Clear(matrix);
                    for (int i = 0; i < aslide.GetLength(0); i++)
                    {
                        for (int j = 0; j < aslide.GetLength(1); j++)
                        {
                            matrix[i, j] = aslide[i, j];
                        }
                    }
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = aslide.GetLength(1), jj = 0; j < col; j++, jj++)
                        {
                            matrix[i, j] = bslide[i, jj];
                        }
                    }
                    Console.WriteLine("Итоговая матрица:");
                    Show(matrix);
                    break;
                case "Вниз":
                    if (n > row)
                    {
                        n = n % row;
                        //Console.WriteLine(n%col);
                    }
                    int[,] xslide = new int[n, col];
                    for (int i = row-n, ji = 0; i < row; i++, ji++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            xslide[ji, j] = matrix[i, j];
                        }
                    }
                    //Show(xslide);
                    int[,] yslide = new int[row - n, col];
                    for (int i = 0; i < row - n; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            yslide[i, j] = matrix[i, j];
                        }
                    }
                    //Show(yslide);
                    Array.Clear(matrix);
                    for (int i = 0; i < xslide.GetLength(0); i++)
                    {
                        for (int j = 0; j < xslide.GetLength(1); j++)
                        {
                            matrix[i, j] = xslide[i, j];
                        }
                    }
                    for (int i = xslide.GetLength(0), ii = 0; i < row; i++, ii++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            matrix[i, j] = yslide[ii, j];
                        }
                    } 
                    Console.WriteLine("Итоговая матрица:");
                    Show(matrix);
                    break;
                default:
                    Console.WriteLine("Такое направление неизвестно!");
                    return;
            }
        }
    }
}
