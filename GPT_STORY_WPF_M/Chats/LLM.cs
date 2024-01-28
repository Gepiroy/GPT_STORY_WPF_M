namespace GPT_STORY_WPF_M.Chats
{
    public class LLM
    {
        public string endOfTurn { get; private set; }
        public string inputForAI { get; private set; }
        public string inputForUser { get; private set; }

        public static readonly LLM OPENCHAT = new LLM
        {
            endOfTurn = "<|end_of_turn|>",
            inputForAI = "GPT4 Correct Assistant:",
            inputForUser = "GPT4 Correct User:"
        };

        public static readonly LLM XWIN = new LLM
        {
            endOfTurn = "</s>",
            inputForAI = "ASSISTANT:",
            inputForUser = "USER:"
        };
    }
}
