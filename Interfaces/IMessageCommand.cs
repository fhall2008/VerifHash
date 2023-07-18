namespace IDiscord.DiscordModels
{
    public interface IMessageCommand
    {
        public bool RunCondition(IMessageModel message);

        public Task Run(IMessageModel message);

        public bool StopCommands(IMessageModel message);
    }
}
