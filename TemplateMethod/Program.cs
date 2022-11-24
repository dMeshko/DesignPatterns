using TemplateMethod;

Console.Title = "TemplateMethod";

var exchangeMailParser = new ExchangeMailParser();
Console.WriteLine(exchangeMailParser.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

var apacheMailParser = new ExchangeMailParser();
Console.WriteLine(apacheMailParser.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

var eudoraMailParser = new EudoraMailParser();
Console.WriteLine(eudoraMailParser.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

Console.ReadKey();