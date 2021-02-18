using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Infrastructure;
using PP_12._2020.Models;
using PP_12._2020.Views;
using PP_12._2020.DataContainer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Runtime.CompilerServices;

namespace PP_12._2020.ViewsModels
{
    class Users_ed_Vm:OnPropertyChangedClass
    {
        string str = "Подтверждение";
        public string title;
        public Action Close_Win;
        bool check()

        { 
            return (
            current_user.First_name.Length > 0 &&
            current_user.Last_name.Length > 0 &&
            current_user.Middle_name.Length > 0 &&
            current_user.Phone.Length > 0 &&
            current_user.User_types != null &&
            password !=null &&
            login.Length !=null &&
            repeat_password.Length > 0 &&
            password == repeat_password            
            ) ;
        }
        public CollegeEntities db { get; set; }
        public User constain_user;
        private User _current_user = new User()
        { 
            First_name="",
            Last_name="",
            Middle_name="",
            Phone ="",
        };
        public User current_user { get => _current_user; set => SetProperty(ref _current_user, value); }
        public ObservableCollection<User_types> user_Types { get => new ObservableCollection<User_types>(db.User_types); }
        private Visibility _visibility_But_Save = Visibility.Collapsed;
        public Visibility visibility_But_Save { get => _visibility_But_Save; set => SetProperty(ref _visibility_But_Save, value); }
        private Visibility _visibility_But_Del = Visibility.Collapsed;
        public Visibility visibility_But_Del { get => _visibility_But_Del; set => SetProperty(ref _visibility_But_Del, value); }
        private Visibility _visibility_But_Add = Visibility.Collapsed;
        public Visibility visibility_But_Add { get => _visibility_But_Add; set => SetProperty(ref _visibility_But_Add, value); }
        private string _login = "";
        public string login { get => _login; set => SetProperty(ref _login, value);
    }
        private string _password = "";
        public string password { get => _password; set => SetProperty(ref _password, value); }
        private string _repeat_password = "";
        public string repeat_password { get => _repeat_password; set => SetProperty(ref _repeat_password, value); }

        private RelayCommand _del_User;
        public RelayCommand del_User => _del_User ?? (_del_User = new RelayCommand(
            p=>
            {
                try
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить пользователя {current_user.FIO}", $"{str}", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {

                        db.Users.Remove(current_user);
                        db.SaveChanges();
                        MessageBox.Show("Успешно");
                        Close_Win();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            }
            ));
        private RelayCommand _save_User;
        public RelayCommand save_User => _save_User ?? (_save_User = new RelayCommand(
            p =>

            {
                try
                {
                    if (current_user!=null)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show($"Внести изменения в пользователе {current_user.FIO}", $"{str}", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                        db.SaveChanges();
                        MessageBox.Show("Успешно");                       
                        Close_Win();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка данных");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");

                }
            },
            p =>check()
            ));
        private RelayCommand _add_User;
        public RelayCommand add_User => _add_User ?? (_add_User = new RelayCommand(
            p =>
            {
                try
                {
                    if (current_user != null)
                    {
                        db.Users.Add(current_user);
                        db.Logins_and_passwords.Add(new Logins_and_passwords()
                        {
                            Password = password,
                            Login = login,
                            User = current_user,
                        });
                        db.SaveChanges();
                        MessageBox.Show("Успешно");
                
                        Close_Win();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка данных");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p=>check()        
            ));
        

    }
}
