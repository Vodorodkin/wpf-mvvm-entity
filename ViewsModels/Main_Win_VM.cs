using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Infrastructure;
using PP_12._2020.ViewsModels;
using PP_12._2020.Models;
using System.ComponentModel;
using System.Windows;
using PP_12._2020.Views;
using PP_12._2020.DataContainer;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace PP_12._2020.ViewsModels
{
    class Main_Win_VM:OnPropertyChangedClass
    {
        private Main_Control_MV _main_Control_MV;
        public Main_Control_MV main_Control_MV { get => _main_Control_MV; set => SetProperty(ref _main_Control_MV, value); }
        
        public Win_Login win_Login;
        private User _user;
        public User user { get => _user; set => SetProperty(ref _user, value); }
        public CollegeEntities db { get; set; }       
        DateTime _authorizationDate;
        public DateTime authorizationDate { get => _authorizationDate; set => SetProperty(ref _authorizationDate, value); }
        DateTime _logOutDate;
        public DateTime logOutDate { get => _logOutDate; set => SetProperty(ref _logOutDate, value); }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show($"После выхода из аккаунта, вы не сможете войти в этот аккаунт {1} минут","Выйти?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                db.Login_log.Add(new Login_log
                {
                    ID_user = user.ID,
                    Login_date = Locator.Data.authorizationDate,
                    Logout_date = DateTime.Now
                });
                db.SaveChanges();
                e.Cancel = false;
                win_Login.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void Image_MouseLeftButtonDown()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                user.Image = ImageToByteArray(Image.FromFile(openDialog.FileName));
                db.SaveChanges();

            }
            catch (OutOfMemoryException ex)
            {
                System.Windows.MessageBox.Show("Ошибка чтения картинки");
                return;
            }
            refresh();
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public void refresh()
        {
            user = db.Users.FirstOrDefault(u=>u.ID== user.ID);
        }
    }
}
