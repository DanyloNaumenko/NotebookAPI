using BusinessLayer.Interfaces;

namespace Notebook.AnimeNotesAPI.Logger;

public class ConsoleLog : ILog
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}