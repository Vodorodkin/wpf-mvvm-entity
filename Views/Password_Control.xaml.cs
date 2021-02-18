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

namespace PP_12._2020.Views
{
    /// <summary>
    /// Логика взаимодействия для Password_Control.xaml
    /// </summary>
    public partial class Password_Control : UserControl
    {
       
        public Window window { get; set; }
        public Password_Control()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                ((dynamic)DataContext).password = ((PasswordBox)sender).Password;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            if (DataContext!=null)
            {
               
                pwb.Password = ((dynamic)DataContext).password;
            }
                
        }
    }
}
