using System.Windows;
using System.Windows.Input;

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
        }

        public void DragEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
