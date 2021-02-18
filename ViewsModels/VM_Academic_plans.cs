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
    class VM_Academic_plans:OnPropertyChangedClass
    {
        public CollegeEntities db { get; set; }
        private Academic_plans _current_academic_Plan ;
        public Academic_plans current_academic_Plan { get => _current_academic_Plan; set => SetProperty(ref _current_academic_Plan, value); }
        private ObservableCollection<Academic_plans> _academic_Plans;
        public ObservableCollection<Academic_plans> academic_Plans { get => _academic_Plans=new ObservableCollection<Academic_plans>(db.Academic_plans); set => SetProperty(ref _academic_Plans, value); }
        private RelayCommand _ED_academic_Plan;
        public RelayCommand ED_academic_Plan => _ED_academic_Plan ?? (_ED_academic_Plan = new RelayCommand(
            p =>
            {
                if (current_academic_Plan!=null)
                {
                    new Win_ED_academic_plan()
                    {
                        Title = $"Редактирование {current_academic_Plan.Name}",
                        DataContext=new MV_ED_acadimc_plan()
                        {
                            current_academic_Plan=current_academic_Plan,
                            db=db,
                            visibility_But_Del=Visibility.Visible,
                            visibility_But_Save=Visibility.Visible,
                            visibility_But_Add_1=Visibility.Visible,
                        }
                    }.ShowDialog();
                    refresh();
                }
            }
            ));
        private RelayCommand _add_academic_Plan;
        public RelayCommand add_academic_Plan => _add_academic_Plan ?? (_add_academic_Plan = new RelayCommand(
            p =>
            {
                    new Win_ED_academic_plan()
                    {
                        Title = $"Редактирование {current_academic_Plan.Name}",
                        DataContext = new MV_ED_acadimc_plan()
                        {                         
                            db = db,
                            visibility_But_Add = Visibility.Visible,                                                 
                        }

                    }.ShowDialog();
                refresh();
            }
            ));
        public void refresh()
        {
            academic_Plans = new ObservableCollection<Academic_plans>(db.Academic_plans);
        }
    }
}
