using System.Windows;
using System.Windows.Input;
using TestTrainee.ViewModels;

namespace TestTrainee.Views
{
    /// <summary>
    ///  Window to show detailed information about current
    /// </summary>
    public partial class CurrentDetailsWindow : Window, IDragableWindow
    {
        /// <summary>
        /// Constructor for a current view
        /// </summary>
        /// <param name="currentId"> Takes Id of current to get from API later </param>
        public CurrentDetailsWindow(string currentId)
        {
            InitializeComponent();
            var vm = new CurrentDetailsWindowViewModel(this, "Details", currentId);
            DataContext = vm;
        }
        /// <summary>
        /// Implementation of drag event
        /// </summary>
        /// <param name="sender">current window, which sends event </param>
        /// <param name="e"> Event parameters </param>
        public void DragEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
