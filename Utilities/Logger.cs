using IDiscord.DiscordModels;

namespace IDiscord.Utilities
{
    internal class Logger : ILogger
    {
        private readonly StreamWriter _streamWriter;

        public Logger()
        {
            string folderPath = $"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)}//DiscordBotLogs";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var time = Time();
            var filePath = $"{folderPath}//DiscordBotLog{time}.txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            _streamWriter = new StreamWriter(filePath,true);
            _streamWriter.WriteLine($"{time}: Run started");
            _streamWriter.Flush();
        }

        public void Close()
        {
            _streamWriter.WriteLine($"{Time()}: Run finished");
            _streamWriter.Close();
        }

        public void Log(String msg)
        {
            _streamWriter.WriteLine($"{Time()}: {msg}");
            _streamWriter.Flush();
            Console.WriteLine(msg.ToString());
        }

        private static string Time()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        }
    }
}
