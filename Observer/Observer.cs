// Defines a one-to-many dependency between objects so that when one object changes state,
// all its dependents are notified and updated automatically
namespace Observer
{
    public class TicketChange
    {
        public int Amount { get; set; }
        public int ArtistId { get; set; }

        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }
    }

    /// <summary>
    /// Subject
    /// </summary>
    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        public void AddObserver(ITicketChangeListener observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(ITicketChangeListener observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    /// <summary>
    /// Observer
    /// </summary>
    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    /// <summary>
    /// ConcreteSubject
    /// </summary>
    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            Console.WriteLine("Completing ticket sale!!");
            Notify(new TicketChange(artistId, amount));
        }
    }

    /// <summary>
    /// ConcreteObserver
    /// </summary>
    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{GetType().Name} notified of ticket {ticketChange.ArtistId} and {ticketChange.Amount}");
        }
    }

    /// <summary>
    /// ConcreteObserver
    /// </summary>
    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{GetType().Name} notified of ticket {ticketChange.ArtistId} and {ticketChange.Amount}");
        }
    }
}
