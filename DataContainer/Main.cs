using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using PP_12._2020.Infrastructure;

namespace PP_12._2020.DataContainer
{
    class Main:OnPropertyChangedClass
    {
        int _authorizationAttempts;
        public int authorizationAttempts { get => _authorizationAttempts; set => SetProperty(ref _authorizationAttempts, value); }
        DateTime _authorizationTimer;
        public DateTime authorizationTimer { get => _authorizationTimer; set => SetProperty(ref _authorizationTimer, value); }
        DispatcherTimer _TimerOut;
        public DispatcherTimer TimerOut { get => _TimerOut; set => SetProperty(ref _TimerOut, value); }
        DateTime _authorizationDate;
        public DateTime authorizationDate { get => _authorizationDate; set => SetProperty(ref _authorizationDate, value); }
        DateTime _logOutDate;
        public DateTime logOutDate { get => _logOutDate; set => SetProperty(ref _logOutDate, value); }
    }
}
