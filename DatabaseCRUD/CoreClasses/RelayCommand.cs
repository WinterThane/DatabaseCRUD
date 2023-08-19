using System;
using System.Windows.Input;

namespace DatabaseCRUD.CoreClasses
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public readonly Action _execute;

        public RelayCommand(Action execute) 
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
