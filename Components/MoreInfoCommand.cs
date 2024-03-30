using System.Windows.Input;


namespace TestTrainee.Components
{
    internal class MoreInfoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
        }
    }
}
