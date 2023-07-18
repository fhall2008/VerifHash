using IDiscord.DiscordModels;
using System.Security.Cryptography;
using System.Text;

namespace Discord_Bot.Commands
{
    internal class verifyCommand : IMessageCommand
    {
        public verifyCommand()
        {
        }

        public bool RunCondition(IMessageModel message)
        {
         if (message.Channel.Name!="verify"){return false;}
//Convert the string into an array of bytes.
byte[] messageBytes = Encoding.UTF8.GetBytes(message.AuthorName);

//Create the hash value from the array of bytes.
byte[] hashValue = SHA256.HashData(messageBytes);
//Display the hash value to the console.
return message.Content==Convert.ToHexString(hashValue);
        }

        public Task Run(IMessageModel message)
        {
            message.verify();
            message.delete();
            return Task.CompletedTask;
        }

        public bool StopCommands(IMessageModel message)
        {
            return true;
        }
    }
}
