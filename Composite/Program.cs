using Directory = Composite.Directory;
using File = Composite.File;

Console.Title = "Composite";

var root = new Directory("root", 0);
var topLevelFile = new File("topLevel.txt", 100);
var topLevelDirectory1 = new Directory("topLevelDirectory1", 4);
var topLevelDirectory2 = new Directory("topLevelDirectory2", 4);

root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

var subLevelFile1 = new File("subLevelFile1.txt", 200);
var subLevelFile2 = new File("subLevelFile2.txt", 150);

topLevelDirectory2.Add(subLevelFile1);
topLevelDirectory2.Add(subLevelFile2);

Console.WriteLine($"Size of {nameof(topLevelDirectory1)}: {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of {nameof(topLevelDirectory2)}: {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of {nameof(root)}: {root.GetSize()}");

Console.ReadKey();