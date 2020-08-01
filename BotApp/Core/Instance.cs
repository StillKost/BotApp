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
                Token = "NjY0MDY3MjY4OTc5NzIwMTky.XhRu7w.2BCGwBZ4RLtpgrH4fpdamdkuxM8",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
        }
    }
}
