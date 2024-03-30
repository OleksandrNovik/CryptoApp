using System.Windows;
using System.Windows.Input;
using TestTrainee.ViewModels;

namespace TestTrainee.Views
{
    /// <summary>
    /// Interaction logic for CurrentDetailsWindow.xaml
    /// </summary>
    public partial class CurrentDetailsWindow : Window, IDragableWindow
    {
        public CurrentDetailsWindow(string currentId)
        {
            InitializeComponent();
            var vm = new CurrentDetailsWindowViewModel(this, "Details", currentId);
            DataContext = vm;
        }

        public void DragEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
