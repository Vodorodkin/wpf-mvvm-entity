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

namespace PP_12._2020.Views
{
    /// <summary>
    /// Логика взаимодействия для Win_Login.xaml
    /// </summary>
    public partial class Win_Login : Window
    {
        public Win_Login()
        {
            InitializeComponent();
        }
        private void Win_Loaded(object sender, RoutedEventArgs e)
        {

            if (DataContext != null)
            {
                ((dynamic)this.DataContext).password_Control_VM.HideAction = new Action(() => this.Hide());
                ((dynamic)this.DataContext).password_Control_VM.win_Login = this;
            }

        }
    }
}
