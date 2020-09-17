using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Model
{
    public class Builder
    {
        Deal deal;
        public Deal BuildDealWithDate()
        {
            deal = new Deal();
            deal.DateIn = DateTime.Now;
            deal.DateOut = DateTime.Now;
            return deal;
        }
    }

    public class Deal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string subscription;
        private int sum;
        private string profit;
        private string status;
        private DateTime dateIn;
        private DateTime dateOut;

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Subscription
        {
            get => subscription;
            set
            {
                subscription = value;
                OnPropertyChanged("Subscription");
            }
        }

        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public string Profit
        {
            get => profit;
            set
            {
                profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public DateTime DateIn
        {
            get => dateIn.Date;
            set
            {
                dateIn = value;
                OnPropertyChanged("DateIn");
            }
        }

        public DateTime DateOut
        {
            get => dateOut.Date;
            set
            {
                dateOut = value;
                OnPropertyChanged("DateOut");
            }
        }

        public static void Dispose(Deal deal)
        {
            deal.Id = 0;
            deal.Profit = null;
            deal.Status = null;
            deal.Subscription = null;
            deal.Sum = 0;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
