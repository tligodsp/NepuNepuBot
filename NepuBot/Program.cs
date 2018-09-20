﻿using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace NepuBot
{
    class Program
    {

        DiscordSocketClient _client;
        ComandHandler _handler;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            _handler = new ComandHandler();
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            _handler = new ComandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
