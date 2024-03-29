using System.Windows;

namespace TestTrainee.Services
{
    public class StaticData
    {
        public static readonly Dictionary<string, Window> Navigation = new Dictionary<string, Window>()
        {
            { nameof(MainWindow), new MainWindow() },
        };
    }
}
