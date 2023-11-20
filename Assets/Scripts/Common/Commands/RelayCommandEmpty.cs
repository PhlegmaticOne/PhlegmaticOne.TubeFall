using System;

namespace Common.Commands {
    public class RelayCommandEmpty : IRelayCommand {
        private readonly Action _action;
        
        public event EventHandler CanExecuteChanged;

        public RelayCommandEmpty(Action action) {
            _action = action;
        }
        
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action?.Invoke();
    }
}