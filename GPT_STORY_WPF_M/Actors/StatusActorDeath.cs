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
        public string check(Chat chat)
        {
            string prompt = chat.messages.last().raw + "\n";

            prompt += Chat.toSystemPrompt + "Answer by only one word. If you sure that someone has died in the message, write it's name. If not, write \"nobody\". If died more than one person, choose one of them.\n";

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
                chat.messages.add(new Message { raw = result+" is DEAD!", from = "StatusActorDeath", type = "check"});
            }
        }
    }
}
