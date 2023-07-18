using Discord;
using Discord.WebSocket;

namespace IDiscord.DiscordModels
{
    internal class ChannelModel : IChannelModel
    {
        private readonly SocketGuildChannel? _SGchannel;

        private readonly IMessageChannel? _Mchannel;

        private readonly IChannel _channel;

        public ChannelModel(SocketGuildChannel channel)
        {
            _SGchannel = channel;
            _channel = channel;
            try
            {
                _Mchannel = channel as IMessageChannel;
            }
            catch (Exception)
            {
                _Mchannel = null;
            }
        }

        public ChannelModel(ISocketMessageChannel channel)
        {
            _Mchannel = channel;
            _channel = channel;
            try
            {
                _SGchannel = channel as SocketGuildChannel;
            }
            catch (Exception)
            {
                _SGchannel = null;
            }
        }

        public ChannelModel(IMessageChannel channel)
        {
            _Mchannel = channel;
            if (channel.GetChannelType() == ChannelType.DM)
            {

            }
            else if (channel.GetChannelType() == ChannelType.Text)
            {


            }
            _channel = channel;
            try
            {
                _SGchannel = channel as SocketGuildChannel;
            }
            catch (Exception)
            {
                _SGchannel = null;
            }
        }

        public string Name => _channel.Name;
        public IServerModel? Server => _SGchannel == null ? null : new ServerModel(_SGchannel.Guild);
        public bool IsDM => _channel.GetChannelType() == ChannelType.DM;
        public bool IsText => _channel.GetChannelType() == ChannelType.Text;

        public async Task<bool> PostMessage(string message)
        {
            if (_Mchannel == null)
            {
                return false;
            }

            await _Mchannel.SendMessageAsync(message);

            return true;
        }
    }
}
