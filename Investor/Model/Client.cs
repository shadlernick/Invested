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
    ///<summary> - Класс клиента-пользователя услугами инвестора </summary>
    public class Client : INotifyPropertyChanged 
    {
        private int _id;
        private string _name;
        private string _info;
        private string _card;
        private string _phone;

        public Client()
        {
            //_id = Guid.NewGuid();
        }
        public Client(int id, string name, string info, string card, string phone)
        {
            this._id = id;
            this._info = info;
            this._name = name;
            this._card = card;
            this._phone = phone;
        }
        ///свойство параметра id, остальное по аналогии
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id 
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        ///<see public int Id/>
        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        ///<see public int Id/>
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        ///<see public int Id/>
        public string Card
        {
            get { return _card; }
            set
            {
                _card = value;
                OnPropertyChanged("Card");
            }
        }

        ///<see public int Id/>
        public string Phone
        {
            get { return _phone; }
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
