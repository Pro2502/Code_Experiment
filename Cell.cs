using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cells.Start
{

    class Cell 
    {
        public float x { get; set; }
        public float y { get; set; }
        
        public int concentration;
        public bool IsSolid { get; private set; }
        public bool Luquid { get; private set; }
        private void Switch_Solid ()
        {
            if (concentration<250)
            {
                IsSolid = false;
            }
        }
        public int Concentration
        {
            set
            {
                concentration = value;
            }
            get
            {
                return concentration;
            }
        }
        public bool CalcSolid()
        {
            return concentration >=250;

        }
        public bool CalcLuquid()
        {
            return concentration < 250;

        }
        
    }
}
