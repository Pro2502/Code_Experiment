using System;

namespace Cells.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            bool can_update = true;
            bool no_end = true;
            CellularAutomata cellularAutomata = new CellularAutomata ();
            cellularAutomata.Initialisation();
            cellularAutomata.Field_output();
            while (no_end)
            {
                while (can_update)
                {
                    //Console.WriteLine("Press ENTER to go through the next iteration");
                    //string str = Console.ReadLine();
                    //if (str == "")
                    //{
                    if (no_end)
                    {
                        cellularAutomata.Transition_Rule_dissolution();
                        //cellularAutomata.Transformation();
                        Console.WriteLine("After dissolution");
                        cellularAutomata.Field_output();
                        cellularAutomata.Transition_Rule_diffusion();
                        //cellularAutomata.Transformation();
                        Console.WriteLine("After diffusion");
                        cellularAutomata.Field_output();
                        
                            cellularAutomata.Iteration_Count(ref no_end);

                    }
                        else
                        {
                            break;
                        }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("!!!You have exited the dissolution visualization program!!!");
                    //    can_update = false;
                    //}
                }
            
            }
        }
    }
}
