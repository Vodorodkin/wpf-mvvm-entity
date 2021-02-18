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
    /// Логика взаимодействия для Users_ed.xaml
    /// </summary>
    public partial class Win_Users_ed : Window
    {
        public Win_Users_ed()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if ((Users_ed_Vm)DataContext!=null&& ((Users_ed_Vm)DataContext).password!=null)
            {

                    passwd.Password = ((Users_ed_Vm)DataContext).password;
                    rep_passswd.Password = ((Users_ed_Vm)DataContext).password;
                ((Users_ed_Vm)DataContext).Close_Win = new Action(() => Close());

            }
        }

        private void passwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((Users_ed_Vm)DataContext != null)
            {
                ((Users_ed_Vm)DataContext).password = passwd.Password;
                ((Users_ed_Vm)DataContext).repeat_password = rep_passswd.Password;
            }
        }
    }
}
