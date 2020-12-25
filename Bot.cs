using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Gateway;
using Discord.WebSockets;
using Newtonsoft.Json;
using SelfBotBase.Logic;

namespace SelfBotBase
{
    public class Bot
    {
        public DiscordSocketClient Client { get; internal set; }
        public Config Config { get; internal set; }

        public async Task Initialize()
        {
            if (File.Exists("Config.json"))
            {
                Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));

                if (string.IsNullOrEmpty(Config.Token))
                {
                    Console.Write("Token #");
                    Config.Token = Console.ReadLine();
                }
            }
            else
            {
                Config = new();

                Console.Write("Token #");
                Config.Token = Console.ReadLine();
            }

            File.WriteAllText("Config.json", JsonConvert.SerializeObject(Config, Formatting.Indented));

            Client = new(new()
            {
                Cache = true
            });

            DiscordEventHandler.Install(Client, this);

            Client.Login(Config.Token);

            await Task.Delay(Timeout.Infinite);
        }
    }
}
