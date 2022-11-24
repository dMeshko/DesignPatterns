// See https://aka.ms/new-console-template for more information

using Iterator;

Console.Title = "Iterator";

var peopleCollection = new PeopleCollection();
peopleCollection.Add(new Person("Marko", "MKD"));
peopleCollection.Add(new Person("Darko", "MKD"));
peopleCollection.Add(new Person("Zharko", "SRB"));

var peopleIterator = peopleCollection.CreateIterator();

for (var person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person.Name);
}

Console.ReadKey();