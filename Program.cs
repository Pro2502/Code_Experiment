using System;

namespace Cells.Start
{
    class Program
    {
        //public void Output()
        //{
        //    CellularAutomata cellularAutomata = new CellularAutomata();
        //    for (int y = 0; y < cellularAutomata.Field.GetLength(1); y++)
        //    {
        //        for (int x = 0; x < cellularAutomata.Field.GetLength(0); x++)
        //        {
        //            if (cellularAutomata.Field[x, y].concentration >= 250)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write("T ");
        //                Console.ResetColor();

        //            }
                        
        //            else if (cellularAutomata.Field[x, y].concentration < 250 && cellularAutomata.Field[x, y].concentration > 0)
        //                Console.Write("L ");
        //            else
        //                Console.Write(" ");

        //        }
        //        Console.WriteLine();
        //    }
        //}
        static void Main(string[] args)
        {
            CellularAutomata cellularAutomata = new CellularAutomata ();
            cellularAutomata.Initialisation();
            for (int y = 0; y < cellularAutomata.Field.GetLength(1); y++)
            {
                for (int x = 0; x < cellularAutomata.Field.GetLength(0); x++)
                {
                    if (cellularAutomata.Field[x, y].concentration >= 250)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T ");
                        Console.ResetColor();

                    }
                        
                    else if (cellularAutomata.Field[x, y].concentration < 250 && cellularAutomata.Field[x, y].concentration > 0)
                        Console.Write("L ");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
            }
            cellularAutomata.Transition_Rule_dissolution();
            cellularAutomata.Transition_Rule_diffusion();
            cellularAutomata.Transformation();
            Console.WriteLine("Click to update the field");
            for (int y = 0; y < cellularAutomata.Field.GetLength(1); y++)
            {
                for (int x = 0; x < cellularAutomata.Field.GetLength(0); x++)
                {
                    if (cellularAutomata.Field[x, y].concentration >= 250)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T ");
                        Console.ResetColor();

                    }

                    else if (cellularAutomata.Field[x, y].concentration < 250 && cellularAutomata.Field[x, y].concentration > 0)
                        Console.Write("L ");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
            }
        }
    }
}
