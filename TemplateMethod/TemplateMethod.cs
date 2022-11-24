// Defines the skeleton of an algorithm in an operation, deferring some steps to subclasses.
// This pattern lets subclasses redefine ceertain steps of an algorithm without changing the algorithm's structure
namespace TemplateMethod
{
    /// <summary>
    /// AbstractClass
    /// </summary>
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding server..");
        }

        public abstract void AuthenticateToServer();

        public string ParseHtmlMailBody(string identifer)
        {
            Console.WriteLine("Parsing HTML mail body..");
            return $"This is the body of mail with id: {identifer}";
        }

        /// <summary>
        /// TemplateMethod
        /// </summary>
        /// <param name="identifer"></param>
        /// <returns></returns>
        public string ParseMailBody(string identifer)
        {
            Console.WriteLine("Parsing mail body (in template method)..");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(identifer);
        }
    }

    /// <summary>
    /// ConcreteClass
    /// </summary>
    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Exchange..");
        }
    }

    /// <summary>
    /// ConcreteClass
    /// </summary>
    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache..");
        }
    }

    /// <summary>
    /// ConcreteClass
    /// </summary>
    public class EudoraMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora..");
        }

        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora server though a custom algorithm..");
        }
    }
}
