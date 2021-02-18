using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PP_12._2020.ViewsModels;

namespace PP_12._2020.Views
{
    /// <summary>
    /// Логика взаимодействия для Control_ED_academic_plan.xaml
    /// </summary>
    public partial class Win_ED_academic_plan : Window
    {
        public Win_ED_academic_plan()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((MV_ED_acadimc_plan)DataContext).Close_Win = new Action(()=> Close());
        }
    }
}
