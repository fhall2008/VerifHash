using IDiscord.DiscordModels;

namespace Discord_Bot.Commands
{
    internal class LogNameCommand : IMessageCommand
    {
        private readonly ILogger _logger;
        private readonly string _logText;

        public LogNameCommand(ILogger logger, string logText)
        {
            _logger = logger;
            _logText = logText;
        }

        public bool RunCondition(IMessageModel message)
        {
            return true;
        }
        public Task Run(IMessageModel message)
        {
            _logger.Log(string.Format(_logText, message.AuthorName));
            return Task.CompletedTask;
        }

        public bool StopCommands(IMessageModel message)
        {
            return false;
        }
    }
}
