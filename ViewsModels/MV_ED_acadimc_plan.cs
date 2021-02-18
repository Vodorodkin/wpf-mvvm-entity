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
    class MV_ED_acadimc_plan : OnPropertyChangedClass
    {
        public Action Close_Win;
        public CollegeEntities db { get; set; }
        ObservableCollection<int> _semesters = new ObservableCollection<int>();
        public ObservableCollection<int> semesters
        {
            get
            {
                for (int i = 0; i <=current_academic_Plan.Duration; i++)
                {
                    _semesters.Add(i);
                }
                return _semesters;
            }
            set => SetProperty(ref _semesters, value);

        }
        private Academic_plans _current_academic_Plan = new Academic_plans()
        {
            Duration = 0,
            Name = "",
        };

        public Academic_plans current_academic_Plan { get => _current_academic_Plan; set => SetProperty(ref _current_academic_Plan, value); }
        public ObservableCollection<Subject> subjects { get => new ObservableCollection<Subject>(db.Subjects); }
        private ObservableCollection<Plan_information> _plans_Information = new ObservableCollection<Plan_information>();
        public ObservableCollection<Plan_information> plans_Information { get => _plans_Information=new ObservableCollection<Plan_information>( db.Plan_information.Where(pi=>pi.ID_AP==current_academic_Plan.ID)); set => SetProperty(ref _plans_Information, value); }

        private Plan_information _current_plans_Information = new Plan_information();
        public Plan_information current_plans_Information { get => _current_plans_Information; set 
                {
                SetProperty(ref _current_plans_Information, value);
            }  }
        private Visibility _visibility_But_Save = Visibility.Collapsed;
        public Visibility visibility_But_Save { get => _visibility_But_Save; set => SetProperty(ref _visibility_But_Save, value); }
        private Visibility _visibility_But_Del = Visibility.Collapsed;
        public Visibility visibility_But_Del { get => _visibility_But_Del; set => SetProperty(ref _visibility_But_Del, value); }
        private Visibility _visibility_But_Add = Visibility.Collapsed;
        public Visibility visibility_But_Add { get => _visibility_But_Add; set => SetProperty(ref _visibility_But_Add, value); }
        private Visibility _visibility_But_Add_1 = Visibility.Collapsed;
        public Visibility visibility_But_Add_1 { get => _visibility_But_Add_1; set => SetProperty(ref _visibility_But_Add_1, value); }
        private RelayCommand _add_academic_Plan;
        public RelayCommand add_academic_Plan => _add_academic_Plan ?? (_add_academic_Plan = new RelayCommand(
            p=>
            {
                try
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Добавить?","", MessageBoxButton.YesNo);
                    if (messageBoxResult==MessageBoxResult.Yes)
                    {
                        db.Academic_plans.Add(current_academic_Plan);
                        foreach (Plan_information pi in plans_Information)
                        {
                            pi.ID_AP=current_academic_Plan.ID;
                            db.Plan_information.Add(pi);
                        }
                        db.SaveChanges();
                        MessageBox.Show("Успешно");
                        Close_Win();
                    }
                    else
                    {
                        MessageBox.Show("Отмена");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            }    ,
            p=>
            (
            current_academic_Plan.Name.Length>0&&current_academic_Plan.Duration>0
            )
            ));
        private RelayCommand _ED_plans_Information;
        public RelayCommand ED_plans_Information => _ED_plans_Information ?? (_ED_plans_Information = new RelayCommand(
            p =>
            {
                try
                {
                    new Win_ED_plans_Information()
                    {
                        Title = $"Редактирование",
                        DataContext = new VM_ED_plans_Information()
                        {
                            db = db,
                            current_academic_Plan = current_academic_Plan,
                            current_plans_Information=current_plans_Information,
                            visibility_But_Del=Visibility.Visible,
                            visibility_But_Save=Visibility.Visible,
                        }

                    }.ShowDialog();
                    refresh();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            }
            ));

        private RelayCommand _del_academic_Plan;
        public RelayCommand del_academic_Plan => _del_academic_Plan ?? (_del_academic_Plan = new RelayCommand(
            p =>
            {
                try {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить?", "", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.Academic_plans.Remove(current_academic_Plan);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Close_Win();
                }
                else
                {
                    MessageBox.Show("Отмена");
                }
            }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            },
            p =>
            (
            current_academic_Plan!=null
            )));
        private RelayCommand _save_academic_Plan;
        public RelayCommand save_academic_Plan => _save_academic_Plan ?? (_save_academic_Plan = new RelayCommand(
            p =>
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Сохранить изменения??", "", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Close_Win();
                }
                else
                {
                    MessageBox.Show("Отмена");
                }
            },
            p =>
            (
            current_academic_Plan != null
            )));
        private RelayCommand _add;
        public RelayCommand add => _add ?? (_add = new RelayCommand(
            p =>
            {
                try
                {
                    new Win_ED_plans_Information()
                    {
                        Title = $"Добавление",
                        DataContext = new VM_ED_plans_Information()
                        {
                            db = db,
                            current_academic_Plan = current_academic_Plan,
                           visibility_But_Add = Visibility.Visible,

                        }

                    }.ShowDialog();
                    refresh();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }
            }
            ));

        public void refresh()
        {
            plans_Information = new ObservableCollection<Plan_information>(db.Plan_information);
        }

    }
}
