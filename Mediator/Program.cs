using Mediator;

Console.Title = "Mediator";

var teamChatRoom = new TeamChatRoom();

var sven = new Lawyer("Sven");
var kenneth = new Lawyer("Kenneth");
var ann = new AccountManager("Ann");
var john = new AccountManager("John");
var kayle = new AccountManager("Kayle");

teamChatRoom.Register(sven);
teamChatRoom.Register(kenneth);
teamChatRoom.Register(ann);
teamChatRoom.Register(john);
teamChatRoom.Register(kayle);

ann.Send("Please check this!");
sven.Send("10-4!");

sven.Send("Ann", "Can we have a teams meeting?");

sven.SendTo<AccountManager>("Hello accountants!");

Console.ReadKey();