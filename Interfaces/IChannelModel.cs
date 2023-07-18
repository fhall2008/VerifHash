namespace IDiscord.DiscordModels
{
    public interface IChannelModel
    {
        string Name { get; }
        IServerModel? Server { get; }
        bool IsDM { get; }
        bool IsText { get; }
        Task<bool> PostMessage(string message);
    }
}
