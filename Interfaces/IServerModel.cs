namespace IDiscord.DiscordModels
{
    public interface IServerModel
    {
        public string Name { get; }
        public IEnumerable<ICategoryModel> Categories { get; }
        public IEnumerable<IChannelModel> Channels { get; }
    }
}
