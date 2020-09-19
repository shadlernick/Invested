
using GalaSoft.MvvmLight.Command;
using Investor.Model;
using Investor.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Investor.Database;

namespace Investor.ViewModel
{
    public class AddHumanVM : ViewModelBase
    {
        //private DatabaseLists _databaseLists;

        private Client client;

        public ObservableCollection<Client> Clients { get; set; }

        #region RelayCommands
        private RelayCommand _addHumanCommand;
        private RelayCommand _editHumanCommand;
        private RelayCommand _removeHumanCommand;

        public RelayCommand AddHumanCommand => _addHumanCommand;
        public RelayCommand EditHumanCommand => _editHumanCommand;
        public RelayCommand RemoveHumanCommand => _removeHumanCommand;
        #endregion

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public Client NewClient
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged("NewClient");
            }
        }

        public AddHumanVM(InvestorContext investorContext) : base(investorContext)
        {
            //_investorContext = investorContext;
            //_databaseLists = DatabaseLists.GetDatabaseLists();
            //Clients = _databaseLists.Clients;
            Clients = new ObservableCollection<Client>();

            _addHumanCommand = new RelayCommand(AddHumanMethod);
            _editHumanCommand = new RelayCommand(EditHumanMethod);
            _removeHumanCommand = new RelayCommand(RemoveHumanMethod);

            NewClient = new Client();
        }

        private bool _isAddEnable = true;
        public bool IsEnabled
        {
            get => _isAddEnable;
            set
            {
                _isAddEnable = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public void EditHumanMethod()
        {
            NewClient = SelectedClient;
            IsEnabled = false;
        }

        public void AddHumanMethod()
        {
            try
            {
                Clients.Add(NewClient);
                NewClient = new Client();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Sure, you complete all strings");
            }

        }

        public void RemoveHumanMethod()
        {
            try
            {
                Clients.Remove(SelectedClient);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please, select client!");
            }

        }
    }
}
