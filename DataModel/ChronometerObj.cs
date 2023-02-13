using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chronometer.DataModel
{
    public class ChronometerObj
    {
        public ChronometerObj() 
        {
            Reset();
        }

        public int seconds { get; set; }

        public int minutes { get; set; }

        public int hours { get; set; }

        public void AddSecond()
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;

                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;

                    if (hours == 100)
                    {
                        hours = 0;
                    }
                }
            }
        }
        public void Stop() { 
            Reset();
        }

        private void Reset()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
        }
    }
}
