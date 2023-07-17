using Discord_Bot.Commands;
using IDiscord.Handlers;
using IDiscord.DiscordModels;
using Newtonsoft.Json;

var token = File.ReadAllLines("token.txt")[0];

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("Invalid configs");
    return;
}

var botCommands = new List<Func<IDiscordClient, ILogger, IMessageCommand>>
{
    (client,logger) => new LogNameCommand(logger, "Message recieved from bot {0}")
};

var privateCommands = new List<Func<IDiscordClient, ILogger, IMessageCommand>>
{
};

var publicCommands = new List<Func<IDiscordClient, ILogger, IMessageCommand>>
{
    (client,logger) => new verifyCommand(),
    (client,logger) => new hashCommandFormating(),
    (client,logger) => new deletionCommand()

};

var publicReactions = new List<Func<IDiscordClient, ILogger, IReactionCommand>>
{
    (client,logger) => new ReactionLogCommand(logger)
};

var client = new ClientHandler(token, botCommands, privateCommands, publicCommands, null, publicReactions);
client.Run().Wait();

//break

/*
using Discord_Bot.Commands;
using Discord_Data.DataModels;
using IDiscord.Handlers;
using IDiscord.DiscordModels;

var token = JsonConvert.DeserializeObject<Discord_Data.Configs>(File.ReadAllText("configs.json"))?.Token;

// https://discord.gg/XZctqGg9

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("Invalid configs");
    return;
}

var botCommands = new List<Func<IDiscordClient, ILogger, DatabaseContext, IMessageCommand>>
{
    (client,logger,dbcontext) => new LogNameCommand(logger, "Message recieved from bot {0}")
};

var privateCommands = new List<Func<IDiscordClient, ILogger, DatabaseContext, IMessageCommand>>
{
    (client,logger,dbcontext) => new SaveCommand(dbcontext)
};

var publicCommands = new List<Func<IDiscordClient, ILogger, DatabaseContext, IMessageCommand>>
{
    (client,logger,dbcontext) => new WassuuuupCommand(client),
    (client,logger,dbcontext) => new GreetCommand(),
    (client,logger,dbcontext) => new LogNameCommand(logger, "Message recieved from user {0}")
};

var publicReactions = new List<Func<IDiscordClient, ILogger, DatabaseContext, IReactionCommand>>
{
    (client,logger,dbcontext) => new ReactionLogCommand(logger)
};

var client = new ClientHandler(token, botCommands, privateCommands, publicCommands, null, publicReactions);
client.Run().Wait();
*/
