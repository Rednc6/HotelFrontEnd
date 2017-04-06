using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace HotelFrontEnd.Commen
{
    class RelayCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;
        private DispatcherTimer canExecuteChangedEventTimer;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;

            //this.canExecuteChangedEventTimer = new DispatcherTimer();
            //this.canExecuteChangedEventTimer.Tick += canExecuteChangedEventTimer_Tick;
            //this.canExecuteChangedEventTimer.Interval = new TimeSpan(0, 0, 1);
            //this.canExecuteChangedEventTimer.Start();
        }

        //private void canExecuteChangedEventTimer_Tick(object sender, object e)
        //{
        //    this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        //}

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            else
            {
                return _canExecute();
            }
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}

