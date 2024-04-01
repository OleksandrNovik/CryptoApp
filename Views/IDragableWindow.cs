using System.Windows.Input;

namespace TestTrainee.Views
{
    /// <summary>
    /// Intarface to implement drag move for all windows
    /// </summary>
    public interface IDragableWindow
    {
        /// <summary>
        /// Method to handle drag event for window
        /// </summary>
        /// <param name="sender"> Event sender</param>
        /// <param name="e"> Event parameters </param>
        public void DragEvent(object sender, MouseButtonEventArgs e);
    }
} 
