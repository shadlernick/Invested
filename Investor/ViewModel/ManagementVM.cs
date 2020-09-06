
using GalaSoft.MvvmLight.Command;
using Investor.Database;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Investor.ViewModel
{
    public class ManagementVM : INotifyPropertyChanged
    {
        private DatabaseLists _databaseLists;

        public static event EventHandler OnSelectedItemChanged;
        public ObservableCollection<Deal> Deals { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<DealClient> DealClients { get; set; }
        public ObservableCollection<DealClient> Temp { get; set; }

        RelayCommand _close;

        public void RemoveDealClient()
        {
            //_investorContext.Deals.Remove(SelectedDeal);
            Deals.Remove(SelectedDeal);
            Temp = new ObservableCollection<DealClient>();
            OnPropertyChanged("Temp");
            //_investorContext.SaveChanges();

        }


        private DealClient _selectedDealClient;
        public DealClient SelectedDealClient
        {
            get => _selectedDealClient;
            set
            {
                _selectedDealClient = value;
                OnPropertyChanged("SelectedDealClient");
            }
        }

        private Deal _selectedDeal;
        public Deal SelectedDeal
        {
            get => _selectedDeal;
            set
            {
                _selectedDeal = value;
                OnPropertyChanged("SelectedDeal");
                OnSelectedItemChanged?.Invoke(this, null);
            }
        }

        public ManagementVM()   //constructor
        {
            //this._investorContext = investorContext;
            //Deals = new ObservableCollection<Deal>(_investorContext.Deals.ToList());
            //Clients = new ObservableCollection<Client>(_investorContext.Clients.ToList());
            //DealClients = new ObservableCollection<DealClient>(_investorContext.DealClients.ToList());
            _databaseLists = DatabaseLists.GetDatabaseLists();

            Deals = _databaseLists.Deals;
            Clients = _databaseLists.Clients;
            DealClients = _databaseLists.DealClients;
            
            OnSelectedItemChanged += SelectedChanged;
        }

        private void SelectedChanged(object sender, EventArgs e)
        {
            try
            {
                ObservableCollection<DealClient> CartProducts = new ObservableCollection<DealClient>();
                foreach (DealClient dc in DealClients)
                {
                    if (SelectedDeal.Id == dc.DealId) //exception!!!!!!!
                    {
                        CartProducts.Add(dc);
                    }
                }
                Temp = CartProducts;
                OnPropertyChanged("Temp");
            }
            catch (Exception ex) { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
