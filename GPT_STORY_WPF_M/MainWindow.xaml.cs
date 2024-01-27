using System.Windows;
using System.Windows.Input;
using GPT_STORY_WPF_M.Chats;

namespace GPT_STORY_WPF_M
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        private Chat chat;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            Fetcher.init();
        }


        private void chatPromptBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string text = chatPromptBox.Text;
                if(text.StartsWith("> ")) chat.send(new Message { raw = text.Substring(2), from = chat.user.actorName, type = "action" });
                else chat.send(new Message { raw = chat.user.startsWith + text, from = chat.user.actorName, type = "message" });
                chatPromptBox.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(chat == null) chat = new Chat();
            else
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    chat.turn(5);
                }
                else chat.turn(1);
            }
        }
    }
}