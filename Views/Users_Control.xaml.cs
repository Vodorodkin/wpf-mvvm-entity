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
    /// Логика взаимодействия для MV_Users_Control.xaml
    /// </summary>
    public partial class Users_Control : UserControl
    {
        public Users_Control()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if ((MV_Users_Control)DataContext!=null)
            {
                ((MV_Users_Control)DataContext).refresh();
            }
        }
    }
}
