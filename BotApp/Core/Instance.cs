using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;

namespace BotApp.Core
{
    public class Instance
    {
        public DiscordClient CreateInstance()
        {
            return new DiscordClient(new DiscordConfiguration
            {
                Token = "NzM5MTExNjQ4NDc2MDA0NDAz.XyVtXQ.uyjy7LgmLodpQEdeNHYpNkIoVBU",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
        }
    }
}
