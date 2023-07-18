namespace IDiscord.DiscordModels
{
    public interface IMessageModel
    {
        string AuthorName { get; }
        ulong AuthorId { get; }
        string Content { get; }
        bool IsBot { get; }
        bool IsPrivate { get; }
        IEnumerable<IUserModel> UsersMentioned { get; }
        public DateTime TimeSent { get; }
        IChannelModel? Channel { get; }

        Task Reply(string content);
        Task verify();
        Task delete();
    }
}
