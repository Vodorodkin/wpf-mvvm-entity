using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_12._2020.Infrastructure;
using PP_12._2020.Models;
using PP_12._2020.Views;
using PP_12._2020.DataContainer;

namespace PP_12._2020.ViewsModels
{
    class Main_Control_MV:OnPropertyChangedClass
    {
        public CollegeEntities db { get; set; }
        public Win_Login win_Login;
        private MV_Users_Control _users_Control_VM;
        public MV_Users_Control users_Control_VM { get => _users_Control_VM; set => SetProperty(ref _users_Control_VM, value); }
        private MV_Login_Log _MV_Login_Log;
        public MV_Login_Log MV_Login_Log { get => _MV_Login_Log; set => SetProperty(ref _MV_Login_Log, value); }
        private VM_Academic_plans _vM_Academic_Plans;
        public VM_Academic_plans vM_Academic_Plans { get => _vM_Academic_Plans; set => SetProperty(ref _vM_Academic_Plans, value); }
        private MV_Estimates _mV_Estimates;
        public MV_Estimates mV_Estimates { get => _mV_Estimates; set => SetProperty(ref _mV_Estimates, value); }
        private VM_Groups _VM_Groups;
        public VM_Groups VM_Groups { get => _VM_Groups; set => SetProperty(ref _VM_Groups, value); }
    }
}
