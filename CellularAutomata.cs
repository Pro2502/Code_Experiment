﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cells.Start
{
    internal class CellularAutomata
    {
        static int X;
        static int Y;
        public int rows = 10;
        public int cols = 10;
        public int saturated_solution = 5;
        public int maximum_concentration = 9;
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
            
            Console.WriteLine("Set the diameter of the tablet in the amount of 1 to 4");
            string str = Console.ReadLine();
            int D = Convert.ToInt32(str);

            int R = D / 2;
            //Console.WriteLine("Our tablet diameter: " + R);
            bool new_cell_has_not_been_created = true;

            Random rnd = new Random();
            X = rnd.Next(0, rows);
            Y = rnd.Next(0, cols);
            //Console.WriteLine("The coordinates of the center of our tablet: X = "+X+"; Y = "+Y);
            //bool intersection_with_another_cell = false;
            while (new_cell_has_not_been_created)
            {  
                if (X - R >= 0 & Y - R! >= 0 & X + R <= rows-1 & Y+R<=cols-1)
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
                    if (R == 0)
                    {
                        rnd = new Random();
                        X = rnd.Next(0, rows);
                        Y = rnd.Next(0, cols);
                        //Console.WriteLine("The coordinates of the center of our tablet: X = " + X + "; Y = " + Y);
                    }
                    for (int i = X - R; i <= X + R; i++)
                    {
                        for (int j = Y - R; j <= Y + R; j++)
                        {
                            Field[i, j].concentration = maximum_concentration;
                            //Random random = new Random();
                            //Field[i, j].concentration = random.Next(saturated_solution + 1);
                            //Field[i, j].concentration += saturated_solution;

                        }
                    }
                    new_cell_has_not_been_created = false;
                }
                else
                {
                    //R--;
                    //if (R==0)
                    //{
                        R = D / 2;
                        rnd = new Random();
                        X = rnd.Next(0, rows-1);
                        Y = rnd.Next(0, cols-1);
                        //Console.WriteLine("The coordinates of the center of our tablet: X = " + X + "; Y = " + Y);
                    //}
                }
            }

            Console.WriteLine("The coordinates of the center of our tablet: X = " + X + "; Y = " + Y);
            Console.WriteLine("Our tablet diameter: " + R);

            //void Update()
            //{
            //    Field[0, 0].concentration += 100;
            //}

        }
        public void Transition_Rule_dissolution()
        {

            double k =0.2;
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {

                    if (Field[x, y].concentration >= saturated_solution)
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
                        int I, J;
                        
                        for (int i = x-1; i <=x+1; i++)
                        {
                            for (int j = y-1; j <= y+1; j++)
                            {
                                
                                I = i;
                                J = j;

                                if (x - 1 < 0 )
                                {
                                    I = rows - 1;
                                }
                                if ( y - 1 < 0 )
                                {
                                    
                                    J = cols-1;
                                }
                                if ( x + 1 > rows-1 )
                                {
                                    
                                    I = 0;
                                }
                                if ( y + 1 > cols-1)
                                {
                                    
                                    J = 0;
                                }
                                
                                 if (I != x && J != y && Field[I, J].concentration < saturated_solution)
                                    {
                                        if ((I != x - 1 && J != y-1 ) || (I != x - 1 && J != y + 1) ||(I != x + 1 && J != y - 1) || (I != x + 1 && J != y + 1) )
                                        {
                                            dC = -k * (saturated_solution - Field[x, y].concentration);
                                            int new_dC = Convert.ToInt32(dC);
                                            //Field[i, j].concentration = -new_dC;
                                            Field_for_calculation[I, J].accumulation_concentration = Field_for_calculation[I, J].accumulation_concentration + new_dC;
                                            Field_for_calculation[x, y].accumulation_concentration = Field_for_calculation[x, y].accumulation_concentration - new_dC;
                                        }
                                 }
                            }
                        }
                    }
                }
            }
        }

        //public void Transition_Rule_diffusion()
        //{
        //    double D = 0.1;
        //    for (int x = 0; x < rows; x++)
        //    {
        //        for (int y = 0; y < cols; y++)
        //        {

        //            if (Field[x, y].concentration < saturated_solution)
        //            {
        //                double dC;
        //                int I, J;
        //                for (int i = x - 1; i <= x + 1; i++)
        //                {
        //                    for (int j = y - 1; j < y + 1; j++)
        //                    {
        //                        I = i;
        //                        J = j;

        //                        if (x - 1 < 0)
        //                        {

        //                            I = rows - 1;

        //                        }
        //                        if (y - 1 < 0)
        //                        {

        //                            J = cols - 1;
        //                        }
        //                        if (x + 1 > rows-1)
        //                        {

        //                            I = 0;
        //                        }
        //                        if (y + 1 > cols-1)
        //                        {

        //                            J = 0;
        //                        }

        //                        if (I != x && J != y && Field[I, J].concentration < saturated_solution && Field[I, J].concentration > Field[x, y].concentration)
        //                        {
        //                            if ((I != x - 1 & J != y - 1) | (I != x - 1 & J != y + 1) | (I != x + 1 & J != y - 1) | (I != x + 1 & J != y + 1))
        //                            {
        //                                dC = D * (Field[I, J].concentration - Field[x, y].concentration);
        //                                int new_dC = Convert.ToInt32(dC);
        //                                Field_for_calculation[I, J].accumulation_concentration = -new_dC;
        //                                Field_for_calculation[x, y].accumulation_concentration = +new_dC;
        //                            }
        //                        }
        //                        if (I != x && J != y && Field[I, J].concentration < saturated_solution && Field[I, J].concentration < Field[x, y].concentration)
        //                        {
        //                            if (((I != x - 1 & J != y - 1) | (I != x - 1 & J != y + 1) | (I != x + 1 & J != y - 1) | (I != x + 1 & J != y + 1)))
        //                            {
        //                                dC = D * (Field[x, y].concentration - Field[I, J].concentration);
        //                                int new_dC = Convert.ToInt32(dC);
        //                                Field_for_calculation[I, J].accumulation_concentration = +new_dC;
        //                                Field_for_calculation[x, y].accumulation_concentration = -new_dC;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        public void Transformation()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Field[i, j].concentration = Field[i, j].concentration + Field_for_calculation[i, j].accumulation_concentration;
                }
            }
        }
        public void Field_output()
        {
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y <Field.GetLength(1); y++)
                {
                    if (Field[x, y].concentration >= saturated_solution)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Field[x, y].concentration + " ");
                        Console.ResetColor();

                    }

                    else if (Field[x, y].concentration < saturated_solution && Field[x, y].concentration > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        //Console.Write("L ");
                        Console.Write(Field[x, y].concentration + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        //Console.Write(" ");
                        Console.Write(Field[x, y].concentration +" ");
                        Console.ResetColor();
                    }


                }
                Console.WriteLine();
            }
        }
    }
}
   