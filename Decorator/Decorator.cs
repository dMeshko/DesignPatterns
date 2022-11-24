// Attaches additional responsibilities to an object dynamically. 
// This pattern provides a flexible alternative to sub-classing for extending functionality
namespace Decorator
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }

    /// <summary>
    /// ConcreteComponent
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message {message} sent via {nameof(CloudMailService)}");
            return true;
        }
    }

    /// <summary>
    /// ConcreteComponent
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message {message} sent via {nameof(OnPremiseMailService)}");
            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        protected MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// ConcreteDecorator
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> Messages { get; private set; }

        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
            Messages = new List<string>();
        }

        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                Messages.Add(message);
                return true;
            }

            return false;
        }
    }
}
