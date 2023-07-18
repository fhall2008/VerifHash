using Discord.WebSocket;

namespace IDiscord.DiscordModels
{
    internal class ReactionModel : IReactionModel
    {
        private readonly SocketReaction _reaction;

        public ReactionModel(SocketReaction readtion)
        {
            _reaction = readtion;
        }

        public IChannelModel Channel => new ChannelModel(_reaction.Channel);

        public string Emote => _reaction.Emote.Name;

        public IUserModel User => new UserModel(_reaction.UserId);
    }
}
