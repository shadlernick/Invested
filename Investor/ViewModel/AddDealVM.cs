
using GalaSoft.MvvmLight.Command;
using Investor.Database;
using Investor.Implements;
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
        private DatabaseLists _databaseLists;

        private Deal deal;

        public static event EventHandler OnSelectedItemChanged;

        public ObservableCollection<Deal> Deals { get; set; }

        private RelayCommand addDeal;
        private RelayCommand editDeal;
        private RelayCommand removeDeal;

        private RelayCommand _delayEditMode;

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
        private Deal _selectedDeal;

        public Deal SelectedDeal
        {
            get { return _selectedDeal; }
            set
            {
                _selectedDeal = value;
                OnPropertyChanged("SelectedDeal");
                OnSelectedItemChanged?.Invoke(this, null);
            }
        }

        public Deal NewDeal
        {
            get
            {
                return deal;
            }
            set
            {
                deal = value;
                OnPropertyChanged("NewDeal");
            }
        }
        Builder DealBuilder;
        public AddDealVM()   //constructor
        {
            DealBuilder = new Builder();
            //_investorContext = investorContext;

            _databaseLists = DatabaseLists.GetDatabaseLists();

            Deals = _databaseLists.Deals;

            NewDeal = DealBuilder.BuildDealWithDate();

            addDeal = new RelayCommand(AddDeal);
            editDeal = new RelayCommand(EditDeal);
            removeDeal = new RelayCommand(RemoveDeal);

        }


        public void AddDeal()
        {
            Deals.Add(NewDeal);
            //_investorContext.Deals.Add(NewDeal);
            //_investorContext.SaveChanges();
            NewDeal = DealBuilder.BuildDealWithDate();
            //NewDeal = new Deal();
            //deal = new Deal();
        }

        public void EditDeal()
        {
            NewDeal = SelectedDeal;
            IsEnabled = false;

            editDeal = new RelayCommand(DelayEditMode);
        }

        public void RemoveDeal()
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

        public void DelayEditMode()
        {
            IsEnabled = true;
            //_investorContext.Deals.Find(NewDeal.Id).DateIn = NewDeal.DateIn;
            //_investorContext.Deals.Find(NewDeal.Id).DateOut = NewDeal.DateOut;
            //_investorContext.Deals.Find(NewDeal.Id).Profit = NewDeal.Profit;
            //_investorContext.Deals.Find(NewDeal.Id).Subscription = NewDeal.Subscription;
            //_investorContext.Deals.Find(NewDeal.Id).Sum = NewDeal.Sum;
            //_investorContext.SaveChanges();
            NewDeal = DealBuilder.BuildDealWithDate();

            editDeal = new RelayCommand(EditDeal);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //public override void DelayEditMode()
        //{
        //    IsEnabled = true;
        //    //_investorContext.Deals.Find(NewDeal.Id).DateIn = NewDeal.DateIn;
        //    //_investorContext.Deals.Find(NewDeal.Id).DateOut = NewDeal.DateOut;
        //    //_investorContext.Deals.Find(NewDeal.Id).Profit = NewDeal.Profit;
        //    //_investorContext.Deals.Find(NewDeal.Id).Subscription = NewDeal.Subscription;
        //    //_investorContext.Deals.Find(NewDeal.Id).Sum = NewDeal.Sum;
        //    //_investorContext.SaveChanges();
        //    NewDeal = DealBuilder.BuildDealWithDate();

        //    OnSelectedItemChanged -= base.SelectedChanged;
        //}
    }
}
