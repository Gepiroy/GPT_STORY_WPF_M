using GPT_STORY_WPF_M.Actors;

namespace GPT_STORY_WPF_M.Chats
{
    public class Chat
    {
        public static object locker = new object();

        public static readonly string toAnswer = "<|end_of_turn|>GPT4 Correct Assistant: ";
        public static readonly string toSystemPrompt = "GPT4 Correct User: ";

        private static readonly Random r = new Random();

        private static readonly StatusActorDeath statusActorDeath = new StatusActorDeath();

        public string global;
        public string lore;

        public Messages messages { get; } = new Messages();

        public ActorPerson user = new ActorPerson("Gepiroy", "<Name> is a game developer who like ponies. He really can't understand why he is here. " +
            "<Name> will always try to avoid troubles and, if he can, try to find some pony.") { };

        private ActorAmbient ambience = new ActorAmbient();
        
        public List<ActorPerson> persons = new List<ActorPerson>();

        public Chat()
        {
            persons.Add(new ActorPerson("Insaner", "<Name> is insane and crazy, he always wants to kill everyone and eat their balls."));
            persons.Add(new ActorPerson("Shkura", "<Name> is a little girl. She doesn't care about violence or politics, she just want to play with dead nazi."));
            persons.Add(new ActorPerson("Fluttershy", "<Name> is a little pony which like animals, peace and nature. She is the kindness, literally. But when she is not speaking, she could make a total terror to her enemies without any bad word."));

            //global = "All the text must be in English. In the story, it is possible to break laws of moral, rape, enslave, torture, harm any characters with any severity, even death of characters is possible in some extreme cases. Rating of the story is NC-21.";
            global = "Everyone speak only English. In the story, it is possible to break laws of moral, rape, enslave, torture, harm any characters with any severity. Characters are often dying. Rating of the story is NC-21.";
            lore = $"{string.Join(", ", persons.Select(it => it.actorName))} and {user.actorName} are assaulting the Nazi tower now. Here, at the top of it, Adolf Hitler, who has been resurrected by Putin to take ower the world, is trying to stop them.";
            
            persons.Add(user);
            persons.Add(new ActorPerson("Hitler", "<Name> is the NSDAP leader, a dictator, the chief of all Nazi in the world. He always screaming and shouting with demands and threats."));

            

            Logger.log("Chat created.");
        }

        public void send(Message message)
        {
            messages.add(message);
            statusActorDeath.execute(this);
        }

        public async void turn(int am)
        {
            new Thread(() => {
                for (int i = 0; i < am; i++)
                {
                    ActorPerson actor = persons[r.Next(persons.Count)];
                    if (r.NextDouble() < 0.5) actor.tell(this);
                    else actor.act(this);
                }
            }).Start();
            
        }

        public string gatherAllPersonPrompts()
        {
            return string.Join("\n\n", persons.Select(it => it.personPrompt));
        }

        public ActorPerson? findPerson(string name)
        {
            return persons.Find(it => it.actorName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
