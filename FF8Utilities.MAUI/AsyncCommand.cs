using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FF8Utilities.MAUI
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }

    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<object, Task> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Synchronous overload
        /// </summary>
        public AsyncCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = (_) =>
            {
                execute();
                return Task.CompletedTask;
            };
            if (canExecute != null) _canExecute = (_) => canExecute();
        }

        /// <summary>
        /// Synchronous overload
        /// </summary>
        public AsyncCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = (arg) =>
            {
                execute(arg);
                return Task.CompletedTask;
            };

            _canExecute = canExecute;
        }

        public AsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = (_) => execute();
            if (canExecute != null) _canExecute = (_) => canExecute();
        }

        public bool CanExecute(object parameter)
        {
            if (_isExecuting) return false;
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }
            }
        }

        private void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
        }


        void ICommand.Execute(object parameter)
        {
            ExecuteAsync(parameter).ContinueWith(t =>
            {
                throw t.Exception;
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
