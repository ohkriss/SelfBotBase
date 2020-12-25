using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Gateway;


namespace SelfBotBase.Logic
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DiscordEventAttribute : Attribute
    {
        public EventType Target { get; }
        public DiscordEventAttribute(EventType target)
            => Target = target;

        public void Register(Bot bot, DiscordSocketClient client, DiscordEventMethod listener)
        {
            void OnEvent(object s, object e)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        //var constructor = listener.Type.GetConstructor(Type.EmptyTypes);
                        var instance = Activator.CreateInstance(listener.Type);

                        await (Task)listener.Method.Invoke(instance, new[] { bot, s, e });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Listener] Uncaught exception in listener thread >> {ex} >>");
                        Console.WriteLine($"{ex.Message} >> {ex.StackTrace}");
                    }
                });
            }

            switch (Target)
            {
                case EventType.LoggedIn:
                    client.OnLoggedIn += OnEvent;
                    break;
                case EventType.LoggedOut:
                    client.OnLoggedOut += OnEvent;
                    break;
                case EventType.SettingsUpdated:
                    client.OnSettingsUpdated += OnEvent;
                    break;
                case EventType.SessionsUpdated:
                    client.OnSessionsUpdated += OnEvent;
                    break;
                case EventType.UserUpdated:
                    client.OnUserUpdated += OnEvent;
                    break;
                case EventType.JoinedGuild:
                    client.OnJoinedGuild += OnEvent;
                    break;
                case EventType.GuildUpdated:
                    client.OnGuildUpdated += OnEvent;
                    break;
                case EventType.LeftGuild:
                    client.OnLeftGuild += OnEvent;
                    break;
                case EventType.UserJoinedGuild:
                    client.OnUserJoinedGuild += OnEvent;
                    break;
                case EventType.UserLeftGuild:
                    client.OnUserLeftGuild += OnEvent;
                    break;
                case EventType.GuildMemberUpdated:
                    client.OnGuildMemberUpdated += OnEvent;
                    break;
                case EventType.UserPresenceUpdated:
                    client.OnUserPresenceUpdated += OnEvent;
                    break;
                case EventType.RoleCreated:
                    client.OnRoleCreated += OnEvent;
                    break;
                case EventType.RoleUpdated:
                    client.OnRoleUpdated += OnEvent;
                    break;
                case EventType.RoleDeleted:
                    client.OnRoleDeleted += OnEvent;
                    break;
                case EventType.ChannelCreated:
                    client.OnChannelCreated += OnEvent;
                    break;
                case EventType.ChannelUpdated:
                    client.OnChannelUpdated += OnEvent;
                    break;
                case EventType.ChannelDeleted:
                    client.OnChannelDeleted += OnEvent;
                    break;
                case EventType.Ringing:
                    client.OnRinging += OnEvent;
                    break;
                case EventType.CallUpdated:
                    client.OnCallUpdated += OnEvent;
                    break;
                case EventType.CallEnded:
                    client.OnCallEnded += OnEvent;
                    break;
                case EventType.InviteCreated:
                    client.OnInviteCreated += OnEvent;
                    break;
                case EventType.InviteDeleted:
                    client.OnInviteDeleted += OnEvent;
                    break;
                case EventType.VoiceStateUpdate:
                    client.OnVoiceStateUpdated += OnEvent;
                    break;
                case EventType.EmojisUpdated:
                    client.OnEmojisUpdated += OnEvent;
                    break;
                case EventType.UserTyping:
                    client.OnUserTyping += OnEvent;
                    break;
                case EventType.MessageReceived:
                    client.OnMessageReceived += OnEvent;
                    break;
                case EventType.MessageEdited:
                    client.OnMessageEdited += OnEvent;
                    break;
                case EventType.MessageDeleted:
                    client.OnMessageDeleted += OnEvent;
                    break;
                case EventType.MessageReactionAdded:
                    client.OnMessageReactionAdded += OnEvent;
                    break;
                case EventType.MessageReactionRemoved:
                    client.OnMessageReactionRemoved += OnEvent;
                    break;
                case EventType.UserBanned:
                    client.OnUserBanned += OnEvent;
                    break;
                case EventType.UserUnbanned:
                    client.OnUserUnbanned += OnEvent;
                    break;
                case EventType.RelationshipAdded:
                    client.OnRelationshipAdded += OnEvent;
                    break;
                case EventType.RelationshipRemoved:
                    client.OnRelationshipRemoved += OnEvent;
                    break;
                case EventType.GiftCodeCreated:
                    client.OnGiftCodeCreated += OnEvent;
                    break;
                case EventType.GiftUpdated:
                    client.OnGiftUpdated += OnEvent;
                    break;
                case EventType.OnBoostSlotCreated:
                    client.OnBoostSlotCreated += OnEvent;
                    break;
                case EventType.OnBoostSlotUpdated:
                    client.OnBoostSlotUpdated += OnEvent;
                    break;
                case EventType.OnEntitlementCreated:
                    client.OnEntitlementCreated += OnEvent;
                    break;
                case EventType.OnEntitlementUpdated:
                    client.OnEntitlementUpdated += OnEvent;
                    break;
            }
        }
    }
}
