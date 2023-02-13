using Chronometer.DataModel;
using Chronometer.Helpers;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace Chronometer.ViewModel
{
    public class ChronometerVM : BaseViewModel
    {
        private DispatcherTimer? _timer;
        private ChronometerObj _chrono;
        private ICommand _startCommand;
        private ICommand _stopCommand;
        private ICommand _pauseCommand;
        private string _hours;
        private string _minutes;
        private string _seconds;

        public ChronometerVM() {
            _startCommand = new ChronometerCommand(_Start, null);
            _stopCommand = new ChronometerCommand(_Stop, null);
            _pauseCommand = new ChronometerCommand(_Pause, null);
            _chrono = new ChronometerObj();
            _hours = AddTrailingZero(_chrono.hours.ToString());
            _minutes = AddTrailingZero(_chrono.hours.ToString());
            _seconds = AddTrailingZero(_chrono.hours.ToString());
        }

        public ICommand StartCommand
        {
            get { return _startCommand; }
            set { SetProperty(ref _startCommand, value); }
        }

        public ICommand StopCommand
        {
            get { return _stopCommand; }
            set { SetProperty(ref _stopCommand, value); }
        }

        public ICommand PauseCommand
        {
            get { return _pauseCommand; }
            set { SetProperty(ref _pauseCommand, value); }
        }

        public string Hours
        {
            get { return _hours; }
            set { SetProperty(ref _hours, value); }
        }

        public string Minutes
        {
            get { return _minutes; }
            set { SetProperty(ref _minutes, value); }
        }

        public string Seconds
        {
            get { return _seconds; }
            set { SetProperty(ref _seconds, value); }
        }
      
        private void _Start(object parameter)
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += new EventHandler(timerTick);
                
            }
            _timer.Start();
        }
        public void _Stop(object parameter)
        {
            if ((_timer != null) && (_timer.IsEnabled))
            {
                _timer.Stop();
            }

            _chrono.Stop();
            Seconds = AddTrailingZero(_chrono.seconds.ToString());
            Minutes = AddTrailingZero(_chrono.minutes.ToString());
            Hours = AddTrailingZero(_chrono.hours.ToString());
        }
        
        public void _Pause(object parameter)
        {
            if ((_timer != null) && (_timer.IsEnabled))
            {
                _timer.Stop();
            }
        }
        private void timerTick(object? sender, EventArgs? e)
        {
            _chrono.AddSecond();
            Seconds = AddTrailingZero(_chrono.seconds.ToString());
            Minutes = AddTrailingZero(_chrono.minutes.ToString());
            Hours = AddTrailingZero(_chrono.hours.ToString());
        }

        private string AddTrailingZero(string value)
        {
            if (value.Length == 1) 
            {
                return "0" + value;
            }
            else 
            { 
                return value; 
            }
        }
    }
}
