
using GalaSoft.MvvmLight.Command;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Investor.ViewModel
{
    public class AddDealVM : INotifyPropertyChanged
    {
        //private DatabaseLists _databaseLists;
        public ObservableCollection<Deal> Deals { get; set; }


        Builder _dealBuilder;
        private Deal _deal;
        private Deal _selectedDeal;


        private RelayCommand _addDealCommand;
        private RelayCommand _editDealCommand;
        private RelayCommand _removeDealCommand;
        private RelayCommand _delayEditModeCommand;

        public RelayCommand AddDealCommand
        {
            get => _addDealCommand;
        }
        public RelayCommand EditDealCommand
        {
            get => _editDealCommand;
        }
        public RelayCommand RemoveDealCommand
        {
            get => _removeDealCommand;
        }
        public RelayCommand DelayEditModeCommand
        {
            get => _delayEditModeCommand;
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

        public Deal NewDeal
        {
            get => _deal;
            set
            {
                _deal = value;
                OnPropertyChanged("NewDeal");
            }
        }

        public AddDealVM()   //constructor
        {
            _dealBuilder = new Builder();
            //_investorContext = investorContext;

            //_databaseLists = DatabaseLists.GetDatabaseLists();
            //Deals = _databaseLists.Deals;
            NewDeal = _dealBuilder.BuildDealWithDate();


            _addDealCommand = new RelayCommand(AddDealMethod);
            _editDealCommand = new RelayCommand(EditDealMethod);
            _removeDealCommand = new RelayCommand(RemoveDealMethod);

        }


        public void AddDealMethod()
        {
            Deals.Add(NewDeal);
            //_investorContext.Deals.Add(NewDeal);
            //_investorContext.SaveChanges();
            NewDeal = _dealBuilder.BuildDealWithDate();
            //NewDeal = new Deal();
            //deal = new Deal();
        }

        public void EditDealMethod()
        {
            NewDeal = SelectedDeal;
            IsEnabled = false;

            _editDealCommand = new RelayCommand(DelayEditModeMethod);
        }

        public void RemoveDealMethod()
        {
            try
            {
                //_investorContext.Deals.Remove(SelectedDeal);
                Deals.Remove(SelectedDeal);
                //_investorContext.SaveChanges();
                //NewDeal = new Deal();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please, select deal!");
            }

        }

        public void DelayEditModeMethod()
        {
            IsEnabled = true;
            //_investorContext.Deals.Find(NewDeal.Id).DateIn = NewDeal.DateIn;
            //_investorContext.Deals.Find(NewDeal.Id).DateOut = NewDeal.DateOut;
            //_investorContext.Deals.Find(NewDeal.Id).Profit = NewDeal.Profit;
            //_investorContext.Deals.Find(NewDeal.Id).Subscription = NewDeal.Subscription;
            //_investorContext.Deals.Find(NewDeal.Id).Sum = NewDeal.Sum;
            //_investorContext.SaveChanges();
            NewDeal = _dealBuilder.BuildDealWithDate();

            _editDealCommand = new RelayCommand(EditDealMethod);
        }



        public static event EventHandler OnSelectedItemChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
