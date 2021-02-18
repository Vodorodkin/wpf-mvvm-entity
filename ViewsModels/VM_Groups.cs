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
    class VM_Groups:OnPropertyChangedClass
    {
        public CollegeEntities db { get; set; }
        User _current_student_in_group;
        User _current_student_all;
        public User current_student_in_group { get => _current_student_in_group; set => SetProperty(ref _current_student_in_group, value); }
        public User current_student_all { get => _current_student_all; set => SetProperty(ref _current_student_all, value); }

        Group _current_group;
        public Group current_group { get => _current_group; set => SetProperty(ref _current_group, value); }
        ObservableCollection<Group> _groups;
        public ObservableCollection<Group> groups { get => _groups = new ObservableCollection<Group>(db.Groups); set => SetProperty(ref _groups, value); }
        ObservableCollection<User> _users;
        public ObservableCollection<User> users { get => _users = new ObservableCollection<User>(db.Users); set => SetProperty(ref _users, value); }
        ObservableCollection<User> _students;
        public ObservableCollection<User> students { get => _students = new ObservableCollection<User>(users.Where(u=>u.User_types.ID==4&&u.ID_Group==null)); set => SetProperty(ref _students, value); }
        ObservableCollection<User> _students_in_group;
        public ObservableCollection<User> students_in_group { get => _students_in_group = new ObservableCollection<User>(users.Where(u => u.User_types.ID == 4)); set => SetProperty(ref _students_in_group, value); }
        private RelayCommand _right;
        public RelayCommand right => _right ?? (_right = new RelayCommand(
            p =>
            {
                students.Remove(current_student_all);
                students_in_group.Add(current_student_all);
            },
            p => current_student_all != null
            ));
        private RelayCommand _left;
        public RelayCommand left => _left ?? (_left = new RelayCommand(
            p =>
            {
                students_in_group.Remove(current_student_in_group);
                students_in_group.Add(current_student_in_group);
            },
            p => current_student_in_group != null
            ));


    }
}
