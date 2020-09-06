using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Investor.Database
{
    public class DatabaseLists
    {
        private InvestorContext _investorContext;

        public ObservableCollection<Deal> Deals { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<DealClient> DealClients { get; set; }

        private static DatabaseLists _instance;

        public static DatabaseLists GetDatabaseLists()
        {
            if (_instance == null)
                _instance = new DatabaseLists();
            return _instance;
        }

        private DatabaseLists()
        {
            _investorContext = new InvestorContext();

            try
            {
                Deals = new ObservableCollection<Deal>(_investorContext.Deals.ToList());
                Clients = new ObservableCollection<Client>(_investorContext.Clients.ToList());
                DealClients = new ObservableCollection<DealClient>(_investorContext.DealClients.ToList());
            }
            catch
            {
                //todo: logger
                Deals = new ObservableCollection<Deal>();
                Clients = new ObservableCollection<Client>();
                DealClients = new ObservableCollection<DealClient>();
            }

        }
    }
}
