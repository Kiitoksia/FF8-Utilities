using System;
using System.Windows.Input;

namespace FF8Utilities.Entities
{
    public class Command : ICommand
    {        
        private Func<bool> _canExecuteMethod;
        private EventHandler _executeMethod;

        public Command(Func<bool> canExecute, EventHandler executeMethod)
        {
            _canExecuteMethod = canExecute;
            _executeMethod = executeMethod;
        }

        #region Implementation of ICommand
        public bool CanExecute(object parameter) => _canExecuteMethod.Invoke();

        public void Execute(object parameter) => _executeMethod.Invoke(this, EventArgs.Empty);
        
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion
    }
}
