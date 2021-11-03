using System;
using System.Windows.Input;

namespace ChatViewer.ViewModels
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> action, Predicate<object> canExecute = null)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _action(parameter);

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _action;
        private readonly Predicate<object> _canExecute;
    }
}
