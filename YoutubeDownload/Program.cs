using dotenv.net;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace YoutubeDownload
{
    internal class Program
    {
        private const string HelpText =
@"Usage:
  YoutubeDownload [url]

Options:
  --help    Show this help and exit.

If no url is provided, the program will prompt interactively.";
        static async Task Main(string[] args)
        {
            if (args.Length == 1 && args[0] is "--help" or "-h")
            {
                Console.WriteLine(HelpText);
                return;
            }

            do
            {
                try
                {
                    var youtube = new YoutubeClient();

                    // Use argument if provided, else prompt
                    var videoUrl = args.Length > 0 ? args[0] : Prompt("Enter url:");
                    args = Array.Empty<string>(); // consume arg so loop stays interactive

                    var video = await youtube.Videos.GetAsync(videoUrl);
                    Console.WriteLine($"Downloading {video.Title}");

                    string downloadsPath = Environment.GetFolderPath(
                                   Environment.SpecialFolder.UserProfile)
                               + Path.DirectorySeparatorChar
                               + "Downloads";

                    await youtube.Videos.DownloadAsync(
                        videoUrl,
                        Path.Combine(downloadsPath, video.Id + ".mp4"),
                        progress: new Progress<double>(ProgresFunc));

                    Console.WriteLine("Done!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Press <Enter> to download another, or Ctrl+C to quit.");
                Console.ReadLine();
            } while (true);
        }

        private static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine() ?? "";
        }

        private static void ProgresFunc(double obj)
        {
            Console.Clear();
            Console.WriteLine($"Progress: {obj:P0}");
        }
    }
}