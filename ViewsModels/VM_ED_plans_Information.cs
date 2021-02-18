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
    class VM_ED_plans_Information : OnPropertyChangedClass
    {
        public Action Close_Win;
        public CollegeEntities db { get; set; }
        private Academic_plans _current_academic_Plan = new Academic_plans()
        {
            Duration = 0,
            Name = "",
        };
        public Academic_plans current_academic_Plan { get => _current_academic_Plan; set => SetProperty(ref _current_academic_Plan, value); }
        ObservableCollection<int> _semesters = new ObservableCollection<int>();
        private Visibility _visibility_But_Save = Visibility.Collapsed;
        public Visibility visibility_But_Save { get => _visibility_But_Save; set => SetProperty(ref _visibility_But_Save, value); }
        private Visibility _visibility_But_Del = Visibility.Collapsed;
        public Visibility visibility_But_Del { get => _visibility_But_Del; set => SetProperty(ref _visibility_But_Del, value); }
        private Visibility _visibility_But_Add = Visibility.Collapsed;
        public Visibility visibility_But_Add { get => _visibility_But_Add; set => SetProperty(ref _visibility_But_Add, value); }
        private Visibility _visibility_But_Add_1 = Visibility.Collapsed;
        public Visibility visibility_But_Add_1 { get => _visibility_But_Add_1; set => SetProperty(ref _visibility_But_Add_1, value); }
        public ObservableCollection<int> semesters
        {
            get
            {
                for (int i = 0; i <= current_academic_Plan.Duration; i++)
                {
                    _semesters.Add(i);
                }
                return _semesters;
            }
            set => SetProperty(ref _semesters, value);

        }
        private Plan_information _current_plans_Information = new Plan_information();
        public Plan_information current_plans_Information
        {
            get => _current_plans_Information; set
            {
                SetProperty(ref _current_plans_Information, value);
            }
        }
        public ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> subjects { get => new ObservableCollection<Subject>(db.Subjects); set => SetProperty(ref _subjects, value); }

        private RelayCommand _add;
        public RelayCommand add => _add ?? (_add = new RelayCommand(
            p =>
            {
                try { 
                MessageBoxResult messageBoxResult = MessageBox.Show($"Внести изменения?", "", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.Plan_information.Add(new Plan_information
                    {
                        Academic_plans = current_academic_Plan,
                        Semester = current_plans_Information.Semester,
                        Subject = current_plans_Information.Subject
                    });
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Close_Win();
                }
            }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p =>
            (
            true
            )
            ));
        private RelayCommand _save;
        public RelayCommand save => _save ?? (_save = new RelayCommand(
            p =>
            {
                try { 
                MessageBoxResult messageBoxResult = MessageBox.Show($"Внести изменения?", "", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Close_Win();
                }
            }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p =>
            (
            current_plans_Information.Subject!=null&&current_plans_Information.Semester>0
            )
            ));
        private RelayCommand _del;
        public RelayCommand del => _del ?? (_del = new RelayCommand(
            p =>
            {
                try { 
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить?","", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.Plan_information.Remove(current_plans_Information);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Close_Win();
                }
            }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p =>
            (
            true
            )
            ));
        private RelayCommand _add_s;
        public RelayCommand add_s => _add_s ?? (_add_s = new RelayCommand(
            p =>
            {
                new Win_add_subjects()
                {
                    Title = $"Добавление",
                    DataContext = new VM_Win_Subjects()
                    {
                        db = db,                        
                    }

                }.ShowDialog();
                refresh();
            }
            ));
        public void refresh()
        {
            subjects = new ObservableCollection<Subject>(db.Subjects);
        }

    }
}
