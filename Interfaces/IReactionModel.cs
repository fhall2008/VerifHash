namespace IDiscord.DiscordModels
{
    public interface IReactionModel
    {
        IChannelModel Channel { get; }

        string Emote { get; }

        public IUserModel User { get; }
    }
}
