
using GalaSoft.MvvmLight.Command;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Investor.ViewModel
{
    public class AddContractVM : INotifyPropertyChanged
    {
        private DealClient dealClient;

        public ObservableCollection<Deal> Deals { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<DealClient> DealClients { get; set; }

        private RelayCommand addDealClient;
        private RelayCommand editDealClient;
        private RelayCommand removeDealClient;

        private Client selectedClient;
        private Deal selectedDeal;
        private DealClient selectedDealClient;


        public DealClient SelectedDealClient
        {
            get => selectedDealClient;
            set
            {
                selectedDealClient = value;
                OnPropertyChanged("SelectedDealClient");
            }
        }

        public DealClient NewDealClient
        {
            get => dealClient;
            set
            {
                dealClient = value;
                OnPropertyChanged("NewDealClient");
            }
        }

        public Deal SelectedDeal
        {
            get => selectedDeal;
            set
            {
                selectedDeal = value;
                OnPropertyChanged("SelectedDeal");
            }
        }

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public AddContractVM()   //constructor
        {
            NewDealClient = new DealClient();
        }

        public void EditDealClient()
        {
        }

        public void AddDealClient()
        {
            try
            {
                NewDealClient.ClientId = SelectedClient.Id;
                NewDealClient.ClientName = SelectedClient.Name;
                NewDealClient.DealId = SelectedDeal.Id;
                NewDealClient.DealSubs = SelectedDeal.Subscription;
                DealClients.Add(NewDealClient);
                //_investorContext.DealClients.Add(NewDealClient);
                //_investorContext.SaveChanges();

                //DATABASE

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Sure, you complete all strings");
            }
        }

        public void RemoveDealClient()
        {
            try
            {
                //_investorContext.DealClients.Remove(SelectedDealClient);
                DealClients.Remove(SelectedDealClient);
                //_investorContext.SaveChanges();

                //DATABASE
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please, select contract!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
