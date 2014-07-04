﻿namespace appfactory.core
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public static class Command
    {
        public static ICommand Construct<T>(Action<T> action)
        {
            return new Command<T, object>(action, _ => { return true; });
        }

        public static ICommand Construct(Action action)
        {
            return new Command<object, object>(_ => { action(); }, _ => { return true; });
        }

        public static ICommand ConstructFunc(Func<Task> action)
        {
            return new Command<object, object>(_ => { action(); }, _ => { return true; });
        }
    }

    public class Command<T, Y> : ICommand
    {
        private Func<Y, bool> _canExecuteAction;
        private Action<T> _executeAction;

        public Command(Action<T> executeAction, Func<Y, bool> canExecuteAction)
        {
            this._executeAction = executeAction;
            this._canExecuteAction = canExecuteAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecute((Y)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "This does use an event")]
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        private bool CanExecute(Y parameter)
        {
            return _canExecuteAction(parameter);
        }

        private void Execute(T parameter)
        {
            _executeAction(parameter);
        }
    }
}