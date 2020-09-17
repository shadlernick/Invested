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
    public class Client : INotifyPropertyChanged 
    {
        private int _id;
        private string _name;
        private string _info;
        private string _card;
        private string _phone;

        public Client(){}
        public Client(int id, string name, string info, string card, string phone)
        {
            this._id = id;
            this._info = info;
            this._name = name;
            this._card = card;
            this._phone = phone;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        public string Card
        {
            get => _card;
            set
            {
                _card = value;
                OnPropertyChanged("Card");
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
