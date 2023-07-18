using IDiscord.DiscordModels;
using System.Security.Cryptography;
using System.Text;

namespace Discord_Bot.Commands
{
    internal class hashCommandFormating : IMessageCommand
    {
        public hashCommandFormating()
        {
        }

        public bool RunCondition(IMessageModel message)
        {
            return message.Content.StartsWith("verificationhash") && message.UsersMentioned.Count()==1; 
        }

        public Task Run(IMessageModel message)
        {               
            
            
           
//Convert the string into an array of bytes.
byte[] messageBytes = Encoding.UTF8.GetBytes(message.UsersMentioned.First().Name);

//Create the hash value from the array of bytes.
byte[] hashValue = SHA256.HashData(messageBytes);
//Display the hash value to the console.
 message.Reply(Convert.ToHexString(hashValue));
            return Task.CompletedTask;
        }

        public bool StopCommands(IMessageModel message)
        {
            return true;
        }
    }
}
