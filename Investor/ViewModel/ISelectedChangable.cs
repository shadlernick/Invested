using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.ViewModel
{
    public abstract class ISelectedChangable
    {
        public abstract void DelayEditMode();
        public void SelectedChanged(object sender, EventArgs e)
        {
            DelayEditMode();
        }
    }
}
