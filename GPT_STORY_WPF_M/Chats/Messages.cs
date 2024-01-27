namespace GPT_STORY_WPF_M.Chats
{
    public class Messages
    {
        private List<Message> messages = new List<Message>();
        public override string ToString()
        {
            return string.Join("\n", messages.Select(it=>it.raw));
        }
        public void add(Message message)
        {
            messages.Add(message);
            string st = "";
            foreach (Message m in messages)
            {
                st += $"\n        -    -    -    -    -   {m.from}'s {m.type}\n";
                st += m.raw;
            }
            UIThread.run(() => MainWindow.Instance.chatTextBlock.Text = st);
        }
        public Message last()
        {
            return messages.Last();
        }
    }
}
