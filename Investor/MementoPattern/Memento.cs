using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.MementoPattern
{
    class Memento
    {
        public object ViewModelContext;

        public Memento(object vmc)
        {
            this.ViewModelContext = vmc;
        }
    }
}
