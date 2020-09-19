using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investor.Model;

namespace Investor.Database
{
    public class InvestorContext
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Deal> Deals { get; set; }
        public ObservableCollection<DealClient> DealClients { get; set; }

        public InvestorContext()
        {
            Clients = new ObservableCollection<Client>();
            Deals = new ObservableCollection<Deal>();
            DealClients = new ObservableCollection<DealClient>();
        }
    }
}
