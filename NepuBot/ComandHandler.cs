using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NepuBot
{
    class ComandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
            await _client.SetGameAsync(Utilities.GetAlert("GAME"));
            _client.UserJoined += AnnounceJoinedUser;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)
                || msg.HasStringPrefix(Config.bot.cmdPrefixEx, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
            //_client.UserJoined += AnnounceJoinedUser;
        }

        public async Task AnnounceJoinedUser(SocketGuildUser user) //Welcomes the new user
        {
            //Console.WriteLine("User joined");
            var channel = _client.GetChannel(421689189805981698) as SocketTextChannel; // Gets the channel to send the message in
            await channel.SendMessageAsync($"Welcome {user.Mention} to {channel.Guild.Name}! Enjoy your stay \\\\(≧ω≦)/"); //Welcomes the new user
        }

    }
}
