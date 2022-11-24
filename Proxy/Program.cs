using Proxy;

Console.Title = "Proxy";

// without proxy
Console.WriteLine("Constructing document..");
var document = new Document("MyDocument.pdf");
Console.WriteLine("Document constructed");
document.DisplayDocument();

Console.WriteLine();

// with proxy
Console.WriteLine("Constructing document proxy..");
var documentProxy = new DocumentProxy("MyDocument.pdf");
Console.WriteLine("Document proxy constructed");
documentProxy.DisplayDocument();

Console.WriteLine();

// with proxy
Console.WriteLine("Constructing protected document proxy..");
var protectedDocumentProxy = new ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
Console.WriteLine("Protected document proxy constructed");
protectedDocumentProxy.DisplayDocument();

Console.ReadKey();