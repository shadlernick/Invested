
using GalaSoft.MvvmLight.Command;
using Investor.Database;
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

namespace Investor.ViewModel
{
    public class AddHumanVM : ISelectedChangable, INotifyPropertyChanged
    {
        private DatabaseLists _databaseLists;

        private Client client;

        public static event EventHandler OnSelectedItemChanged;
        public ObservableCollection<Client> Clients { get; set; }

        #region RelayCommands
        private RelayCommand addHuman;
        private RelayCommand editHuman;
        private RelayCommand removeHuman;
        #endregion

        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
                OnSelectedItemChanged?.Invoke(this, null);
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

        public AddHumanVM()
        {
            //_investorContext = investorContext;

            _databaseLists = DatabaseLists.GetDatabaseLists();

            Clients = _databaseLists.Clients;

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

        public void EditHuman()
        {
            NewClient = SelectedClient;
            IsEnabled = false;
            OnSelectedItemChanged += base.SelectedChanged;
        }

        public void AddHuman()
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

        public void RemoveHuman()
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public override void DelayEditMode()
        {
            IsEnabled = true;
            NewClient = new Client();
            OnSelectedItemChanged -= base.SelectedChanged;
        }
    }
}
