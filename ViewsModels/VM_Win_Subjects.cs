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

namespace PP_12._2020.ViewsModels
{
    class VM_Win_Subjects:OnPropertyChangedClass
    {
        public Action Close_Win;
        public CollegeEntities db { get; set; }
        public Subject _subject = new Subject()
        {
            Name="",

        };
        public Subject subject { get => _subject; set => SetProperty(ref _subject, value); }
        public ObservableCollection< User> users { get => new ObservableCollection<User>(db.Users.Where(u => u.User_types.ID == 3)); }
        RelayCommand _add;
        public RelayCommand add => _add ?? (_add = new RelayCommand(
            p=>
            {
                try
                {
                    db.Subjects.Add(subject);
                        db.SaveChanges();
                        MessageBox.Show("Успешно");
                        Close_Win();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p=>
            (subject.Name.Length>0&&subject.User!=null)
            ));
    }
}
