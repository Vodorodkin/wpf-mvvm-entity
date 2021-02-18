using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Infrastructure;
using PP_12._2020.ViewsModels;

namespace PP_12._2020.ViewsModels
{
    class Login_Win_VM:OnPropertyChangedClass
    {
        private Password_Control_VM _password_Control_VM;
        public Password_Control_VM password_Control_VM { get => _password_Control_VM; set => SetProperty(ref _password_Control_VM, value); }
    }
}
