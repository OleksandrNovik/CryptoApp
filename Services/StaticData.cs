using System.Windows;

namespace TestTrainee.Services
{
    /// <summary>
    /// Class to hold static data
    /// </summary>
    public class StaticData
    {
        /// <summary>
        /// Navigation should return right window by its name
        /// </summary>
        public static readonly Dictionary<string, Window> Navigation = new Dictionary<string, Window>()
        {
            { "Home", new MainWindow() },
        };
    }
}
