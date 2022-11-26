using System;

namespace Cells.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            bool can_update = true;
            CellularAutomata cellularAutomata = new CellularAutomata ();
            cellularAutomata.Initialisation();
            cellularAutomata.Field_output();
            while (can_update)
            {
                Console.WriteLine("Press the space bar to update the field");
                string str = Console.ReadLine();
                if (str == " ")
                {
                    cellularAutomata.Transition_Rule_dissolution();
                    //cellularAutomata.Transition_Rule_diffusion();
                    cellularAutomata.Transformation();
                    cellularAutomata.Field_output();
                }
                else
                {
                    Console.WriteLine("!!!You have exited the dissolution visualization program!!!");
                    can_update = false;
                }
            }
        }
    }
}
