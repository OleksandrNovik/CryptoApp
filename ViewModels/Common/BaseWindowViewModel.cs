using System.Windows;

namespace TestTrainee.ViewModels
{
    public class BaseWindowViewModel
    {
        private readonly Window _window;
        public RelayCommand CloseCommand => new(execute => { _window.Close(); });
        public RelayCommand ResizeCommand => new(execute => { ResizeWindow(); });
        public RelayCommand MinimizeCommand => new(execute => { _window.WindowState = WindowState.Minimized; });
        public BaseWindowViewModel(Window currentWindow) 
        { 
            _window = currentWindow;
        }
        private void ResizeWindow()
        {
            if (_window.WindowState == WindowState.Maximized)
                _window.WindowState = WindowState.Normal;
            else
                _window.WindowState = WindowState.Maximized;
        }
    }
}
