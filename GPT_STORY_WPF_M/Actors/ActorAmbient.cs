namespace GPT_STORY_WPF_M.Actors
{
    public class ActorAmbient : Actor
    {
        public ActorAmbient() : base("ambience", "Don't impersonate or narrate for characters. Write only short-term actions, like, what happened in a few minutes from last action or message. Try to be realistic.")
        {
            basePrompt = "GPT4 Correct User: Read the dialogue below. Write a single thing which happens next without explaining why.";
        }
    }
}
