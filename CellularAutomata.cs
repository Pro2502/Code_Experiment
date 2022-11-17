using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cells.Start
{
    //enum Color
    //{
    //    Blue,
    //    White
    //}
    internal class CellularAutomata
    {
        public int rows = 50;
        public int cols = 50;
        public Cell[,] Field;
        public Calculation[,] Field_for_calculation;
        static void StartCreate (ref Cell[,] Field,ref Calculation[,] Field_for_calculation, int rows, int cols)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Field[x, y] = new Cell();
                    Field_for_calculation[x, y] = new Calculation();
                    //Field[x,y].concentration = random.Next(251);
                    Field[x, y].concentration = 0;
                    Field_for_calculation[x, y].accumulation_concentration = 0;
                }
            }
        }
        public void Initialisation()
        {
            Field = new Cell[rows, cols];
            Field_for_calculation = new Calculation[rows, cols];

            CellularAutomata.StartCreate(ref Field,ref Field_for_calculation, rows, cols);
            Random rnd = new Random();
            int X = rnd.Next(0, rows);
            int Y = rnd.Next(0, cols);
            Console.WriteLine("Set the diameter of the tablet in the amount of 10 to 50");
            string str = Console.ReadLine();
            int D = Convert.ToInt32(str);

            int R = D / 2;
            Console.WriteLine("Our tablet diameter: " + R);
            bool new_cell_has_not_been_created = true;
            //bool intersection_with_another_cell = false;
            while (new_cell_has_not_been_created)
            {
                if (X - R >= 0 & Y - R! >= 0 & X + R <= rows & Y+R<=cols)
                {
                    //условие на наличие другой таблетки
                    //while (intersection_with_another_cell != true)
                    //{
                    //    for (int x = X - R; x <= X + R; x++)
                    //    {
                    //        for (int y = Y - R; y <= Y + R; y++)
                    //        {
                    //            if (Field[x, y].concentration >= 250)
                    //            {
                    //                intersection_with_another_cell = true;
                    //            }
                    //        }
                    //    }
                    //    if (intersection_with_another_cell)
                    //    {
                    //        R--;
                    //        intersection_with_another_cell = false;
                    //    }
                    //}
                    Random random = new Random();
                    for (int i = X - R; i < X + R; i++)
                    {
                        for (int j = Y - R; j < Y + R; j++)
                        {
                            Field[i, j].concentration = random.Next(100);
                            Field[i, j].concentration += 900;
                        }
                    }
                    new_cell_has_not_been_created = false;
                }
                else
                {
                    R--;
                }

            }
            //void Update()
            //{
            //    Field[0, 0].concentration += 100;
            //}
            Console.WriteLine("Let's derive our tablet with the appropriate concentrations:");
            //for (int x = 0; x < rows; x++)
            //{
            //    for (int y = 0; y < cols; y++)
            //    {
            //        Console.WriteLine(Field[x, y].concentration);
            //    }
            //}
        }
        public void Transition_Rule_dissolution()
        {
            double k =0.9;
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {

                    if (Field[x, y].concentration >= 250)
                    {
                        double dC;
                        //Console.WriteLine("Введите мощность, затрачиваемую на смешивание");
                        //string str = Console.ReadLine();
                        //int N = Convert.ToInt32(str);
                        //Console.WriteLine("Введите массу перемешиваемой системы");
                        //string str = Console.ReadLine();
                        //int G = Convert.ToInt32(str);
                        //Console.WriteLine("Введите кинетическую вязкость");
                        //str = Console.ReadLine();
                        //int v = Convert.ToInt32(str);
                        //Console.WriteLine("Введите коэффициент диффузии");
                        //str = Console.ReadLine();
                        //int D = Convert.ToInt32(str);
                        ////находим массу твердого вещества
                        //int M = -(1 / G) ^ (1 / 4) * (v / D) ^ (-3 / 4) * 1 * (250 - Field[x, y].concentration);
                        for (int i = x-1; i <=x+1; i++)
                        {
                            for (int j = y-1; j < y+1; j++)
                            {
                                if (i != x && j != y && Field[i, j].concentration < 250)
                                {
                                    if ((i != x - 1 & j != y - 1) | (i != x - 1 & j != y + 1) | (i != x + 1 & j != y - 1) | (i != x + 1 & j != y + 1))
                                    {
                                        dC = k * (250.0 - Field[x, y].concentration);
                                        int new_dC = Convert.ToInt32(dC);
                                        //Field[i, j].concentration = -new_dC;
                                        Field_for_calculation[i, j].accumulation_concentration = -new_dC;
                                }
                            }

                        }
                        }
                 
                    }
                }
            }
        }

        public void Transition_Rule_diffusion()
        {
            double D = 0.6;
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {

                    if (Field[x, y].concentration < 250)
                    {
                        double dC;

                        for (int i = x - 1; i <= x + 1; i++)
                        {
                            for (int j = y - 1; j < y + 1; j++)
                            {
                                if (i!=x && j!=y && Field[i, j].concentration < 250 && Field[i, j].concentration > Field[x, y].concentration)
                                {
                                    if ((i != x - 1 & j != y - 1) | (i != x - 1 & j != y + 1) | (i != x + 1 & j != y - 1) | (i != x + 1 & j != y + 1))
                                    {
                                        dC = D * (Field[i, j].concentration - Field[x, y].concentration);
                                        int new_dC = Convert.ToInt32(dC);
                                        Field_for_calculation[i,j].accumulation_concentration = -new_dC;
                                        Field_for_calculation[x,y].accumulation_concentration = +new_dC;
                                    }
                                }
                                if (i != x && j != y && Field[i, j].concentration < 250 && Field[i, j].concentration < Field[x, y].concentration)
                                {
                                    if ((i != x - 1 & j != y - 1) | (i != x - 1 & j != y + 1) | (i != x + 1 & j != y - 1) | (i != x + 1 & j != y + 1))
                                    {
                                        dC = D * (Field[x, y].concentration - Field[i, j].concentration);
                                        int new_dC = Convert.ToInt32(dC);
                                        Field_for_calculation[i, j].accumulation_concentration = +new_dC;
                                        Field_for_calculation[x, y].accumulation_concentration = -new_dC;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Transformation()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Field[i, j].concentration = +Field_for_calculation[i, j].accumulation_concentration;
                }
            }
        }

     }
}
   