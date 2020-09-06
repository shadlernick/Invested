using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.MementoPattern
{
    class CareTaker
    {
        public Stack<Memento> History { get; private set; }
        public CareTaker()
        {
            History = new Stack<Memento>();
        }
    }
}
