using System.Windows.Threading;

namespace GPT_STORY_WPF_M
{
    public static class Logger
    {
        private static string logged = "";

        public static void log(string message)
        {
            logged += message + "\n";
            UIThread.run(() => { MainWindow.Instance.logTextBlock.Text = logged; });
            
            Console.WriteLine("Logged: " + message);
        }
    }
}
