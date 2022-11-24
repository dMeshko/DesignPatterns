using Flyweight;

Console.Title = "Flyweight";

var someString = "abba";

var characterFactory = new CharacterFactory();

var characterObject = characterFactory.GetCharacter(someString[0]);
characterObject?.Draw("Arial", 10);

characterObject = characterFactory.GetCharacter(someString[1]);
characterObject?.Draw("Trebuchet", 12);

characterObject = characterFactory.GetCharacter(someString[2]);
characterObject?.Draw("Times New Roman", 14);

characterObject = characterFactory.GetCharacter(someString[3]);
characterObject?.Draw("Comic Sans", 16);

var paragraph = characterFactory.CreateParagraph(new List<ICharacter> { characterObject }, 1);
paragraph.Draw("Lucinda", 20);

Console.ReadKey();