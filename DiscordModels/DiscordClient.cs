using Discord;
using Discord.WebSocket;
using IDiscord.Handlers;

namespace IDiscord.DiscordModels
{
    internal class DiscordClient : IDiscordClient
    {
        private readonly DiscordSocketClient _client;
        private readonly string _token;

        public DiscordClient(ClientHandler handler, string token)
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.All
            };

            _client = new DiscordSocketClient(config);
            _client.Log += async l => await handler.Log(l.ToString());
            _client.MessageReceived += async sm => await handler.MessageRecieved(new MessageModel(sm));
            _client.ReactionAdded += async (m,c,r) => await handler.ReactionRecieved(new MessageModel(await m.GetOrDownloadAsync()), new ChannelModel(await c.GetOrDownloadAsync()), new ReactionModel(r));
            _client.UserJoined += UserAdded;
            _token = token;
        }

        private Task UserAdded(SocketGuildUser user)
        {
            var role = user.Guild.Roles.FirstOrDefault(r => r.Name.ToString()=="Unverified");
            user.AddRoleAsync(role); 
            return Task.CompletedTask;
        }

        public ulong BotId => _client.CurrentUser.Id;
        public IEnumerable<IServerModel> Servers => _client.Guilds.Select(g => new ServerModel(g));

        public async Task Run()
        {
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            while (Console.ReadKey().KeyChar != 'q') { }
            await _client.StopAsync();
        }
    }
}
