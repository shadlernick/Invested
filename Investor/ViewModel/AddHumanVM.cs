
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

namespace Investor.ViewModel
{
    ///<summary> ViewModel соединяющая Client(Model) и AddHumanWindow(View) </summary>
    public class AddHumanVM : ISelectedChangable, INotifyPropertyChanged
    {
        //private DatabaseLists _databaseLists;

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
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
                OnSelectedItemChanged?.Invoke(this, null);
            }
        }

        public Client NewClient
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
                OnPropertyChanged("NewClient");
            }
        }

        ///constructor инициализирую Client`a и ObservableCollection`ы
        public AddHumanVM()
        {
            //_investorContext = investorContext;

            //_databaseLists = DatabaseLists.GetDatabaseLists();

            //Clients = _databaseLists.Clients;

            NewClient = new Client();
        }

        private bool _isAddEnable = true;
        public bool IsEnabled
        {
            get
            {
                return _isAddEnable;
            }
            set
            {
                _isAddEnable = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        //}
        /// <summary>
        /// Редактирование существующего client`a
        /// </summary>
        public void EditHuman()
        {
            NewClient = SelectedClient;
            IsEnabled = false;
            OnSelectedItemChanged += base.SelectedChanged;
            //Clients.Where(x => x.Id == selectedClient.Id).FirstOrDefault().Name = NewClient.Name;
            //Clients.Where(x => x.Id == selectedClient.Id).FirstOrDefault().Info = NewClient.Info;
            //Clients.Where(x => x.Id == selectedClient.Id).FirstOrDefault().Card = NewClient.Card;
            //Clients.Where(x => x.Id == selectedClient.Id).FirstOrDefault().Phone = NewClient.Phone;

            //client = new Client();

        }

        /// <summary>
        /// Добавление нового client`a
        /// </summary>
        public void AddHuman()
        {
            try
            {
                Clients.Add(NewClient);
                //_investorContext.Clients.Add(NewClient);
                //_investorContext.SaveChanges();
                NewClient = new Client();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Sure, you complete all strings");
            }

        }

        /// <summary>
        /// Удаление существующего client`a
        /// </summary>
        public void RemoveHuman()
        {
            try
            {
                //_investorContext.Clients.Remove(SelectedClient);
                Clients.Remove(SelectedClient);
                //_investorContext.SaveChanges();
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
