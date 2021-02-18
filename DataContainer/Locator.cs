using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_12._2020.DataContainer
{
    class Locator
    {
        public static Main Data { get; }
            = new Main()
            {
                authorizationAttempts = 0,
                authorizationTimer = DateTime.Now,
                TimerOut = new System.Windows.Threading.DispatcherTimer(),
                logOutDate = new DateTime(),
                authorizationDate = new DateTime(),
                
            };
    }
}
