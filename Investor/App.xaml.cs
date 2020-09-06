using Investor.Database;
using Investor.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Investor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        Loading _loading;
        DatabaseLists _databaseLists;
        MainWindow _mainWindow;
        protected override void OnStartup(StartupEventArgs e)
        {
            //_loading = new Loading();


            //_loading.Show();
            //Task.Factory.StartNew(async () =>
            //{
            //    _databaseLists = DatabaseLists.GetDatabaseLists();
            //}).Wait();
            //_loading.Close();

            _mainWindow = new MainWindow();
            _mainWindow.Show();
            
        }
    }
}
