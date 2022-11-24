// See https://aka.ms/new-console-template for more information

using Interpreter;

Console.Title = "Interpreter";

// syntax tree
var expressions = new List<IRomanExpression>()
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression()
};

var input = 5;
var context = new RomanContext(input);
foreach (var romanExpression in expressions)
{
    romanExpression.Interpret(context);
}

Console.WriteLine($"The roman representation of {input} is {context.Output}");

Console.ReadKey();