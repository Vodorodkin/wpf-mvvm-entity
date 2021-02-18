using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PP_12._2020.Models;
using PP_12._2020.ViewsModels;


namespace PP_12._2020.Views
{
    /// <summary>
    /// Логика взаимодействия для Win_main.xaml
    /// </summary>
    public partial class Win_main : Window
    {
        User user = new User();
        public Win_main()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((dynamic)DataContext).OnWindowClosing(sender, e);
        }
        private void Win_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                //((Win_main)this.DataContext).password_Control_VM.HideAction = new Action(() => this.Close());
                //((dynamic)this.DataContext).password_Control_VM.win_Login = this;
                user = ((Main_Win_VM)DataContext).user;
            }

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Main_Win_VM)DataContext).Image_MouseLeftButtonDown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Main_Win_VM)DataContext).Image_MouseLeftButtonDown();
        }
    }
}
