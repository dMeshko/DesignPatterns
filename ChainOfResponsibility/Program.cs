using ChainOfResponsibility;

Console.Title = "ChainOfResponsibility";

var validDocument = new Document("Valid document title", DateTimeOffset.UtcNow, true, true);
var invalidDocument = new Document("Invalid document title", DateTimeOffset.UtcNow, false, true);

var documentTitleHandler = new DocumentTitleHandler();
var documentLastModifiedHandler = new DocumentLastModifiedHandler();
var documentApprovedByLitigationHandler = new DocumentApprovedByLitigationHandler();
var documentApprovedByManagementHandler = new DocumentApprovedByManagementHandler();

documentTitleHandler
    .SetSuccessor(documentLastModifiedHandler)
    .SetSuccessor(documentApprovedByLitigationHandler)
    .SetSuccessor(documentApprovedByManagementHandler);

try
{
    Console.WriteLine("Handling valid document..");
    documentTitleHandler.Handle(validDocument);

    Console.WriteLine("Handling invalid document..");
    documentTitleHandler.Handle(invalidDocument);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadKey();