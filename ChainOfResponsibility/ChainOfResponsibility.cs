using System.ComponentModel.DataAnnotations;

// Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request.
// This pattern chains the receiving objects and passes the request along the chain until an object handles it
namespace ChainOfResponsibility
{
    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagement { get; set; }

        public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagement = approvedByManagement;
        }
    }

    /// <summary>
    /// Handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetSuccessor(IHandler<T> successor);
        void Handle(T request);
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentTitleHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return _successor;
        }

        public void Handle(Document request)
        {
            if (string.IsNullOrEmpty(request.Title))
            {
                throw new ValidationException(new ValidationResult("Title must be filled out", 
                    new List<string> { "Title" }), null, null);
            }

            _successor?.Handle(request);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentLastModifiedHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return _successor;
        }

        public void Handle(Document request)
        {
            if (request.LastModified < DateTime.UtcNow.AddDays(-30))
            {
                throw new ValidationException(new ValidationResult("Document must be modified in the last 30 days",
                    new List<string> { "LastModified" }), null, null);
            }

            _successor?.Handle(request);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentApprovedByLitigationHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return _successor;
        }

        public void Handle(Document request)
        {
            if (!request.ApprovedByLitigation)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by litigation",
                    new List<string> { "ApprovedByLitigation" }), null, null);
            }

            _successor?.Handle(request);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentApprovedByManagementHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return _successor;
        }

        public void Handle(Document request)
        {
            if (!request.ApprovedByManagement)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by management",
                    new List<string> { "ApprovedByManagement" }), null, null);
            }

            _successor?.Handle(request);
        }
    }
}
