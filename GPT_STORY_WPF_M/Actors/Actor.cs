using GPT_STORY_WPF_M.Chats;

namespace GPT_STORY_WPF_M.Actors
{
    public class Actor
    {
        public string actorName { get; protected set; }
        public string basePrompt = "";
        public string personPrompt;
        public string startsWith="";

        public Actor(string actorName, string personPrompt) {
            this.actorName = actorName;
            this.personPrompt = personPrompt.Replace("<Name>", actorName);
            this.basePrompt = basePrompt.Replace("<Name>", actorName);
        }

        /*public string send(Chat chat)
        {
            Logger.log(actorName + " is writing...");
            string request = chat.global + "\n\n" + chat.lore + "\n\n" + basePrompt + "\n\n" + personPrompt;

            request += "\n\n" + chat.messages.ToString();

            request += "\n" + Chat.toAnswer + startsWith;

            var result = Fetcher.send(request);
            chat.send(result);
            return result;
        }*/
    }
}
