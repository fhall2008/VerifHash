using Discord.WebSocket;

namespace IDiscord.DiscordModels
{
    internal class CategoryModel : ICategoryModel
    {
        private readonly SocketCategoryChannel _categoryChannel;

        public CategoryModel(SocketCategoryChannel categoryChannel)
        {
            _categoryChannel = categoryChannel;
        }

        public string Name => _categoryChannel.Name;

        public IEnumerable<IChannelModel> Channels => _categoryChannel.Channels.Select(c => new ChannelModel(c));
    }
}
