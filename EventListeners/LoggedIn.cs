using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Gateway;
using SelfBotBase.Logic;

namespace SelfBotBase.EventListeners
{
    public class LoggedIn
    {
        [DiscordEvent(EventType.LoggedIn)]
        public async Task OnLoggedInAsync(Bot bot, DiscordSocketClient client, LoginEventArgs args)
        {
            await Task.Yield();

            Console.WriteLine($"Logged into {args.User}");
        }
    }
}
