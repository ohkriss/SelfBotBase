using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.Gateway;

namespace SelfBotBase.Commands
{
    [Command("ping")]
    public class Ping : CommandBase
    {
        public override async void Execute()
        {
            await Message.EditAsync(new() { Content = "Pong!" });
        }
    }

    [Command("avatar")]
    public class Avatar : CommandBase
    {
        [Parameter("user")]
        public ulong UserId { get; set; }
        public override async void Execute()
        {
            var user = await Client.GetUserAsync(UserId);
            EmbedMaker emb = new()
            {
                Title = user.ToString(),
                ImageUrl = user.Avatar.Url + "?size=4096"
            };

            await Message.EditAsync(new() { Embed = emb, Content = string.Empty });
        }
    }
}
