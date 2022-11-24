using Decorator;

Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hello world!");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hello world!");

var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");

var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper1");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper2");
foreach (var message in messageDatabaseDecorator.Messages)
{
    Console.WriteLine($"Stored message: {message}");
}

Console.ReadKey();