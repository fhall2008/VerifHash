namespace IDiscord.DiscordModels
{
    public interface ICategoryModel
    {
        public string Name { get; }
        public IEnumerable<IChannelModel> Channels { get; }
    }
}
