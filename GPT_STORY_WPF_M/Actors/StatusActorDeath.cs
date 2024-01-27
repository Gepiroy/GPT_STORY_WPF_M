using GPT_STORY_WPF_M.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_STORY_WPF_M.Actors
{
    public class StatusActorDeath
    {
        private string prompt1 = "Answer by only one word. If you sure that someone has died in the message, write it's name. If not, write \"nobody\". If died more than one person, choose one of them.";
        private string prompt2 = "Answer only with a single name. If you are sure someone has died based on the message provided, reply with their name. If there's more than one dead person, choose one of them arbitrarily. In other case, write out \"nobody\". The message is below:\n";
        private string prompt3 = "The Assistant answers in JSON. Its response should be of schema: { \"died\": <who has died> }.\r\nThe \"died\" is who has died in the text. If there was nobody or you're not absolutely sure, put \"nobody\".";
        private string prompt4 = "Tell if you think that someone has died in the text.";

        public string check(Chat chat)
        {
            string prompt = "";

            prompt += prompt4;

            //prompt += "Last actions:\n";

            prompt += Chat.toSystemPrompt;

            prompt += chat.messages.ToString() + "\n";

            //prompt += "<|end_of_turn|>";

            prompt += Chat.toAnswer;

            return Fetcher.send(prompt);
        }

        public void execute(Chat chat)
        {
            string result = check(chat);
            Logger.log("death detector: "+result);
            if (!result.Contains("nobody", StringComparison.OrdinalIgnoreCase)){
                ActorPerson? person = chat.findPerson(result);
                if(person == null)
                {
                    Logger.log($"CAN'T FIND PERSON NAMED \"{result}\"!");
                }
                else
                {
                    chat.persons.Remove(person);
                }
                //chat.messages.add(new Message { raw = result+" is DEAD!", from = "StatusActorDeath", type = "check"});
            }
        }
    }
}
