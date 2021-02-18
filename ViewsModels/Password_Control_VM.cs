using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PP_12._2020.Infrastructure;
using PP_12._2020.Models;
using PP_12._2020.Views;
using PP_12._2020.DataContainer;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Office.Interop;
using EPPlusTest.Table;
using OfficeOpenXml;

namespace PP_12._2020.ViewsModels
{
    public class Password_Control_VM:OnPropertyChangedClass
    {

        public Win_Login win_Login;
        CollegeEntities db = new CollegeEntities();
        private string _login;
        public string login { get => _login; set => SetProperty(ref _login, value); }
        private string _password;
        public string password { get => _password; set => SetProperty(ref _password, value); }
        public Action HideAction { get; set; }
        public string cap { get; set; } = Methods.newstrCapcha();
        Captcha_VM _Captcha_VM;
        public Captcha_VM Captcha_VM { get => _Captcha_VM; set => SetProperty(ref _Captcha_VM, value); }
        Visibility _visibility_Captcha = Visibility.Collapsed;
        public Visibility visibility_Captcha { get => _visibility_Captcha = Visibility.Collapsed; set => SetProperty(ref _visibility_Captcha, value); }

        public RelayCommand _Authorization;
        public RelayCommand Authorization => _Authorization ?? (_Authorization = new RelayCommand(
            p =>
            {
                
                    var user = Methods.Authorization(login, password, db);
                    if (user!=null)
                    {
                        Locator.Data.authorizationDate = DateTime.Now;

                    new Win_main()
                    {
                        Title="Главное окно",
                        DataContext = new Main_Win_VM()
                        {
                            win_Login = win_Login,
                            db = db,
                            user = user,
                            main_Control_MV = new Main_Control_MV()
                            {
                                users_Control_VM = new MV_Users_Control()
                                {
                                    db = db,
                                },
                                MV_Login_Log = new MV_Login_Log()
                                {
                                    db = db,
                                    login_Log = new ObservableCollection<Login_log>(db.Login_log)
                                },
                                vM_Academic_Plans = new VM_Academic_plans()
                                {
                                    db = db,
                                },
                                mV_Estimates = new MV_Estimates()
                                {
                                    db=db,
                                },                              
                                VM_Groups=new VM_Groups()
                                {
                                    db=db,
                                }
                            },
                        }
                    }.Show();
                        
                        user = null;
                        HideAction();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные", "Логин или пароль неверные");
                    if (Locator.Data.authorizationAttempts>0)
                    {
                        Captcha_VM = new Captcha_VM()
                        {
                            visibility_Captcha = Visibility.Visible,
                            strCapcha = cap,

                        };
                        visibility_Captcha = Visibility.Visible;
                    }
                    Locator.Data.authorizationAttempts++;

                    }               
            },
            p=>login!=null&&password!=null
            ));
        private RelayCommand _showPas;
        public RelayCommand ShowPas => _showPas ?? (_showPas = new RelayCommand(
            p =>
            {
                Methods.excel(new ObservableCollection<Login_log> (db.Login_log));
                Methods.prf(new ObservableCollection<Login_log>(db.Login_log));
            }
            ));
        
    }
}
