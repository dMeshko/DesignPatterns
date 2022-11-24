using Singleton;

Console.Title = "Singleton";

var logger = Logger.Instance;
logger.Log("Test!!");

var otherLogger = Logger.Instance;
otherLogger.Log("Other test!!");

if (logger == otherLogger && otherLogger == Logger.Instance)
{
    Console.WriteLine("Same instances!!");
}

Console.ReadKey();