using IDiscord.DiscordModels;

namespace Discord_Bot.Commands
{
    internal class ReactionLogCommand : IReactionCommand
    {
        private readonly ILogger _logger;
        public ReactionLogCommand(ILogger logger)
        {
            _logger = logger;
        }

        public bool RunCondition(IReactionModel reation, IMessageModel message, IChannelModel channel)
        {
            return true;
        }

        public Task Run(IReactionModel reation, IMessageModel message, IChannelModel channel)
        {
            _logger.Log(reation.Emote);
            return Task.CompletedTask;
        }

        public bool StopCommands(IReactionModel reation, IMessageModel message, IChannelModel channel)
        {
            return false;
        }
    }
}
