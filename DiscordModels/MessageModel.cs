using Discord;
using Discord.WebSocket;

namespace IDiscord.DiscordModels
{
    internal class MessageModel : IMessageModel
    {
        private readonly IMessage _message;
        private readonly ISnowflakeEntity _snowflake;
        private readonly IEntity<ulong> _entity;
        private readonly IDeletable _deletable;
        private readonly IEnumerable<IUserModel> _users;

        public MessageModel(SocketMessage socketMessage)
        {
            _message = socketMessage;
            _snowflake = socketMessage;
            _entity = socketMessage;
            _deletable = socketMessage;
            _users = socketMessage.MentionedUsers.Select(mu => new UserModel(mu));
        }
        public MessageModel(IUserMessage userMessage)
        {
            _message = userMessage;
            _snowflake = userMessage;
            _entity = userMessage;
            _deletable = userMessage;
            _users = userMessage.MentionedUserIds.Select(mu => new UserModel(mu));
        }

        public string AuthorName => _message.Author.Username;
        public ulong AuthorId => _message.Author.Id;
        public string Content => _message.Content;
        public bool IsBot => _message.Author.IsBot;
        public bool IsPrivate => _message.Channel.GetType() == typeof(SocketDMChannel);
        public IEnumerable<IUserModel> UsersMentioned => _users;
        public DateTime TimeSent => _message.Timestamp.UtcDateTime;
        public IChannelModel? Channel => new ChannelModel(_message.Channel);
        public async Task verify()
        { 
        var badrole =  (_message.Channel as SocketGuildChannel).Guild.Roles.FirstOrDefault(r => r.Name.ToString()=="Unverified");

        await (_message.Author as IGuildUser).RemoveRoleAsync(badrole);
        var role =  (_message.Channel as SocketGuildChannel).Guild.Roles.FirstOrDefault(r => r.Name.ToString()=="Verified");

        await (_message.Author as IGuildUser).AddRoleAsync(role);
        return;
        }
        
        public async Task Reply(string content)
        {
            await _message.Channel.SendMessageAsync(content);
        }
        public async Task delete()
        {
            await _deletable.DeleteAsync();
        }
    }
}
