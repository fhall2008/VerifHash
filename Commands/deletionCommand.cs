using IDiscord.DiscordModels;
using System.Security.Cryptography;
using System.Text;

namespace Discord_Bot.Commands
{
    internal class deletionCommand : IMessageCommand
    {
        public deletionCommand()
        {
        }

        public bool RunCondition(IMessageModel message)
        {
         return message.Channel.Name=="verify";
        }

        public Task Run(IMessageModel message)
        {
            message.delete();
            return Task.CompletedTask;
        }

        public bool StopCommands(IMessageModel message)
        {
            return true;
        }
    }
}
