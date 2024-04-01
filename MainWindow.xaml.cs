using System.Windows;
using System.Windows.Input;
using TestTrainee.ViewModels;
using TestTrainee.Views;

namespace TestTrainee
{
    /// <summary>
    /// Main window, that shows list of top current items from API
    /// </summary>
    public partial class MainWindow : Window, IDragableWindow
    {
        /// <summary>
        /// Constructor that initialize all needed fields
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel(this, "Home");
            DataContext = vm;
        }

        /// <summary>
        /// Drag event for current window
        /// </summary>
        /// <param name="sender"> Event sender </param>
        /// <param name="e"> Event params </param>
        public void DragEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}