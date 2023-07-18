namespace IDiscord.DiscordModels
{
    public interface IDiscordClient
    {
        public ulong BotId { get; }

        public Task Run();

        public IEnumerable<IServerModel> Servers { get; }
    }
}
