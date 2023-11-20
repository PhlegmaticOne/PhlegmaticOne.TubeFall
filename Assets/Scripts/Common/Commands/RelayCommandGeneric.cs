using System;

namespace Common.Commands {
    public class RelayCommandGeneric<T> : IRelayCommand {
        private readonly Action<T> _action;
        public event EventHandler CanExecuteChanged;

        public RelayCommandGeneric(Action<T> action) => _action = action;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) {
            if (parameter is T generic) {
                _action?.Invoke(generic);
            }
        }
    }
}