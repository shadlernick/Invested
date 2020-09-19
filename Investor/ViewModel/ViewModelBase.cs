using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Investor.Database;

namespace Investor.ViewModel
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public InvestorContext InvestorContext;

        public ViewModelBase(InvestorContext investorContext)
        {
            this.InvestorContext = investorContext;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
