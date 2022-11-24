// Provides a surrogate or placeholder for another object to control access to it
// 4 types of proxy:
//  * Remote: client can communicate with the proxy, feels like local resource (hides network and protocol details)
//  * Virtual: allows creating expensive objects on demand (a stand-in for object that is expensive to create)
//  * Smart: allows adding additional logic around the subject (caching or locking access to shared resources)
//  * Protection: used to control access to an object (when objects have different access rights)
namespace Proxy
{
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// RealSubject
    /// </summary>
    public class Document : IDocument
    {
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expensive action: loading a file from disk");

            // fake loading
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }
    }

    /// <summary>
    /// Proxy / RealSubject (VirtualProxy)
    /// </summary>
    public class DocumentProxy : IDocument
    {
        private readonly Lazy<IDocument> _document;

        public DocumentProxy(string fileName)
        {
            _document = new Lazy<IDocument>(() => new Document(fileName));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }

    /// <summary>
    /// Proxy (ProtectionProxy)
    /// </summary>
    public class ProtectedDocumentProxy : IDocument
    {
        private readonly string _fileName;
        private readonly string _userRole;
        private readonly IDocument _documentProxy;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Entering {nameof(DisplayDocument)}");

            if (_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            Console.WriteLine($"Exiting {nameof(DisplayDocument)} in {nameof(ProtectedDocumentProxy)}");
        }
    }
}
