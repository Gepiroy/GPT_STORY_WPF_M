using GPT_STORY_WPF_M.Chats;

namespace GPT_STORY_WPF_M.Actors
{
    public class ActorPerson : Actor
    {

        public string baseActionPrompt = "Write a single action for the only one character: \"<Name>\" without explaining why. " +
            "Write only one short-term action, not more than few minutes in length. Try to be realistic. Don't repeat what already written. Write only the new things.";
        public ActorPerson(string actorName, string personPrompt) : base(actorName, personPrompt)
        {
            basePrompt = $"Write a single saying for the character \"{actorName}\".";
            baseActionPrompt = baseActionPrompt.Replace("<Name>", actorName);
            startsWith = actorName + ": ";
        }

        public string tell(Chat chat)
        {
            Logger.logn(actorName + " is writing...");
            string request = chat.global + "\n\n" + chat.lore + "\n\n" + /*personPrompt*/chat.gatherAllPersonPrompts();

            request += "\n\n" + chat.messages.ToString();

            request += "\n\n" + Chat.toSystemPrompt() + basePrompt;

            request += "\n" + Chat.toAnswer() + startsWith;

            var result = Fetcher.send(request);
            chat.send(new Message { raw = startsWith + result, from = actorName, type = "message" });
            return result;
        }
        public string act(Chat chat)
        {
            Logger.logn(actorName + " is acting...");
            string request = chat.global + "\n\n" + chat.lore + "\n\n" + /*personPrompt*/chat.gatherAllPersonPrompts();

            request += "\n\n" + chat.messages.ToString();

            request += "\n\n" + Chat.toSystemPrompt() + baseActionPrompt;

            request += "\n" + Chat.toAnswer();

            var result = Fetcher.send(request);
            chat.send(new Message { raw = result, from = actorName, type = "action" });
            return result;
        }
    }
}
