namespace Notebook.AnimeNotesAPI;

public class ConsoleLog : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}