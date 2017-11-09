using System;
using System.Windows.Input;

namespace APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies {
    class RelayCommand : ICommand {
        private readonly Action<Object> _action;

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public RelayCommand(Action<Object> action) {
            _action = action;
        }

        public void Execute(object parameter) {
            _action(parameter);
        }

        public bool CanExecute(object parameter) {
            return true;
        }
    }
}
