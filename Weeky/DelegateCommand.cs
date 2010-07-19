using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Weeky
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private EventHandler _canExecuteChanged = new EventHandler(Nothing);

        private static void Nothing(object sender, EventArgs e)
        {
            
        }

        public DelegateCommand(Action execute) : this(execute, () => true)
        {
        }

        private DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute();
            
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { _canExecuteChanged += value; }
            remove { _canExecuteChanged -= value;  }
        }

        void ICommand.Execute(object parameter)
        {
            _execute();
        }
    }
}
