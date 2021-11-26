using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntPattern
{
    class Rules
    {
        public Color clr { get; set; }
        public bool dir { get; set; } //true == right, false == left
        private static Random rnd = new Random();

        public Rules(Color clr)
        {
            this.clr = clr;
            this.dir = rnd.Next(0, 2) == 1;
        }
    }
}
