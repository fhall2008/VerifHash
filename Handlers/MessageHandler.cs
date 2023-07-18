using IDiscord.DiscordModels;
using IDiscord.Utilities;

namespace IDiscord.Handlers
{
    internal class MessageHandler
    {
        private readonly IDiscordClient _client;
        private readonly Logger _logger;
        private readonly IEnumerable<IMessageCommand>? _botCommands;
        private readonly IEnumerable<IMessageCommand>? _privateCommands;
        private readonly IEnumerable<IMessageCommand>? _publicCommands;

        public MessageHandler(IDiscordClient client, Logger logger, List<Func<IDiscordClient, ILogger, IMessageCommand>>? botCommands, List<Func<IDiscordClient, ILogger, IMessageCommand>>? privateCommands, List<Func<IDiscordClient, ILogger, IMessageCommand>>? publicCommands)
        {
            _client = client;
            _logger = logger;

            _botCommands = botCommands?.Select(bc => bc(client, logger));
            _privateCommands = privateCommands?.Select(bc => bc(client, logger));
            _publicCommands = publicCommands?.Select(bc => bc(client, logger));
        }

        public async Task BotMessageHandler(IMessageModel message)
        {
            await RunCommands(message, _botCommands);
        }

        public async Task PrivateMessageHandler(IMessageModel message)
        {
            await RunCommands(message, _privateCommands);
        }

        public async Task ChannelMessageHandler(IMessageModel message)
        {
            await RunCommands(message, _publicCommands);
        }

        static async Task RunCommands(IMessageModel message, IEnumerable<IMessageCommand>? commands)
        {
            if (commands == null)
            {
                return;
            }
            foreach (var command in commands)
            {
                if (command.RunCondition(message))
                {
                    await command.Run(message);
                    if (command.StopCommands(message))
                    {
                        return;
                    }
                }
            }
        }
    }
}
