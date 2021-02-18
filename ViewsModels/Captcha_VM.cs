using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PP_12._2020.Infrastructure;

namespace PP_12._2020.ViewsModels
{
    public class Captcha_VM : OnPropertyChangedClass
    {
        public string cap;
        public Captcha_VM()
        {
            rnd_c();
        }
        Visibility _visibility_Captcha = Visibility.Collapsed;
        public Visibility visibility_Captcha { get => _visibility_Captcha= Visibility.Collapsed; set => SetProperty(ref _visibility_Captcha, value); }
        private int _l1x1 = 0;
        private int _l1x2 = 0;
        private int _l1y1 = 0;
        private int _l1y2 = 0;

        private int _l2x1 = 0;
        private int _l2x2 = 0;
        private int _l2y1 = 0;
        private int _l2y2 = 0;

        private int _l3x1 = 0;
        private int _l3x2 = 0;
        private int _l3y1 = 0;
        private int _l3y2 = 0;

        private int _l4x1 = 0;
        private int _l4x2 = 0;
        private int _l4y1 = 0;
        private int _l4y2 = 0;
        private int _width;
        private int _height;
        private string _strCapcha;
        private string _Capcha;
        private int _Canvas_Left;
        public int l1x1 { get => _l1x1; set => SetProperty(ref _l1x1, value); }
        public int l1x2 { get => _l1x2; set => SetProperty(ref _l1x2, value); }
        public int l1y1 { get => _l1y1; set => SetProperty(ref _l1y1, value); }
        public int l1y2 { get => _l1y2; set => SetProperty(ref _l1y2, value); }

        public int l2x1 { get => _l2x1; set => SetProperty(ref _l2x1, value); }
        public int l2x2 { get => _l2x2; set => SetProperty(ref _l2x2, value); }
        public int l2y1 { get => _l2y1; set => SetProperty(ref _l2y1, value); }
        public int l2y2 { get => _l2y2; set => SetProperty(ref _l2y2, value); }

        public int l3x1 { get => _l3x1; set => SetProperty(ref _l3x1, value); }
        public int l3x2 { get => _l3x2; set => SetProperty(ref _l3x2, value); }
        public int l3y1 { get => _l3y1; set => SetProperty(ref _l3y1, value); }
        public int l3y2 { get => _l3y2; set => SetProperty(ref _l3y2, value); }

        public int l4x1 { get => _l4x1; set => SetProperty(ref _l4x1, value); }
        public int l4x2 { get => _l4x2; set => SetProperty(ref _l4x2, value); }
        public int l4y1 { get => _l4y1; set => SetProperty(ref _l4y1, value); }
        public int l4y2 { get => _l4y2; set => SetProperty(ref _l4y2, value); }
        public int width { get => _width; set => SetProperty(ref _width, value); }
        public int height { get => _height; set => SetProperty(ref _height, value); }
        public string strCapcha { get => _strCapcha; set => SetProperty(ref _strCapcha, value); }
        public int Canvas_Left { get => _Canvas_Left; set => SetProperty(ref _Canvas_Left, value); }

        
        public string Capcha { get => _Capcha; set => SetProperty(ref _Capcha, value); }

        private RelayCommand _showPas;
        public RelayCommand ShowPas => _showPas ?? (_showPas = new RelayCommand(
            p =>
            {
                rnd_c();
            }
            ));
        public void rnd_c()
        {
            Random random = new Random();
            int w = 60;
            int h = 40;
            width = w;
            height = h;
            strCapcha = Methods.newstrCapcha();
            l1x1 = random.Next(0, w);
            l1x2 = random.Next(0, w);
            l1y1 = random.Next(0, h);
            l1y2 = random.Next(0, h);
            l2x1 = random.Next(0, w);
            l2x2 = random.Next(0, w);
            l2y1 = random.Next(0, h);
            l2y2 = random.Next(0, h);
            l3x1 = random.Next(0, w);
            l3x2 = random.Next(0, w);
            l3y1 = random.Next(0, h);
            l3y2 = random.Next(0, h);
            l4x1 = random.Next(0, w);
            l4x2 = random.Next(0, w);
            l4y1 = random.Next(0, h);
            l4y2 = random.Next(0, h);
        }
    }
}
