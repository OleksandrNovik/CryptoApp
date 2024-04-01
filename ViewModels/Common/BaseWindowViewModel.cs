using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TestTrainee.Services;
using TestTrainee.Services.Theme;

namespace TestTrainee.ViewModels
{
    /// <summary>
    /// Base view model for holding necessary commands and other props
    /// </summary>
    public abstract class BaseWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Field for holding current window
        /// </summary>
        protected readonly Window _window;
        /// <summary>
        /// Theme provider for switching themes
        /// </summary>
        private readonly ThemeProvider thems;
        /// <summary>
        /// Current window name for navigation
        /// </summary>
        private readonly string windowName;
        /// <summary>
        /// Current theme
        /// </summary>
        private string theme;
        /// <summary>
        /// Is dark theme set (initial state of switch)
        /// </summary>
        public bool IsThemeChecked { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Method to call PropertyChanged
        /// </summary>
        /// <param name="propertyName"> Name of property that was changed </param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Navigate to other window
        /// </summary>
        public RelayCommand<string> NavigateCommand => new RelayCommand<string>(NavigateTo);
        /// <summary>
        /// Close the window
        /// </summary>
        public ICommand CloseCommand => new RelayCommand<object?>(execute => { _window.Close(); });
        /// <summary>
        /// Maximum or Normal size for window
        /// </summary>
        public ICommand ResizeCommand => new RelayCommand<object?>(execute => { ResizeWindow(); });
        /// <summary>
        /// Minimize window
        /// </summary>
        public ICommand MinimizeCommand => new RelayCommand<object?>(execute => { _window.WindowState = WindowState.Minimized; });
        /// <summary>
        /// Switch themes
        /// </summary>
        public ICommand SwitchThemeCommand => new RelayCommand(() =>  theme = thems.SwitchTheme(theme));
        /// <summary>
        /// Create instance of <see cref="BaseWindowViewModel"/>
        /// </summary>
        /// <param name="currentWindow"> Window to work with </param>
        /// <param name="windowName"> Current window name for navigation </param>
        public BaseWindowViewModel(Window currentWindow, string windowName) 
        { 
            _window = currentWindow;
            this.windowName = windowName;
            thems = new ThemeProvider();
            theme = ThemeProvider.CurrentTheme;
            IsThemeChecked = theme == "DarkTheme";
        }
        /// <summary>
        /// Change size of current window
        /// </summary>
        private void ResizeWindow()
        {
            if (_window.WindowState == WindowState.Maximized)
                _window.WindowState = WindowState.Normal;
            else
                _window.WindowState = WindowState.Maximized;
        }
        /// <summary>
        /// Navigate to other window
        /// </summary>
        /// <param name="window"> Window's name </param>
        private void NavigateTo(string window)
        {
            if (window == windowName)
                return;
            StaticData.Navigation[window].Show();
            _window.Close();
        }
    }
}
