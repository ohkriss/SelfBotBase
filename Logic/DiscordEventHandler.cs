using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SelfBotBase.Logic
{
    class DiscordEventHandler
    {
        public static IEnumerable<DiscordEventMethod> DiscordEventMethods { get; private set; }

        public static void Install(DiscordSocketClient client, Bot bot)
        {
            DiscordEventMethods =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                from m in t.GetMethods()
                let attribute = m.GetCustomAttribute(typeof(DiscordEventAttribute), true)
                where attribute != null
                select new DiscordEventMethod { Method = m, Attribute = attribute as DiscordEventAttribute, Type = t };

            foreach (var listener in DiscordEventMethods)
                listener.Attribute.Register(bot, client, listener);
        }
    }

    public class DiscordEventMethod
    {
        public Type Type { get; internal set; }
        public MethodInfo Method { get; internal set; }
        public DiscordEventAttribute Attribute { get; internal set; }
    }
}
