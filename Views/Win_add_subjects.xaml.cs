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
    /// Логика взаимодействия для Win_add_subjects.xaml
    /// </summary>
    public partial class Win_add_subjects : Window
    {
        public Win_add_subjects()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (((VM_Win_Subjects)DataContext!=null))
                {
                ((VM_Win_Subjects)DataContext).Close_Win = new Action(() => Close());
            }
                
        }
    }
}
