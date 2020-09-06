using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor
{
    class CareTaker
    {
        public Stack<Memento> History { get; set; }
        public CareTaker()
        {
            History = new Stack<Memento>();
        }
    }
}
