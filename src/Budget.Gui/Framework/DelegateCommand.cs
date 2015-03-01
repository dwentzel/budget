namespace Budget.Gui.Framework
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public DelegateCommand(Action execute)
            : this(execute, () => true)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
