using Investor.Model;
using Investor.View;
using Investor.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Investor
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ManagementVM();
            careTaker = new CareTaker();
            Loaded += Window_Loaded;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            try
            {
                var outer = Task.Factory.StartNew(() => GetCurrencyAsync());
                outer.Wait();

                //localhost.MyService lms = new localhost.MyService();
                //bool isOnline = lms.Init(); //downloading db to local file
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private async void GetCurrencyAsync()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = await httpClient.GetStringAsync("https://openexchangerates.org/api/latest.json?app_id=d630a35d8e244c1ea13ce45743a597a6");


                    var currency = JsonConvert.DeserializeObject(json);

                    JObject jObject = JObject.Parse(currency.ToString());

                    Dispatcher.Invoke(() =>
                    {
                        Currency.Text = "$" + Math.Round((double)jObject["rates"]["UAH"], 2).ToString();
                        Currency.Text += " | €" + Math.Round((double)jObject["rates"]["UAH"] / (double)jObject["rates"]["EUR"], 2).ToString();
                        Currency.Text += " | ₽" + Math.Round((double)jObject["rates"]["UAH"] / (double)jObject["rates"]["RUB"], 2).ToString();
                    });
                }
                catch
                {
                    MessageBox.Show("Error connection, exchange is empty!");
                }

            }
        }
        
        //SQLiteConnection sqlConn = new SQLiteConnection(@"Data Source=" + Environment.CurrentDirectory + "\\InvestorDB.db");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!File.Exists(Environment.CurrentDirectory + "\\InvestorDB.db"))
            //{
            //    SQLiteConnection.CreateFile(Environment.CurrentDirectory + "\\InvestorDB.db");
            //}

            //string createClients = "CREATE TABLE IF NOT EXISTS Client(id INTEGER PRIMARY KEY AUTOINCREMENT, name varchar, info varchar, card varchar, phone varchar)";
            //string createDeals = "CREATE TABLE IF NOT EXISTS Deal(id INTEGER PRIMARY KEY AUTOINCREMENT, subscr varchar, sum int, profit int, status varchar, dateIn date, dateOut date)";
            //string createDealClient = "CREATE TABLE IF NOT EXISTS DealClient(id INTEGER PRIMARY KEY AUTOINCREMENT, dealId integer, clientId integer, sumIn integer, sumOut integer, info varchar)";

            //SQLiteCommand createClientsCommand = new SQLiteCommand(createClients, sqlConn);
            //SQLiteCommand createDealsCommand = new SQLiteCommand(createDeals, sqlConn);
            //SQLiteCommand createDealClientCommand = new SQLiteCommand(createDealClient, sqlConn);

            //sqlConn.Open();
            //createClientsCommand.ExecuteNonQuery();
            //createDealsCommand.ExecuteNonQuery();
            //createDealClientCommand.ExecuteNonQuery();
            //sqlConn.Close();
        }
        CareTaker careTaker;
        private void MakeMemento()
        {
            careTaker.History.Push(new Memento(this.DataContext));
        }
        private void OpenAddDealWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeMemento();
            DataContext = new AddDealVM();            
        }

        private void OpenAddHumanWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeMemento();
            DataContext = new AddHumanVM();
        }

        private void OpenAddContractWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeMemento();
            DataContext = new AddContractVM();
        }

        private void OpenManagementWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeMemento();
            DataContext = new ManagementVM();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = careTaker.History.Peek().ViewModelContext;
            }
            catch { }
        }
    }
}
