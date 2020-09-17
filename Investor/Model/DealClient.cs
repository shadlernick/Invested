using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Model
{
    public class DealClient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;

        private int dealId;
        private string dealSubs;
        private string clientName;
        private int clientId;
        private int sumIn;
        private string info;

        public string DealSubs
        {
            get => dealSubs;
            set
            {
                dealSubs = value;
                OnPropertyChanged("DealSubs");
            }
        }

        public string ClientName
        {
            get => clientName;
            set
            {
                clientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        public int SumIn
        {
            get => sumIn;
            set
            {
                sumIn = value;
                OnPropertyChanged("SumIn");
            }
        }

        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
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
        public int DealId
        {
            get => dealId;
            set
            {
                dealId = value;
                OnPropertyChanged("DealId");
            }
        }
        public int ClientId
        {
            get => clientId;
            set
            {
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }

        public void Dispose(DealClient dealClient)
        {
            dealClient.Id = 0;
            dealClient.Info = null;
            dealClient.SumIn = 0;
            dealClient.ClientId = 0;
            dealClient.ClientName = null;
            dealClient.DealId = 0;
            dealClient.DealSubs = null;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
