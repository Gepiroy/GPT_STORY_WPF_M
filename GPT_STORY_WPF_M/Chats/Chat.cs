using GPT_STORY_WPF_M.Actors;

namespace GPT_STORY_WPF_M.Chats
{
    public class Chat
    {
        public static object locker = new object();

        [Obsolete("Use model.endOfTurn + model.inputForAI + space instead.")]
        public static string toAnswer() { return /*model.endOfTurn +*/ model.inputForAI + " "; }
        [Obsolete("Use model.inputForUser + space instead.")]
        public static string toSystemPrompt() { return model.inputForUser + " "; }

        public static readonly LLM model = LLM.XWIN;

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
            /*persons.Add(new ActorPerson("Insaner", "<Name> is insane and crazy, he always wants to kill everyone and eat their balls."));
            persons.Add(new ActorPerson("Shkura", "<Name> is a little girl. She doesn't care about violence or politics, she just want to play with dead nazi."));
            persons.Add(new ActorPerson("Fluttershy", "<Name> is a little pony which like animals, peace and nature. She is the kindness, literally. But when she is not speaking, she could make a total terror to her enemies without any bad word."));
            */
            persons.Add(new ActorPerson("Vika","<Name> is a satan in human body. She is terrible and stupid girl who always insults everybody arond herself. She is a sister of Sanya."));
            persons.Add(new ActorPerson("Sanya","<Name> is a nerd who like to watch and send my little pony and pokemon porn to his friends. He is a brother of Vika. He wants to live in the Pavel's closet."));
            persons.Add(new ActorPerson("Pavel", "<Name> is an owner of the home where the actions is going."));

            //global = "All the text must be in English. In the story, it is possible to break laws of moral, rape, enslave, torture, harm any characters with any severity, even death of characters is possible in some extreme cases. Rating of the story is NC-21.";
            global = "Everyone should speak only English. No Spanish, no German, only English! In the story, it is possible to break laws of moral, rape, enslave, torture, harm any characters with any severity. Characters are often dying. Rating of the story is NC-21.";
            lore = $"{string.Join(", ", persons.Select(it => it.actorName))} and {user.actorName} are assaulting the Nazi tower now. Here, at the top of it, Adolf Hitler, who has been resurrected by Putin to take ower the world, is trying to stop them.";

            lore = $"{string.Join(", ", persons.Select(it => it.actorName))} and {user.actorName} has woke up together in one bed. They are actually the blood enemies for each other.";

            lore = $"After Sanya sent his nudes to Pavel, the Pavel grabbed his leg and moved from Sanyas's old home (shelf) to his new home (a toilet). Then Pavel heared that there is a Vika also in the toilet!";

            //persons.Add(user);
            //persons.Add(new ActorPerson("Hitler", "<Name> is the NSDAP leader, a dictator, the chief of all Nazi in the world. He always screaming and shouting with demands and threats."));

            //persons.ForEach(person => person.personPrompt = person.actorName + " always trying to kill everyone around self.");

            Logger.logn("Chat created.");
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
