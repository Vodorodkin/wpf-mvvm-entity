using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Infrastructure;
using PP_12._2020.Models;
using PP_12._2020.Views;
using PP_12._2020.DataContainer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Runtime.CompilerServices;
 using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using System.IO;

namespace PP_12._2020.ViewsModels
{
    class MV_Estimates:OnPropertyChangedClass
    {
        public CollegeEntities db { get; set; }
        RelayCommand _command1;
        public RelayCommand command1 => _command1 ?? (_command1 = new RelayCommand(
            p=>
            {
                


                

            }
            ));
        RelayCommand _command2;
        public RelayCommand command2 => _command2 ?? (_command2 = new RelayCommand(
            p =>
            {

            }
            ));
        RelayCommand _command3;
        public RelayCommand command3 => _command3 ?? (_command3 = new RelayCommand(
            p =>
            {

            }
            ));
    }
}
