using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PP_12._2020.Views;
using PP_12._2020.ViewsModels;

namespace PP_12._2020
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new Win_Login()
            {
                DataContext = new Login_Win_VM()
                {
                    password_Control_VM = new Password_Control_VM()
                    {
                        //login = "admin",
                        //password = "admin",
                    }
                },
                Width = 300,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title="Авторизация",
            }.Show();
            
            
        }
    }
}
