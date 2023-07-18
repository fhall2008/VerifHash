namespace IDiscord.DiscordModels
{
    public interface IReactionCommand
    {
        public bool RunCondition(IReactionModel reation, IMessageModel message, IChannelModel channel);

        public Task Run(IReactionModel reation, IMessageModel message, IChannelModel channel);

        public bool StopCommands(IReactionModel reation, IMessageModel message, IChannelModel channel);
    }
}
