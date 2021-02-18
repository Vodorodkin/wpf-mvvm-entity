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
using Newtonsoft.Json;

namespace PP_12._2020.ViewsModels
{
    class MV_Login_Log:OnPropertyChangedClass
    {
        public CollegeEntities db { get; set; }
        private ObservableCollection<Login_log> _login_Log;
        public ObservableCollection<Login_log> login_Log { get => _login_Log; set => SetProperty(ref _login_Log, value); }
        private ObservableCollection<Login_log> _selected_login_Log;
        public ObservableCollection<Login_log> selected_login_Log { get => _selected_login_Log; set => SetProperty(ref _selected_login_Log, value); } 
        ObservableCollection<User> _users;
        public ObservableCollection<User> users { get => _users = new ObservableCollection<User>(db.Users); set => SetProperty(ref _users, value); }
        private User _current_user;
        public User current_user { get => _current_user; set => SetProperty(ref _current_user, value); }

        private DateTime _start_date = DateTime.Now;
        public DateTime start_date { get => _start_date; set => SetProperty(ref _start_date, value); }
        private DateTime _finish_date = DateTime.Now;
        public DateTime finish_date { get => _finish_date; set => SetProperty(ref _finish_date, value); }

        private RelayCommand _apply;
        private RelayCommand _undo;
        public RelayCommand apply => _apply ?? (_apply = new RelayCommand(
            p=>
            {
                if (current_user!=null)
                login_Log = new ObservableCollection<Login_log>(db.Login_log.Where(ll=>ll.ID_user==current_user.ID&&ll.Login_date>=start_date&&ll.Logout_date<=finish_date));
                else
                    login_Log = new ObservableCollection<Login_log>(db.Login_log.Where(ll => ll.Login_date >= start_date && ll.Logout_date <= finish_date));
            },
            p=>(start_date<=finish_date
)            ));
        public RelayCommand undo => _undo ?? (_undo = new RelayCommand(
            p=>
            {
                current_user = null;
                start_date = DateTime.Now;
                finish_date = DateTime.Now;
                login_Log = new ObservableCollection<Login_log>(db.Login_log);
            }
            ));


    }
}
