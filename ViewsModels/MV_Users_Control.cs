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

namespace PP_12._2020.ViewsModels
{
    class MV_Users_Control : OnPropertyChangedClass
    {
        public Action Close_Win;
        public CollegeEntities db { get; set; }
        ObservableCollection<User> _users;
        public ObservableCollection<User> users { get => _users=new ObservableCollection<User>(db.Users); set=>SetProperty(ref _users,value); }
        private User _current_user;
        public User current_user { get => _current_user; set => SetProperty(ref _current_user, value); }    


        private User_types _selected_User_type;
        public User_types selected_User_type { get => _current_user.User_types; set => SetProperty(ref _selected_User_type, value); }
        private RelayCommand _ED_current_user;
        public RelayCommand ED_current_user => _ED_current_user ?? (_ED_current_user = new RelayCommand(
            p =>
            {
                if (current_user!=null)
                {
                    new Win_Users_ed()
                    {
                        Title = $"Редактирование пользователя {current_user.FIO}",
                        DataContext = new Users_ed_Vm()
                        {
                            db = db,                            
                            
                            current_user=current_user,
                            login = _current_user.Logins_and_passwords.Select(lap => lap.Login).FirstOrDefault(),
                            password = _current_user.Logins_and_passwords.Select(lap => lap.Password).FirstOrDefault(),
                            repeat_password = _current_user.Logins_and_passwords.Select(lap => lap.Password).FirstOrDefault(),
                            visibility_But_Save = System.Windows.Visibility.Visible,
                            visibility_But_Del = System.Windows.Visibility.Visible,
                        }
                    }.ShowDialog();
                    refresh();
                }
            },
            p => current_user!=null
            ));
        private RelayCommand _add_user;
        public RelayCommand add_user => _add_user ?? (_add_user = new RelayCommand(
            p =>
            {               
                if (current_user != null)
                {

                    new Win_Users_ed()
                    {
                        Title = $"Создание нового пользователя",
                        DataContext = new Users_ed_Vm()
                        {
                            db = db,
                            visibility_But_Add=System.Windows.Visibility.Visible, 
                            
                        }
                    }.ShowDialog();
                    refresh();
                }
            },
            p => current_user != null
            ));
        public void refresh()
        {
            users = new ObservableCollection<User>(db.Users);
        }

    }
}
