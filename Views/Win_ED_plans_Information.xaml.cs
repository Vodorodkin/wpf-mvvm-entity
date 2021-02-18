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
using System.Windows.Shapes;
using PP_12._2020.ViewsModels;

namespace PP_12._2020.Views
{
    /// <summary>
    /// Логика взаимодействия для Win_ED_plans_Information.xaml
    /// </summary>
    public partial class Win_ED_plans_Information : Window
    {
        public Win_ED_plans_Information()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if ((VM_ED_plans_Information)DataContext != null)
            {

                ((VM_ED_plans_Information)DataContext).Close_Win = new Action(() => Close());

            }
        }
    }
}
