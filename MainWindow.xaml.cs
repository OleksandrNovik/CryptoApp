using System.Windows;
using System.Windows.Input;
using TestTrainee.ViewModels;
using TestTrainee.Views;

namespace TestTrainee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDragableWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel(this, "Home");
            DataContext = vm;
        }

        public void DragEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}